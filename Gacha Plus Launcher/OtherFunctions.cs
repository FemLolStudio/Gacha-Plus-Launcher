using Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gacha_Plus_Launcher
{
    public class OtherFunctions
    {
        /// <summary>
        /// Delete Directory if exists
        /// </summary>
        public static void DeleteDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }
        /// <summary>
        /// Delete File if exists
        /// </summary>
        public static void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        /// <summary>
        /// Het a MD5 Checksum of a file
        /// </summary>
        public static string MD5CheckSum(string filePath)
        {
            using (MD5 md5hash = MD5.Create())
            {
                using (FileStream fileStream = File.OpenRead(filePath))
                {
                    return BitConverter.ToString(md5hash.ComputeHash(fileStream)).Replace("-", "").ToUpperInvariant();
                }
            }
        }
        /// <summary>
        /// Compare 2 hash string
        /// </summary>
        public static bool IsSameHash(string one, string two)
        {
            return one != null
                && two != null
                && one.Trim().ToUpper().SequenceEqual(two.Trim().ToUpper());
        }
        /// <summary>
        /// Sending some anonymous usage data
        /// </summary>
        public static async Task SendStatistic()
        {
            try
            {
                Dictionary<string, string> datas = new Dictionary<string, string>
                {
                    { "id", ThumbPrint.Value() }
                };

                await PostFormData("https://gacha-plus.com/GPscripts/app_stat.php", datas);
            }
            catch (Exception)
            { }
        }
        /// <summary>
        /// Doing post request
        /// </summary>
        public static async Task<string> PostFormData(string url, Dictionary<string, string> formData)
        {
            using (var httpClient = new HttpClient())
            {
                var content = new FormUrlEncodedContent(formData);
                var response = await httpClient.PostAsync(url, content);
                var responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
        }
        /// <summary>
        /// Custom message box
        /// </summary>
        public static void CustomMessageBoxShow(string message)
        {
            MessageBox.Show(message, "Gacha Plus Launcher");
        }
        /// <summary>
        /// Extract files one by one, need because the longer than 260 character paths
        /// </summary>
        public static void ExtractFilesOneByOne(string DownloadZipName, string ExtractedDirName)
        {
            using (var archive = ZipFile.Open(DownloadZipName, ZipArchiveMode.Read))
            {
                foreach (var entry in archive.Entries)
                {
                    // The FullName property contains the full path of the file or directory in the zip archive
                    var entryFullName = entry.FullName;

                    // cant contains / instead of \
                    var pth = Path.Combine(ExtractedDirName, entryFullName).Replace('/', '\\');

                    // If the entry is a directory, create the directory
                    if (entry.FullName.EndsWith("/"))
                    {
                        Directory.CreateDirectory(pth);
                    }
                    else
                    {
                        // If the entry is a file, extract it to the specified path
                        entry.ExtractToFile(pth, true);
                    }
                }
            }
        }
    }
}
