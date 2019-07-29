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
    internal class RuleController
    {
        public T LoadSettings<T>(string settingsFileName)
        {
            if (File.Exists(settingsFileName))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                var file = File.OpenRead(settingsFileName);
                return (T)xmlSerializer.Deserialize(file);
            }
            else return default(T);
        }

        public void SaveSettings(string settingsFileName, Settings settings)
        {
            var xmlSerializer = new XmlSerializer(typeof(Settings));

            var file = System.IO.File.Create(settingsFileName);

            xmlSerializer.Serialize(file, settings);
        }
    }
}