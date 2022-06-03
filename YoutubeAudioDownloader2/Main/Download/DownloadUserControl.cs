using YoutubeAudioDownloader2.Main.Download.Item;
using YoutubeAudioDownloader2.Main.Settings;
using YoutubeAudioDownloader2.Properties;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace YoutubeAudioDownloader2.Main.Download
{
    public partial class DownloadUserControl : UserControl
    {
        #region GLOBAL_VARIABLES
        private static DownloadUserControl? instance;
        public static DownloadUserControl Instance { get { instance ??= new DownloadUserControl(); return instance; } }
        #endregion

        #region CONSTRUCTOR
        private DownloadUserControl()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }
        #endregion

        #region DOWNLOAD
        public void AddToDownload(Video video, IStreamInfo streamInfo, Action actionToPerform)
        {
            panelContent.Controls.Add(new ItemDownloadUserControl(video, streamInfo, actionToPerform));
            panelContent.Controls[panelContent.Controls.Count - 1].BringToFront();

            if (panelContent.Controls.Count == 1)
            {
                panelContent.BackgroundImage = null;

                buttonRemoveAll.Enabled = true;
            }

            if (!SettingsUserControl.Instance.Settings.AutoDownload)
            {
                ((MainForm)FindForm()).PerformButtonDownloadClick();
            }
        }
        #endregion

        #region BUTTON_EVENT
        private void ButtonRemoveAll_Click(object sender, EventArgs e)
        {
            if (ManageCancel("Alcuni download/conversioni sono ancora in corso.\n\nVuoi ripristinare comunque la lista?"))
            {
                panelContent.Controls.Clear();
            }
        }
        #endregion

        #region CANCEL
        public bool ManageCancel(string text)
        {
            var cancelRequired = true;

            foreach (ItemDownloadUserControl entryDownloadUserControl in panelContent.Controls)
            {
                if (entryDownloadUserControl.IsRunning)
                {
                    if (MessageBox.Show(text, "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        cancelRequired = false;
                    }

                    break;
                }
            }

            return cancelRequired;
        }
        #endregion

        #region PANEL_EVENT
        private void PanelContent_ControlRemoved(object sender, ControlEventArgs e)
        {
            e.Control.Dispose();

            if (panelContent.Controls.Count == 0)
            {
                panelContent.BackgroundImage = Resources.PerformDownload;

                buttonRemoveAll.Enabled = false;
            }
        }
        #endregion
    }
}