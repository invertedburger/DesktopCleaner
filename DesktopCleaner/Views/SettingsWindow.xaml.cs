using DesktopCleaner.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesktopCleaner
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public ObservableCollection<Rule> rulesList { get; set; }
        public SettingsWindow()
        {
            InitializeComponent();

            
            var rule = new Rule();
            rulesList = new ObservableCollection<Rule>();
            rulesList.Add(rule);
            rule.Name = "jmeno";

            var rule2 = new Rule();
            rule2.Name = "jmeno2";
            rulesList.Add(rule2);
            


            this.DataContext = rulesList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
       
            this.AddChild(new Button() { Name = "test", Content = "ahoj" });
        }
    }
}
