using YoutubeAudioDownloader2.Controls;

namespace YoutubeAudioDownloader2.Main.Settings
{
    public class SettingsService : SettingsManager<SettingsService>
    {
        #region GLOBAL_VARIABLES
        public static string DefaultSettingsPath => 
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                Path.Combine(Application.ProductName, nameof(SettingsService) + ".xml"));

        public static int MinimumSearchResults => 1;
        public static int MaximumSearchResults => 20;

        public static int DefaultSearchResults => 5;
        public static string DefaultDownloadDirectoryPath => Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
        public static bool DefaultAutoDownload => false;

        public int SearchResults { get; set; }
        public string? DownloadDirectoryPath { get; set; }
        public bool AutoDownload { get; set; }
        #endregion

        #region CONSTRUCTOR
        public SettingsService()
        {
            Reset();
        }
        #endregion

        #region CREATELOAD
        public static SettingsService CreateOrLoad()
        {
            return CreateOrLoad(DefaultSettingsPath);
        }
        #endregion

        #region SAVE
        public void Save()
        {
            Save(DefaultSettingsPath);
        }
        #endregion

        #region RESET
        public void Reset()
        {
            SearchResults = DefaultSearchResults;
            DownloadDirectoryPath = DefaultDownloadDirectoryPath;
            AutoDownload = DefaultAutoDownload;
        }
        #endregion
    }
}