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
    class SettingsWindowController
    {

        const string settingsFileName = "settings.xml";

        public List<Rule> rules;

        public SettingsWindowController()
        {

            rules = new List<Rule>();
            LoadSettings();
            this.AddRule("<<new>>", "", "");
        }

        public void LoadSettings()
        {

            if (File.Exists(settingsFileName)) { 
                var xmlSerializer = new XmlSerializer(typeof(List<Rule>));
                var file = File.OpenRead(settingsFileName);
                rules = (List<Rule>) xmlSerializer.Deserialize(file);
            }

        }

        public void SaveSettings()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Rule>));

            var file = System.IO.File.Create(settingsFileName);

            xmlSerializer.Serialize(file, rules);
        }

        public void AddRule(string name, string fileMask, string destinationFolderPath)
        {
            var rule = new Rule()
            {
                Name = name,
                FileMask = fileMask,
                DestinationFolderPath = destinationFolderPath
            };
            rules.Add(rule);
            
        }

    }
}
