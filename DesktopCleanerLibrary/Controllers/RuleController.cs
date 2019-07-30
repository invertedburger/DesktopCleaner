using DesktopCleaner.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DesktopCleaner.Controllers
{
    public class RuleController
    {
        public T LoadSettings<T>(string settingsFileName) where T : class, new()
        {
            if (File.Exists(settingsFileName))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                var returnValue = new T();

                using (FileStream file = File.OpenRead(settingsFileName))
                {
                    returnValue = (T)xmlSerializer.Deserialize(file);
                }

                return returnValue;
            }
            else return default(T);
        }

        public void SaveSettings(string settingsFileName, Settings settings)
        {
            var xmlSerializer = new XmlSerializer(typeof(Settings));

            using (var file = System.IO.File.Create(settingsFileName))
            {
                xmlSerializer.Serialize(file, settings);
            }
        }
    }
}