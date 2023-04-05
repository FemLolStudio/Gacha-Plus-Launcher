using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gacha_Plus_Launcher
{
    public partial class GachaPlusForm : Form
    {
        #region Variables
        private const string LatestVersionDatas = "https://gacha-plus.com/GPscripts/latestversion_and_checksum.php"; //this can be a path for a txt too
        
        private const string ExeName = @"gacha_plus.app\Gacha Plus.exe";

        //  The \\?\ Need to manage longer than 260 character paths.
        private string ExtractedDirName = Path.Combine(@"\\?\" + Application.LocalUserAppDataPath, "App");
        private string VersionPath = Path.Combine(@"\\?\" + Application.LocalUserAppDataPath, "version.txt");
        private string DownloadZipName = Path.Combine(@"\\?\" + Application.LocalUserAppDataPath, "download.zip");

        private string LatestChecksum = "-";
        private string LatestVersion = "0.0.0";
        private string DownloadUrl = "https://www.example.com/download.zip"; //this will be replaced with the actual download link

        /// <summary>
        /// download is in progress, or not
        /// </summary>
        private bool downloading = false;

        #endregion

        /// <summary>
        /// Starting Up function
        /// </summary>
        public GachaPlusForm()
        {
            InitializeComponent();
            DownloadingEndUI();
        }
        Point lastPoint;
        #region Update And Launch
        /// <summary>
        /// Checking updates and after it update or starting up 
        /// </summary>
        private async Task CheckForUpdatesAndStartAsync(bool startiferror = true)
        {
            try
            {
                //getting version, checksum and downloadurl
                string datas = await DownloadStringAsync(LatestVersionDatas);
                LatestVersion = datas.Split('|')[0].Trim();
                LatestChecksum = datas.Split('|')[1].Trim();
                DownloadUrl = datas.Split('|')[2].Trim();

                if (DownloadUrl == "error")
                {
                    throw new Exception("Server error");
                }

                //reading installed version from file
                string installedVersion = "0.0.0"; //default value
                if (File.Exists(VersionPath))
                    installedVersion = File.ReadAllText(VersionPath, Encoding.UTF8);

                //versions ready to compare
                Version latestVersion = new Version(LatestVersion);
                Version version = new Version(installedVersion);

                if (latestVersion > version || !Directory.Exists(ExtractedDirName))
                {
                    // Download and extract the new version
                    await DownloadAndExtractAsync();
                }
                else
                {
                    // Launch the app
                    LaunchApp();
                }
            }
            catch (Exception ex)
            {
                OtherFunctions.CustomMessageBoxShow($"Failed to check for updates: {ex.Message}");

                LaunchApp();
            }
        }
        /// <summary>
        /// Downloading the zip and extract it
        /// </summary>
        /// <returns></returns>
        private async Task DownloadAndExtractAsync()
        {
            try
            {
                // Delete the old version
                ProgressChange($"Deleting old files...", 0);
                OtherFunctions.DeleteDirectory(ExtractedDirName);
                OtherFunctions.DeleteFile(DownloadZipName);

                // Download the new version
                ProgressChange($"Downloading...", 0);
                await DownloadFileAsync(DownloadUrl, DownloadZipName);


                //Getting local checksum
                ProgressChange($"Checking zip...", 100);
                string checksumLocal = OtherFunctions.MD5CheckSum(DownloadZipName);

                //checking checksum
                if (!OtherFunctions.IsSameHash(LatestChecksum, checksumLocal))
                {
                    throw new Exception($"Downloaded file corrupted. Try again! (LatestHash: {LatestChecksum}, LocalHash: {checksumLocal})");
                }


                // Extract the new version
                ProgressChange($"Extracting zip...", 100);
                OtherFunctions.ExtractFilesOneByOne(DownloadZipName, ExtractedDirName);


                // Delete the downloaded zip file
                ProgressChange($"Deleting zip...", 100);
                OtherFunctions.DeleteFile(DownloadZipName);

                // Update versiontxt
                File.WriteAllText(VersionPath, LatestVersion, Encoding.UTF8);

                // Launch the app
                LaunchApp();
            }
            catch (Exception ex)
            {
                OtherFunctions.CustomMessageBoxShow($"Failed to download and extract the new version: {ex.Message}");
                OtherFunctions.DeleteDirectory(ExtractedDirName);
                OtherFunctions.DeleteFile(DownloadZipName);
                DownloadingEndUI();
            }
        }
        /// <summary>
        /// Launching App
        /// </summary>
        private void LaunchApp()
        {
            ProgressChange($"Launching app...", 100);
            try
            {
                Process.Start(Path.Combine(ExtractedDirName, ExeName));
                Application.Exit();
            }
            catch (Exception ex)
            {
                OtherFunctions.CustomMessageBoxShow($"Failed to start: {ex.Message}");
                DownloadingEndUI();
            }
        }
        #endregion

        #region UIControll
        /// <summary>
        /// Exit button Click event
        /// </summary>
        private void exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Start button Click event
        /// </summary>
        private async void start_button_Click(object sender, EventArgs e)
        {
            if (!downloading)
            {
                DownloadingStartUI();
                await CheckForUpdatesAndStartAsync();
            }
        }
        /// <summary>
        /// Update the UI for starting the process
        /// </summary>
        private void DownloadingStartUI()
        {
            downloading = true;
            this.UseWaitCursor= true;

            start_button.BackColor = Color.FromArgb(128, 0, 224);
            start_button.Text = "Starting...";
            download_label.Show();
            download_label.Text = string.Empty;
            download_progressBar.Show();
            download_progressBar.Value = 0;
        }
        /// <summary>
        /// Update the UI for ending the process
        /// </summary>
        private void DownloadingEndUI()
        {
            downloading = false;
            this.UseWaitCursor = false;

            start_button.BackColor = Color.FromArgb(158, 0, 224);
            start_button.Text = "Start";
            download_label.Hide();
            download_label.Text = string.Empty;
            download_progressBar.Hide();
            download_progressBar.Value = 0;
        }
        /// <summary>
        /// Update the progressbar and the progress label
        /// </summary>
        private void ProgressChange(string text, int percent)
        {
            download_progressBar.Invoke(new Action(() => download_progressBar.Value = percent));
            download_label.Invoke(new Action(() => download_label.Text = text));
        }
        private void DragPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void DragPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }

        }
        #endregion

        #region HTTP scripts
        /// <summary>
        /// Downloading the content of a txt file/PHP text content from URL
        /// </summary>
        private async Task<string> DownloadStringAsync(string url)
        {
            using (WebClient client = new WebClient())
            {
                return await client.DownloadStringTaskAsync(url);
            }
        }
        /// <summary>
        /// Downloading a file from URL
        /// </summary>
        private async Task DownloadFileAsync(string url, string filename)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadProgressChanged += (s, e) =>
                {
                    // Update the progress
                    int progressPercentage = e.ProgressPercentage;
                    ProgressChange($"Downloading... {progressPercentage}%", progressPercentage);
                };
                await client.DownloadFileTaskAsync(url, filename);
            }
        }
        #endregion


        private void settings_button_Click(object sender, EventArgs e)
        {
            var ff = new SettingsForm();
            ff.ShowDialog();
        }
    }
}
