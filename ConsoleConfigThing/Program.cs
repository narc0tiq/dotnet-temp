using System;
using System.Configuration;

namespace ConsoleConfigThing
{
    class Program
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Your hostname is {0}", System.Net.Dns.GetHostName());

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["SomeThingy"].Value = rand.Next().ToString();
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
