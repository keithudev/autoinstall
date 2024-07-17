using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Diagnostics;
using System.Windows.Controls;

namespace autoinstall
{
    public partial class Installation : Window
    {
        public Installation()
        {
            InitializeComponent();
        }

        public async Task InstallApp(AppInfo appInfo)
        {
            Dispatcher.Invoke(() =>
            {
                AppName.Text = appInfo.Name;
                AppIcon.Source = new BitmapImage(new Uri($"pack://application:,,,/icons/{appInfo.Icon}"));
            });

            string tempPath = Path.Combine(Path.GetTempPath(), "autoinstall");
            Directory.CreateDirectory(tempPath);
            string installerPath = Path.Combine(tempPath, $"{Guid.NewGuid()}.{appInfo.Type}");

            ProgressText.Text = "Downloading...";

            using (var client = new WebClient())
            {
                client.DownloadProgressChanged += (s, e) =>
                {
                    ProgressBar.Value = e.ProgressPercentage;
                    ProgressText.Text = $"Downloading... {e.BytesReceived / 1024 / 1024} MB / {e.TotalBytesToReceive / 1024 / 1024} MB";
                };
                await client.DownloadFileTaskAsync(new Uri(appInfo.DownloadUrl), installerPath);
            }

            ProgressText.Text = "Installing...";
            ProgressBar.IsIndeterminate = true;
            if (appInfo.Type == "msi")
            {
                Process process = new Process();
                process.StartInfo.FileName = "msiexec";
                process.StartInfo.Arguments = $"/i \"{installerPath}\" {appInfo.Params}";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                await process.WaitForExitAsync();
            }
            else
            {
                Process process = new Process();
                process.StartInfo.FileName = installerPath;
                process.StartInfo.Arguments = appInfo.Params;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                await process.WaitForExitAsync();
            }

            if (!string.IsNullOrEmpty(appInfo.AfterParams))
            {
                ProgressText.Text = "Executing post-installation commands...";
                Process afterProcess = new Process();
                afterProcess.StartInfo.FileName = "cmd.exe";
                afterProcess.StartInfo.Arguments = $"/C {appInfo.AfterParams}";
                afterProcess.StartInfo.UseShellExecute = false;
                afterProcess.StartInfo.CreateNoWindow = true;
                afterProcess.Start();
                await afterProcess.WaitForExitAsync();
            }

            ProgressText.Text = "Deleting temp files...";

            bool fileDeleted = false;
            while (!fileDeleted)
            {
                try
                {
                    File.Delete(installerPath);
                    fileDeleted = true;
                }
                catch
                {
                    await Task.Delay(1000); 
                }
            }

            ProgressText.Text = "Installation complete!";
            ProgressBar.IsIndeterminate = false;
            ProgressBar.Value = 100;
        }


    }
}
