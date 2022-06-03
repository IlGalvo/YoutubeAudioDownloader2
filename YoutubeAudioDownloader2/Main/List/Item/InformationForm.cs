using System.Diagnostics;
using YoutubeExplode.Videos;

namespace YoutubeAudioDownloader2.Main.List.Item
{
    public partial class InformationForm : Form
    {
        #region GLOBAL_VARIABLE
        private readonly Video video;
        #endregion

        #region FORM_EVENTS
        public InformationForm(Video video)
        {
            InitializeComponent();

            this.video = video;
        }

        private void InformationForm_Load(object sender, EventArgs e)
        {
            richTextBoxDescription.Text = video.Description;

            labelLikes.Text = video.Engagement.LikeCount.ToString();
            labelDislikes.Text = video.Engagement.DislikeCount.ToString();

            labelViews.Text = video.Engagement.ViewCount.ToString();
            labelOfficial.Text = "Ok";
        }
        #endregion

        #region RICHTEXTBOX_EVENT
        private void RichTextBoxDescription_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start("Explorer.exe", e.LinkText!).Dispose();
        }
        #endregion
    }
}