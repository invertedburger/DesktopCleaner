using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using DesktopCleaner;
using DesktopCleaner.Controllers;
using DesktopCleaner.Models;
using Microsoft.Win32;

namespace DesktopCleanerService
{
    public partial class Service1 : ServiceBase
    {
        private Timer timer;
        private Settings settings;
        private Runner runner;

        public Service1()
        {
            InitializeComponent();
        }

        [assembly: InternalsVisibleTo("TestsAssembly")]
        protected override void OnStart(string[] args)
        {
            runner = new Runner();
        }

        protected override void OnStop()
        {
            timer.Stop();
        }
    }
}