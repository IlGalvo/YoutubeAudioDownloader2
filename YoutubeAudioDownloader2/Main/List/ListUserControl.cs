using YoutubeAudioDownloader2.Main.List.Item;
using YoutubeAudioDownloader2.Properties;
using YoutubeExplode.Videos;

namespace YoutubeAudioDownloader2.Main.List
{
    public partial class ListUserControl : UserControl
    {
        #region GLOBAL_VARIABLES
        private static ListUserControl? instance;
        public static ListUserControl Instance { get { instance ??= new ListUserControl(); return instance; } }
        #endregion

        #region CONSTRUCTOR
        private ListUserControl()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }
        #endregion

        #region VIDEO_MANAGERS
        public void AddVideo(Video video)
        {
            panelContent.Controls.Add(new ItemListUserControl(video));
            panelContent.Controls[(panelContent.Controls.Count - 1)].BringToFront();
        }

        public void ClearAllVideo()
        {
            panelContent.Controls.Clear();

            panelContent.BackgroundImage = Resources.PerformResearch;
        }
        #endregion

        #region PANELCONTENT_EVENT
        private void PanelContent_ControlAdded(object sender, ControlEventArgs e)
        {
            if (panelContent.Controls.Count == 1)
            {
                panelContent.BackgroundImage = null;
            }
        }
        #endregion
    }
}