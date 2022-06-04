using YoutubeAudioDownloader2.Main.Download;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace YoutubeAudioDownloader2.Main.List.Item
{
    public partial class ItemListUserControl : UserControl
    {
        #region GLOBAL_VARIABLES
        private readonly Video video;

        private IStreamInfo? streamInfo;
        #endregion

        #region CONSTRUCTOR
        public ItemListUserControl(Video video)
        {
            InitializeComponent();
            Dock = DockStyle.Top;

            this.video = video;
            Startup();
        }
        #endregion

        #region STARTUP
        private async void Startup()
        {
            try
            {
                await webView.EnsureCoreWebView2Async();
                webView.CoreWebView2.Navigate(video.Url);

                labelAuthor.Text = video.Author.ChannelTitle;
                resizableLabelTitle.Text = video.Title;
                labelDuration.Text = video.Duration.ToString();
                labelDate.Text = video.UploadDate.ToString("dd/MM/yyyy");
                labelRating.Text = video.Engagement.AverageRating.ToString("0.0") + "/5";

                var streamManifest = await MainForm.YoutubeClient.Videos.Streams.GetManifestAsync(video.Id);
                streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

                labelEncoding.Text = streamInfo.Container.Name + "/" + ((IAudioStreamInfo)streamInfo).AudioCodec;
                labelBitrate.Text = streamInfo.Bitrate.KiloBitsPerSecond.ToString("0.00") + " Kbps";
                labelSize.Text = streamInfo.Size.MegaBytes.ToString("0.00") + " MB";

                buttonDownload.Enabled = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Errore", exception.Message);
            }
        }
        #endregion

        #region LINKLABEL_EVENT
        private void LinkLabelShowExtra_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using InformationForm informationForm = new(video);

            informationForm.ShowDialog();
        }
        #endregion

        #region BUTTON_EVENT
        private void ButtonDownload_Click(object sender, EventArgs e)
        {
            DownloadUserControl.Instance.AddToDownload(video, streamInfo!, EnableDownloadButton);

            buttonDownload.Enabled = false;
        }
        #endregion

        #region RESET
        private void EnableDownloadButton()
        {
            buttonDownload.Enabled = true;
        }
        #endregion
    }
}