namespace YoutubeAudioDownloader2.Converter
{
    internal sealed class ConverterStatus
    {
        public bool Cancelled { get; set; }
        public object UserToken { get; set; }

        public ConverterStatus(object userToken)
        {
            Cancelled = false;
            UserToken = userToken;
        }
    }
}