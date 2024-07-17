using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;
using System.Diagnostics;

namespace autoinstall
{
    public class AppInfo
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string DownloadUrl { get; set; }
        public string Type { get; set; }
        public string Params { get; set; }
        public string AfterParams { get; set; }
    }

    public class Category : Dictionary<string, AppInfo> { }

    public class RootObject : Dictionary<string, Category> { }

    public partial class MainWindow : Window
    {
        private RootObject appsData;
        private Installation installationWindow;

        public MainWindow()
        {
            InitializeComponent();
            LoadApps();
        }

        private void LoadApps()
        {
            appsData = JsonConvert.DeserializeObject<RootObject>(Apps.Json);

            foreach (var Category in appsData)
            {
                var categoryPanel = new StackPanel { Margin = new Thickness(10) };

                var categoryTextBlock = new TextBlock
                {
                    Text = Category.Key,
                    FontSize = 16,
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(0, 0, 0, 10)
                };
                categoryPanel.Children.Add(categoryTextBlock);

                foreach (var app in Category.Value)
                {
                    var appPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5, 0, 5) };

                    var checkbox = new CheckBox { Margin = new Thickness(5) };

                    var icon = new Image
                    {
                        Width = 20,
                        Height = 20,
                        Source = new BitmapImage(new Uri($"pack://application:,,,/icons/{app.Value.Icon}")) 
                    };

                    var appName = new TextBlock { Text = app.Value.Name, VerticalAlignment = VerticalAlignment.Center, Margin = new Thickness(7, 0, 0, 0) };

                    appPanel.Children.Add(checkbox);
                    appPanel.Children.Add(icon);
                    appPanel.Children.Add(appName);

                    categoryPanel.Children.Add(appPanel);
                }

                CategoriesPanel.Children.Add(categoryPanel);
            }
        }

        private async void InstallButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedApps = new List<AppInfo>();

            foreach (StackPanel categoryPanel in CategoriesPanel.Children.OfType<StackPanel>())
            {
                foreach (StackPanel appPanel in categoryPanel.Children.OfType<StackPanel>())
                {
                    CheckBox checkbox = appPanel.Children.OfType<CheckBox>().FirstOrDefault();
                    if (checkbox != null && checkbox.IsChecked == true)
                    {
                        TextBlock appName = appPanel.Children.OfType<TextBlock>().FirstOrDefault();
                        if (appName != null)
                        {
                            foreach (var Category in appsData)
                            {
                                foreach (var app in Category.Value)
                                {
                                    if (app.Value.Name == appName.Text)
                                    {
                                        selectedApps.Add(app.Value);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            this.Hide();
            installationWindow = new Installation();
            installationWindow.Show();

            foreach (var app in selectedApps)
            {
                await installationWindow.InstallApp(app);
            }

            installationWindow.Close();
            MessageBox.Show("All apps have been installed correctly.", "Installation completed", MessageBoxButton.OK, MessageBoxImage.Information);
            Application.Current.Shutdown();
        }
    }
}
