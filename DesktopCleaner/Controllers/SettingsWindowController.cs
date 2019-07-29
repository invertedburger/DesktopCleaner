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
            settings = new RuleController().LoadSettings<Settings>(settingsFileName);
            this.AddOrModifyRule(Consts.newRule, "", "");
        }

        public void SaveSettings()
        {
            new RuleController().SaveSettings(settingsFileName, settings);
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