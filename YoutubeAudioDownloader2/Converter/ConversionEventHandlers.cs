using System.ComponentModel;

namespace YoutubeAudioDownloader2.Converter
{
    public delegate void ConvertionProgressEventHandler(object sender, ConversionProgressEventArgs e);

    public delegate void ConvertionFinishedEventHandler(object sender, AsyncCompletedEventArgs e);
}
