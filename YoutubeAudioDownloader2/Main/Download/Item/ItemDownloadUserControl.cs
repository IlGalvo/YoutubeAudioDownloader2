using System.ComponentModel;
using System.Diagnostics;
using YoutubeAudioDownloader2.Converter;
using YoutubeAudioDownloader2.Main.Settings;
using YoutubeExplode.Common;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace YoutubeAudioDownloader2.Main.Download.Item
{
    public partial class ItemDownloadUserControl : UserControl
    {
        #region GLOBAL_VARIABLES
        public bool IsRunning { get; private set; }

        private readonly ConverterMp3 converterMp3;

        private readonly Video video;
        private readonly IStreamInfo streamInfo;

        private readonly string downloadPath;
        private readonly Action actionToPerform;

        private readonly object lockObject;

        private CancellationTokenSource? tokenSource;
        #endregion

        #region USERCONTROL_EVENTS
        public ItemDownloadUserControl(Video video, IStreamInfo streamInfo, Action actionToPerform)
        {
            InitializeComponent();

            Dock = DockStyle.Top;

            converterMp3 = new ConverterMp3();

            this.video = video;
            this.streamInfo = streamInfo;

            this.actionToPerform = actionToPerform;

            lockObject = new object();

            downloadPath = string.Join("-", video.Title.Split(Path.GetInvalidFileNameChars())) + "." + streamInfo.Container.Name;
            downloadPath = Path.Combine(SettingsUserControl.Instance.Settings.DownloadDirectoryPath!, downloadPath);

            IsRunning = false;

            Startup();
        }

        private void Startup()
        {
            converterMp3.ConvertionProgress += ConverterMp3_ConvertionProgress;
            converterMp3.ConvertionFinished += ConverterMp3_ConvertionFinished;

            var imageUrl = string.Format("https://img.youtube.com/vi/{0}/hqdefault.jpg", video.Id);
            pictureBoxImage.LoadAsync(imageUrl);

            resizableLabelTitle.Text = video.Title;
            labelBitrateSize.Text = "320 Kbps / " + (streamInfo.Size.MegaBytes * 2.5).ToString("00.00") + " MB~";
            labelInformation.Text = "Pronto";

            buttonDownloadCancel.PerformClick();
        }
        #endregion

        #region BUTTONDOWNLOADCANCEL_EVENT
        private async void ButtonDownloadCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (buttonDownloadCancel.Text == "Scarica")
                {
                    IsRunning = true;

                    SetLabelText("Download in corso...");
                    SetButtonDownloadCancelText("Annulla");
                    EnableButtonRemove(false);

                    tokenSource = new CancellationTokenSource();

                    var progress = new Progress<double>();
                    progress.ProgressChanged += Progress_ProgressChanged;

                    await MainForm.YoutubeClient.Videos.Streams.DownloadAsync(streamInfo, downloadPath, progress, tokenSource.Token);

                    var acea = new AsyncCompletedEventArgs(null, false, Path.ChangeExtension(downloadPath, ".mp3"));
                    ManageAsyncCompleteEventArgs(acea, true);
                }
                else if (buttonDownloadCancel.Text == "Annulla")
                {
                    tokenSource?.Cancel();
                    converterMp3.CancelAsync();
                }
                else
                {
                    Process.Start("explorer.exe", "/select, \"" + Path.ChangeExtension(downloadPath, ".mp3") + "\"");
                }
            }
            catch (TaskCanceledException)
            {
                var acea = new AsyncCompletedEventArgs(null, true, Path.ChangeExtension(downloadPath, ".mp3"));
                ManageAsyncCompleteEventArgs(acea, true);
            }
            catch (Exception exception)
            {
                var acea = new AsyncCompletedEventArgs(exception, false, Path.ChangeExtension(downloadPath, ".mp3"));
                ManageAsyncCompleteEventArgs(acea, true);
            }
        }
        #endregion

        #region BUTTONDOWNLOADCANCEL_STATUS
        private void SetButtonDownloadCancelText(string text)
        {
            if (buttonDownloadCancel.InvokeRequired)
            {
                buttonDownloadCancel.BeginInvoke((MethodInvoker)delegate ()
                {
                    SetButtonDownloadCancelText(text);
                });
            }
            else
            {
                buttonDownloadCancel.Text = text;
            }
        }
        #endregion

        #region DOWNLOAD_EVENTS
        private void Progress_ProgressChanged(object? sender, double e)
        {
            SetProgressBarPercentage((int)(e * 100));
        }

        private void AudioInfo_DownloadFinished(object sender, AsyncCompletedEventArgs e)
        {
            ManageAsyncCompleteEventArgs(e, true);
        }
        #endregion

        #region CONVERTER_EVENTS
        private void ConverterMp3_ConvertionProgress(object sender, ConversionProgressEventArgs e)
        {
            SetProgressBarPercentage(e.ProgressPercentage);
        }

        private void ConverterMp3_ConvertionFinished(object sender, AsyncCompletedEventArgs e)
        {
            ManageAsyncCompleteEventArgs(e, false);
        }
        #endregion

        #region ASYNC_MANAGERS
        private void ManageAsyncCompleteEventArgs(AsyncCompletedEventArgs asyncCompletedEventArgs, bool isDownload)
        {
            var userState = asyncCompletedEventArgs!.UserState!.ToString();
            var fileName = isDownload ? downloadPath : userState;

            if (asyncCompletedEventArgs!.Cancelled)
            {
                ManageResultOperations(fileName!, "Operazione annullata.", 0);
            }
            else if (asyncCompletedEventArgs.Error != null)
            {
                ManageResultOperations(fileName!, "Errore: " + asyncCompletedEventArgs.Error.Message + ".", 0);
            }
            else if (isDownload)
            {
                converterMp3.ConvertToMp3Async(fileName!, userState!, asyncCompletedEventArgs.UserState);

                SetLabelText("Conversione in corso...");
            }
            else
            {
                ManageResultOperations(string.Empty, "Completato.", 100);
            }

            if (!isDownload)
            {
                File.Delete(downloadPath);
            }

            lock (lockObject)
            {
                Monitor.Pulse(lockObject);
            }
        }

        private void ManageResultOperations(string fileName, string message, int percentage)
        {
            if (fileName != string.Empty)
            {
                SetButtonDownloadCancelText("Scarica");

                File.Delete(fileName);
            }
            else
            {
                SetButtonDownloadCancelText("Apri");
            }

            SetLabelText(message);

            EnableButtonRemove(true);
            SetProgressBarPercentage(percentage);

            IsRunning = false;
        }
        #endregion

        #region PROGRESSBAR_STATUS
        private void SetProgressBarPercentage(int percentage)
        {
            if (coloredProgressBarDownload.InvokeRequired)
            {
                coloredProgressBarDownload.BeginInvoke((MethodInvoker)delegate ()
                {
                    SetProgressBarPercentage(percentage);
                });
            }
            else
            {
                coloredProgressBarDownload.Value = percentage;
            }
        }
        #endregion

        #region LABEL_STATUS
        private void SetLabelText(string text)
        {
            if (labelInformation.InvokeRequired)
            {
                labelInformation.BeginInvoke((MethodInvoker)delegate ()
                {
                    SetLabelText(text);
                });
            }
            else
            {
                labelInformation.Text = text;
            }
        }
        #endregion

        #region BUTTONREMOVE_EVENT
        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            var fileName = Path.ChangeExtension(downloadPath, ".mp3");

            if (File.Exists(fileName))
            {
                var text = "Vuoi eliminare anche il file?";

                if (MessageBox.Show(text, "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    File.Delete(fileName);
                }
            }

            Parent.Controls.Remove(this);
        }
        #endregion

        #region BUTTONREMOVE_STATUS
        private void EnableButtonRemove(bool enable)
        {
            if (buttonRemove.InvokeRequired)
            {
                buttonRemove.BeginInvoke((MethodInvoker)delegate ()
                {
                    EnableButtonRemove(enable);
                });
            }
            else
            {
                buttonRemove.Enabled = enable;
            }
        }
        #endregion
    }
}