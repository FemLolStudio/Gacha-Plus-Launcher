using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO.Compression;


namespace GameLauncher
{
    public partial class Form1 : Form
    {
        private const string LatestVersionUrl = "http://example.com/latest_version.txt";
        private const string DownloadUrl = "http://example.com/download.zip";
        private const string ExtractedDirName = "Game";
        private const string ExeName = "Game.exe";
        private const string VersionPath = "version.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            await CheckForUpdatesAsync();
        }

        private async Task CheckForUpdatesAsync()
        {
            try
            {
                string latestVersionString = await DownloadStringAsync(LatestVersionUrl);
                Version latestVersion = new Version(latestVersionString);

                if (latestVersion > new Version(Application.ProductVersion))
                {
                    // Download and extract the new version
                    await DownloadAndExtractAsync();
                }
                else
                {
                    // Launch the game
                    LaunchGame();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to check for updates: {ex.Message}");
                LaunchGame();
            }
        }

        private async Task DownloadAndExtractAsync()
        {
            try
            {
                // Delete the old version
                DeleteDirectory(ExtractedDirName);
                DeleteFile("download.zip");

                // Download the new version
                await DownloadFileAsync(DownloadUrl, "download.zip");

                // Extract the new version
                ZipFile.ExtractToDirectory("download.zip", ExtractedDirName);

                // Delete the downloaded zip file
                DeleteFile("download.zip");

                // Launch the game
                LaunchGame();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to download and extract the new version: {ex.Message}");
            }
        }

        private void LaunchGame()
        {
            Process.Start(ExtractedDirName + "\\" + ExeName);
            Application.Exit();
        }

        private static async Task<string> DownloadStringAsync(string url)
        {
            using (WebClient client = new WebClient())
            {
                return await client.DownloadStringTaskAsync(url);
            }
        }

        private static async Task DownloadFileAsync(string url, string filename)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadProgressChanged += (s, e) =>
                {
                    // Update the progress bar
                    int progressPercentage = e.ProgressPercentage;
                    progressBar1.Invoke(new Action(() => progressBar1.Value = progressPercentage));
                };
                await client.DownloadFileTaskAsync(url, filename);
            }
        }

        private static void DeleteDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }
        private static void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
