using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopCleaner.Models
{
    public class Rule
    {
        public string Name { get; set; }
        public string FileMask { get; set; }
        public string DestinationFolderPath { get; set; }
    }
}
