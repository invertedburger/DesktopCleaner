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

        public List<Rule> rules;

        public SettingsWindowController()
        {
            rules = new List<Rule>();
            LoadSettings();
            this.AddOrModifyRule(Consts.newRule, "", "");
        }

        public void LoadSettings()
        {
            if (File.Exists(settingsFileName))
            {
                var xmlSerializer = new XmlSerializer(typeof(List<Rule>));
                var file = File.OpenRead(settingsFileName);
                rules = (List<Rule>)xmlSerializer.Deserialize(file);
            }
        }

        public void SaveSettings()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Rule>));

            var file = System.IO.File.Create(settingsFileName);

            xmlSerializer.Serialize(file, rules);
        }

        public void AddOrModifyRule(string name, string fileMask, string destinationFolderPath)
        {
            var alreadyExists = this.rules.SingleOrDefault(x => x.Name == name);
            if (alreadyExists == null)
            {
                var rule = new Rule()
                {
                    Name = name,
                    FileMask = fileMask,
                    DestinationFolderPath = destinationFolderPath
                };
                rules.Add(rule);
            }
            else
            {
                alreadyExists.FileMask = fileMask;
                alreadyExists.DestinationFolderPath = destinationFolderPath;
            }
        }
    }
}