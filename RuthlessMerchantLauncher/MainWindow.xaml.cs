using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace RuthlessMerchantLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string settings = "startupPaths.txt";
        private string vrPath;
        private string gamePath;
        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists(settings))
            {
                string[] files = File.ReadAllLines(settings);
                if (files.Length > 0)
                {
                    try
                    {
                        gamePath = files[0].Split('=')[1];
                    }
                    catch
                    {
                        Start.IsEnabled = false;
                    }
                }
                else
                    Start.IsEnabled = false;

                if (files.Length > 1)
                {
                    try
                    {
                        vrPath = files[1].Split('=')[1];
                    }
                    catch
                    {
                        StartVR.IsEnabled = false;
                    }
                }
                else
                    StartVR.IsEnabled = false;
            }
            else
            {
                Start.IsEnabled = false;
                StartVR.IsEnabled = false;
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(gamePath);
                QuitLauncher();
            }
            catch
            {
                MessageBox.Show("Failed to start " + gamePath + " (File not found)");
            }
        }

        private void StartVR_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                Process.Start(vrPath);
                QuitLauncher();
            }
            catch
            {
                MessageBox.Show("Failed to start " + gamePath + " (File not found)");
            }
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            QuitLauncher();
        }

        private void QuitLauncher()
        {      
            Close();
            Environment.Exit(0);
        }
    }
}
