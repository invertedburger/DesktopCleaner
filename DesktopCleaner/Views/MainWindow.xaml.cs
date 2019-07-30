using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DesktopCleaner.Controllers;
using DesktopCleaner.Models;
using Hardcodet.Wpf.TaskbarNotification;

namespace DesktopCleaner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TaskbarIcon tbi = new TaskbarIcon();

            tbi.ToolTipText = "hello world";
        }

        private void TextBox_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("ahoj");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newSettings = new SettingsWindow();
            newSettings.ShowDialog();
        }
    }
}