using DesktopCleaner.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        }

        public void SaveSettings()
        {
            //settings.Rules.RemoveAt(0);
            SetStartUpOnBoot(settings.StartOnBoot);
            SaveSettingsFileLocation();
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

        public void DeleteRule(Rule selecteditem)
        {
            settings.Rules.Remove(selecteditem);
        }

        public void SaveSettingsFileLocation()
        {
            Registry.CurrentUser.CreateSubKey("SOFTWARE\\IvoSoftware\\DesktopCleaner");
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\IvoSoftware\\DesktopCleaner", true))
            {
                key.SetValue("DesktopCleanerPath", Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), Consts.settingsFileName));
            }
        }

        public void SetStartUpOnBoot(bool startOnBoot)
        {
            if (startOnBoot)
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.SetValue("DesktopCleaner", Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), Consts.runnerFileName));
                }
            }
            else
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.DeleteValue("DesktopCleaner");
                }
            }
        }
    }
}