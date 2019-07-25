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
    internal class SettingsWindowController
    {
        private const string settingsFileName = "settings.xml";

        public Settings settings;

        public SettingsWindowController()
        {
            settings = new Settings();
            settings = LoadSettings<Settings>();
            this.AddOrModifyRule(Consts.newRule, "", "");
        }

        public T LoadSettings<T>()
        {
            if (File.Exists(settingsFileName))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                var file = File.OpenRead(settingsFileName);
                return (T)xmlSerializer.Deserialize(file);
            }
            else return default(T);
        }

        public void SaveSettings()
        {
            var xmlSerializer = new XmlSerializer(typeof(Settings));

            var file = System.IO.File.Create(settingsFileName);

            xmlSerializer.Serialize(file, settings);
        }

        public void AddOrModifyRule(string name, string fileMask, string destinationFolderPath)
        {
            var alreadyExists = settings.Rules.SingleOrDefault(x => x.Name == name);
            if (alreadyExists == null)
            {
                var rule = new Rule()
                {
                    Name = name,
                    FileMask = fileMask,
                    DestinationFolderPath = destinationFolderPath
                };
                settings.Rules.Add(rule);
            }
            else
            {
                alreadyExists.FileMask = fileMask;
                alreadyExists.DestinationFolderPath = destinationFolderPath;
            }
        }
    }
}