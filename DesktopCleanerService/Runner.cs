using DesktopCleaner;
using DesktopCleaner.Controllers;
using DesktopCleaner.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DesktopCleanerService
{
    internal class Runner
    {
        private Timer timer;
        private Settings settings;

        public Runner()
        {
            string settingsFilePath;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\IvoSoftware\\DesktopCleaner", true))
            {
                settingsFilePath = key.GetValue("DesktopCleanerPath").ToString();
            }
            settings = new RuleController().LoadSettings<Settings>(settingsFilePath);
            timer = new Timer(settings.Timer * 1000);
            timer.Elapsed += TimerElaped;
            timer.Start();
        }

        public void TimerElaped(Object source, ElapsedEventArgs e)
        {
            ((Timer)source).Stop();

            foreach (var rule in settings.Rules)
            {
                var roleRunner = new RuleRunner(rule);
            }
        ((Timer)source).Start();
        }
    }
}