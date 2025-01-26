using Market.Languages;
using Market.model;
using Market.Themes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market.Settings
{
    [Serializable]
    internal class Setting
    {
        private const string FILE = "save.ser";
        private static Dictionary<string, Setting> usersSettings { get; set; }
        public Language Language { get; set; }
        public Theme Theme { get; set; }

        public static Setting singleton { get; set; }
        private Setting() 
        {
            Language = new EnglishLanguage();
            Theme = new LightTheme();
        }

        public static Setting GetSettings() 
        {
            if(singleton == null)
                singleton = new Setting();
            return singleton;
        }

        public static void save(UserDTO user)
        {
            if(usersSettings == null)
                usersSettings = new Dictionary<string, Setting>();
            if(!usersSettings.ContainsKey(user.Username))
            {
                usersSettings.Add(user.Username, GetSettings());
            }
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(FILE, FileMode.OpenOrCreate, FileAccess.Write);
            formatter.Serialize(stream, usersSettings);
            stream.Close();
        }

        public static void load(UserDTO user)
        {
            if(File.Exists(FILE)) 
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(FILE, FileMode.Open, FileAccess.Read);
                usersSettings = (Dictionary<string, Setting>)formatter.Deserialize(stream);
                stream.Close();
                if (usersSettings.ContainsKey(user.Username))
                    singleton = usersSettings[user.Username];
            }
        }
    }
}
