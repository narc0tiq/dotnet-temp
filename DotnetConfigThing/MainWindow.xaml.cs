using System;
using System.Configuration;
using System.Windows;

namespace DotnetConfigThing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rand = new Random();

        public MainWindow()
        {
            InitializeComponent();
            txtHostname.Text = System.Net.Dns.GetHostName();
        }

        private void btnConfigFuckery_Click(object sender, RoutedEventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["SomeThingy"].Value = rand.Next().ToString();
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");

            txtMessedWith.Visibility = Visibility.Visible;
        }
    }
}
