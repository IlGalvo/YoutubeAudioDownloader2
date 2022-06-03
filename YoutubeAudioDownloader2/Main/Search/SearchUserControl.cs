using YoutubeAudioDownloader2.Main.List;
using YoutubeAudioDownloader2.Main.Settings;
using YoutubeExplode.Videos;

namespace YoutubeAudioDownloader2.Main.Search
{
    public partial class SearchUserControl : UserControl
    {
        #region GLOBAL_VARIABLES
        private static SearchUserControl? instance;
        public static SearchUserControl Instance { get { instance ??= new SearchUserControl(); return instance; } }
        #endregion

        #region CONSTRUCTOR
        private SearchUserControl()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            labelInformation.Text = string.Empty;
        }
        #endregion

        #region OPTIMIZEDTEXTBOX_EVENT
        private void OptimizedTextBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (buttonSearch.Enabled && e.KeyCode == Keys.Enter)
            {
                buttonSearch.PerformClick();
            }
        }
        #endregion

        #region BUTTON_EVENT
        private async void ButtonSearch_ClickAsync(object sender, EventArgs e)
        {
            labelInformation.Text = string.Empty;

            if (!string.IsNullOrEmpty(placeholderRichTextBoxSearch.Text))
            {
                ListUserControl.Instance.ClearAllVideo();

                panelLoading.Visible = true;
                buttonSearch.Enabled = false;

                var query = placeholderRichTextBoxSearch.Text;

                try
                {
                    var videoId = VideoId.TryParse(query);

                    if (videoId != null)
                    {
                        var video = await MainForm.YoutubeClient.Videos.GetAsync((VideoId)videoId);
                        ListUserControl.Instance.AddVideo(video);

                        ((MainForm)FindForm()).PerformButtonListClick();
                    }
                    else
                    {
                        var count = 0;

                        await foreach (var videoSearchResult in MainForm.YoutubeClient.Search.GetVideosAsync(query))
                        {
                            var video = await MainForm.YoutubeClient.Videos.GetAsync(videoSearchResult.Id);

                            ListUserControl.Instance.AddVideo(video);

                            count++;

                            if (count == SettingsUserControl.Instance.Settings.SearchResults)
                            {
                                break;
                            }
                        }

                        if (count != 0)
                        {
                            ((MainForm)FindForm()).PerformButtonListClick();
                        }
                        else
                        {
                            labelInformation.Text = "Nessun risultato.";
                        }
                    }
                }
                catch (Exception exception)
                {
                    labelInformation.Text = "Errore: " + exception.Message;
                }
                finally
                {
                    panelLoading.Visible = false;
                    buttonSearch.Enabled = true;
                }
            }
        }
        #endregion
    }
}