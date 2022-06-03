using System.Xml.Serialization;

namespace YoutubeAudioDownloader2.Controls
{
    public class SettingsManager<T> where T : new()
    {
        #region CREATELOAD
        public static T CreateOrLoad(string filePath)
        {
            return File.Exists(filePath) ? CreateOrLoad(File.OpenRead(filePath)) : new T();
        }

        public static T CreateOrLoad(Stream readStream)
        {
            var genericSettings = default(T);

            if (readStream != null)
            {
                using StreamReader streamReader = new(readStream);

                genericSettings = (T)new XmlSerializer(typeof(T)).Deserialize(streamReader)!;
            }
            else
            {
                genericSettings = new T();
            }

            return genericSettings;
        }
        #endregion

        #region SAVE
        public void Save(string filePath)
        {
            var directoryName = Path.GetDirectoryName(filePath);

            if ((!string.IsNullOrEmpty(directoryName)) && (!Directory.Exists(directoryName)))
            {
                Directory.CreateDirectory(directoryName);
            }

            Save(File.Create(filePath));
        }

        public void Save(Stream writeStream)
        {
            using StreamWriter streamWriter = new(writeStream);

            new XmlSerializer(typeof(T)).Serialize(streamWriter, this);
        }
        #endregion
    }
}