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
using DesktopCleaner.Models;

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
            var timer = new Timer(1000);
            timer.Elapsed += TimerElaped;
        }

        public void TimerElaped(Object source, ElapsedEventArgs e)
        {

        }

        private void TextBox_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("ahoj");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newSettings = new SettingsWindow();
            newSettings.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
