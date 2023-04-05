using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gacha_Plus_Launcher
{
    public static class BackupManager
    {
        public static string backupDirectory = Path.Combine(Application.LocalUserAppDataPath, "backup");
        private static string appDataRoaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static string gameSavePath = Path.Combine(appDataRoaming, "com.lunime.gachaclub", "Local Store", "#SharedObjects", "gacha_plus.swf");

        public static void CreateBackup()
        {
            DateTime now = DateTime.Now;
            string formattedDate = now.ToString("yyyy-MM-dd_HH-mm-ss");

            string filename = $"backup-{formattedDate}.sol";

            string sourcePath = Path.Combine(gameSavePath, "gachaclub_save.sol");
            string destinationPath = Path.Combine(backupDirectory, filename);

            if (!File.Exists(sourcePath))
                return;

            if(!Directory.Exists(backupDirectory))
                Directory.CreateDirectory(backupDirectory);

            File.Copy(sourcePath, destinationPath);
        }
        public static bool LoadBackup(string path)
        {
            if (!File.Exists(path))
                return false;

            if (!Directory.Exists(gameSavePath))
                Directory.CreateDirectory(gameSavePath);

            string destinationPath = Path.Combine(gameSavePath, "gachaclub_save.sol");

            if (File.Exists(destinationPath))
            {
                CreateBackup();
                OtherFunctions.DeleteFile(destinationPath);
            }

            File.Copy(path, destinationPath);
            
            return true;
        }
        public static bool LoadLastBackup()
        {
            var backupdir = new DirectoryInfo(backupDirectory);
            if (!backupdir.Exists)
                return false;

            var backups = backupdir.GetFiles().ToList();
            if(backups.Count == 0)
                return false;

            var path = backups.OrderByDescending(x => x.Name).FirstOrDefault().FullName;

            if (!Directory.Exists(gameSavePath))
                Directory.CreateDirectory(gameSavePath);

            string destinationPath = Path.Combine(gameSavePath, "gachaclub_save.sol");

            if (File.Exists(destinationPath))
            {
                CreateBackup();
                OtherFunctions.DeleteFile(destinationPath);
            }

            File.Copy(path, destinationPath);

            return true;
        }
    }
}
