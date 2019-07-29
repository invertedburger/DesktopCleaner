using DesktopCleaner.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopCleaner
{
    internal class RoleRunner
    {
        public RoleRunner(Rule rule)
        {
            var path = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE"), "Desktop");

            foreach (var item in Directory.GetFiles(path, rule.FileMask))
            {
                File.Move(item, rule.DestinationFolderPath);
            }
        }
    }
}