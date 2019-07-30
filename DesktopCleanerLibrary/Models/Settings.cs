using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopCleaner.Models
{
    public class Settings
    {
        public List<Rule> Rules { get; set; }
        public int Timer { get; set; }
        public bool StartOnBoot { get; set; }

        public Settings()
        {
            Rules = new List<Rule>();
        }
    }
}