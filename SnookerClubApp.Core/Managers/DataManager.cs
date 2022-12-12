using Newtonsoft.Json;

using System.IO;

namespace SnookerClubApp.Core.Managers
{
    /// <summary>
    /// Responsible for storing and loading data in the json format
    /// </summary>
    public class DataManager
    {

        #region Public Static Members

        /// <summary>
        /// Saves data to the specified path
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">The path where to store the data</param>
        /// <param name="value">The value which is to be serialized and stored</param>
        /// <returns></returns>
        public void SaveData<T>(string path, T value)
        {
            string res = JsonConvert.SerializeObject(value);
            using(StreamWriter writer = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate)))
            {
                writer.Write(res);
            }
        }

        /// <summary>
        /// Loads data from the specified location
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">The path from where data is to be loaded</param>
        /// <returns></returns>
        public T LoadData<T>(string path)
            where T: class
        {
            FileInfo info = new FileInfo(path);
            if (!info.Exists)
            {
                return null;
            }
            string text = "";
            using(StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open)))
            {
                text = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<T>(text);
        }

        #endregion

    }
}
