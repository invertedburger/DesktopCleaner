using DesktopCleaner.Models;
using System;
using System.IO;

namespace DesktopCleaner
{
    public class RuleRunner
    {
        public RuleRunner(Rule rule)
        {
            var path = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE"), "Desktop");

            foreach (var item in Directory.GetFiles(path, rule.FileMask))
            {
                var destination = Path.Combine(rule.DestinationFolderPath, Path.GetFileName(item));

                if (!File.Exists(destination))
                    File.Move(item, destination);
                else
                {
                }
            }
        }
    }
}