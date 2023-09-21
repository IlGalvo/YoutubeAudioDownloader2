﻿using System.ComponentModel;
using System.Diagnostics;
using System.IO.Compression;
using YoutubeAudioDownloader2.Properties;

namespace YoutubeAudioDownloader2.Converter
{
    public sealed class ConverterMp3 : IDisposable
    {
        #region GLOBAL_VARIABLES
        private static readonly string FfmpegPath = Path.Combine(Path.GetTempPath(), nameof(Resources.ffmpeg) + ".exe");
        private static readonly object LockObject = new();

        private readonly Process ffmpegProcess;

        private ConverterStatus? converterStatus;
        private TimeSpan totalDuration;

        public event ConvertionProgressEventHandler? ConvertionProgress;
        public event ConvertionFinishedEventHandler? ConvertionFinished;
        #endregion

        #region STATIC
        static ConverterMp3()
        {
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
        }

        private static void CurrentDomain_ProcessExit(object? sender, EventArgs e)
        {
            if (File.Exists(FfmpegPath))
            {
                File.Delete(FfmpegPath);
            }
        }
        #endregion

        #region CONSTRUCTOR
        public ConverterMp3()
        {
            ffmpegProcess = new Process();

            ffmpegProcess.StartInfo.FileName = FfmpegPath;
            ffmpegProcess.StartInfo.CreateNoWindow = true;
            ffmpegProcess.StartInfo.UseShellExecute = false;
            ffmpegProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ffmpegProcess.StartInfo.RedirectStandardInput = true;
            ffmpegProcess.StartInfo.RedirectStandardError = true;
            ffmpegProcess.EnableRaisingEvents = true;

            ffmpegProcess.ErrorDataReceived += Process_ErrorDataReceived;
            ffmpegProcess.Exited += FfmpegProcess_Exited;

            converterStatus = null;
            totalDuration = TimeSpan.Zero;
        }
        #endregion

        #region CONVERT
        public void ConvertToMp3Async(string sourceFileName, string destinationFileName, object userToken)
        {
            sourceFileName = ValidateGenericField(sourceFileName, nameof(sourceFileName));

            if (!File.Exists(sourceFileName))
            {
                throw new FileNotFoundException();
            }

            destinationFileName = ValidateGenericField(destinationFileName, nameof(destinationFileName));

            lock (LockObject)
            {
                if (!File.Exists(FfmpegPath))
                {
                    using (ZipArchive zipArchive = new(new MemoryStream(Resources.ffmpeg)))
                    {
                        zipArchive.ExtractToDirectory(Path.GetTempPath());
                    }

                    File.SetAttributes(FfmpegPath, FileAttributes.Hidden);
                }
            }

            converterStatus = new ConverterStatus(userToken);

            ffmpegProcess.StartInfo.Arguments = "-hide_banner -v info -y -i \"" + sourceFileName + "\" -f mp3 -b:a 320k \"" + destinationFileName + "\"";
            ffmpegProcess.Start();

            ffmpegProcess.BeginErrorReadLine();
        }
        #endregion

        #region PROCESS_EVENTS
        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                var data = e.Data.ToLower().Trim();

                if (data.StartsWith("duration"))
                {
                    totalDuration = TimeSpan.Parse(ExtractValue(data, "duration: ", ","));
                }
                else if (data.StartsWith("size") && TimeSpan.TryParse(ExtractValue(data, "time=", " "), out var currentDuration))
                {
                    ConvertionProgress?.Invoke(this, new ConversionProgressEventArgs(currentDuration, totalDuration, converterStatus!.UserToken));
                }
            }
        }

        private void FfmpegProcess_Exited(object? sender, EventArgs e)
        {
            ffmpegProcess.CancelErrorRead();

            var exception = (ffmpegProcess.ExitCode != 0) ? new Exception("Errore durante la conversione.") : null;
            ConvertionFinished?.Invoke(this, new AsyncCompletedEventArgs(exception, converterStatus!.Cancelled, converterStatus.UserToken));

            converterStatus = null;
        }
        #endregion

        #region CANCEL
        public void CancelAsync()
        {
            if ((converterStatus != null) && (!converterStatus.Cancelled))
            {
                converterStatus.Cancelled = true;

                ffmpegProcess.StandardInput.WriteLine("q");
            }
        }
        #endregion

        #region DISPOSE
        private bool disposedValue = false;

        public void Dispose()
        {
            if (!disposedValue)
            {
                disposedValue = true;

                if (converterStatus != null)
                {
                    ffmpegProcess.WaitForExit();
                }

                ffmpegProcess.Dispose();
            }
        }
        #endregion

        #region UTILITIES
        public static string ValidateGenericField(string genericField, string fieldName)
        {
            if (genericField == null)
            {
                throw new ArgumentNullException(fieldName);
            }

            genericField = genericField.Trim().Normalize();

            if (genericField == string.Empty)
            {
                throw new ArgumentException(fieldName);
            }

            return genericField;
        }

        public static string ExtractValue(string fullText, string keyStart, string keyStop)
        {
            fullText = fullText[(fullText.IndexOf(keyStart) + keyStart.Length)..];

            return fullText[..fullText.IndexOf(keyStop)];
        }
        #endregion
    }
}