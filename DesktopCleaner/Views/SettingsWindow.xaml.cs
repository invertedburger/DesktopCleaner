using DesktopCleaner.Controllers;
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
        public ObservableCollection<Rule> RulesList { get; set; }
        private SettingsWindowController settingsWindowController;

        public SettingsWindow()
        {
            InitializeComponent();
            settingsWindowController = new SettingsWindowController();

            //var rule = new Rule();
            //RulesList = new ObservableCollection<Rule>();
            //RulesList.Add(rule);
            //rule.Name = "jmeno";

            //var rule2 = new Rule();
            //rule2.Name = "jmeno2";
            //RulesList.Add(rule2);

            this.DataContext = settingsWindowController.settings;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.AddChild(new Button() { Name = "test", Content = "ahoj" });
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            settingsWindowController.AddOrModifyRule(TextBoxName.Text, TextBoxFileMask.Text, TextBoxFolder.Text);
            this.DataContext = null;
            this.DataContext = settingsWindowController.settings;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            settingsWindowController.SaveSettings();
        }

        private void RefreshList()
        {
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = (ListBox)sender;
            var selectedItem = (Rule)listbox.SelectedItem;

            if ((selectedItem != null) && (selectedItem.Name != Consts.newRule))
            {
                TextBoxName.Text = settingsWindowController.settings.Rules.Single(x => x.Name == selectedItem.Name).Name;
                TextBoxFileMask.Text = settingsWindowController.settings.Rules.Single(x => x.Name == selectedItem.Name).FileMask;
                TextBoxFolder.Text = settingsWindowController.settings.Rules.Single(x => x.Name == selectedItem.Name).DestinationFolderPath;
            }
            else
            {
                TextBoxName.Text = TextBoxFileMask.Text = TextBoxFolder.Text = String.Empty;
            }
        }
    }
}