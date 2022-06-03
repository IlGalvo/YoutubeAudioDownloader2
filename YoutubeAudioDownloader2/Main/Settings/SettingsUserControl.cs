namespace YoutubeAudioDownloader2.Main.Settings
{
    public partial class SettingsUserControl : UserControl
    {
        #region GLOBAL_VARIABLES
        private static SettingsUserControl? instance;
        public static SettingsUserControl Instance { get { instance ??= new SettingsUserControl(); return instance; } }

        public SettingsService Settings { get; private set; }
        #endregion

        #region CONSTRUCTOR
        private SettingsUserControl()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            Settings = SettingsService.CreateOrLoad();
            Startup();
        }
        #endregion

        #region STARTUP
        private void Startup()
        {
            numericUpDownSearchResults.Value = Settings.SearchResults;
            richTextBoxDownloadPath.Text = Settings.DownloadDirectoryPath;
            toggleButtonSilentDownload.ToggleState = Settings.AutoDownload;

            folderBrowserDialogPath.SelectedPath = richTextBoxDownloadPath.Text;
        }
        #endregion

        #region NUMERICUPDOWN_EVENT
        private void NumericUpDownSearchResults_ValueChanged(object sender, EventArgs e)
        {
            Settings.SearchResults = (int)numericUpDownSearchResults.Value;
        }
        #endregion

        #region BUTTONDOWNLOADPATH_EVENT
        private void ButtonDownloadPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogPath.ShowDialog() == DialogResult.OK)
            {
                richTextBoxDownloadPath.Text = folderBrowserDialogPath.SelectedPath;
            }

            Settings.DownloadDirectoryPath = richTextBoxDownloadPath.Text;
        }
        #endregion

        #region TOGGLEBUTTON_EVENT
        private void ToggleButtonSilentDownload_ToggleChanged(object sender, EventArgs e)
        {
            Settings.AutoDownload = toggleButtonSilentDownload.ToggleState;
        }
        #endregion

        #region BUTTONRESTORE_EVENT
        private void ButtonRestore_Click(object sender, EventArgs e)
        {
            Settings.Reset();

            Startup();
        }
        #endregion
    }
}
