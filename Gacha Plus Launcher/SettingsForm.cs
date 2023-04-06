using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gacha_Plus_Launcher
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void Ok_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backupdir_button_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(BackupManager.backupDirectory))
                Directory.CreateDirectory(BackupManager.backupDirectory);

            Process.Start("explorer.exe", BackupManager.backupDirectory);
        }

        private void deletealldata_button_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Are you sure you want to delete all data?", "Gacha Plus Launcher", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if(res == DialogResult.Yes)
            {
                BackupManager.DeleteActiveSavedDatas();

                if (File.Exists(GachaPlusForm.pathPath))
                    OtherFunctions.DeleteDirectory(GachaPlusForm.pathPath);

                OtherFunctions.DeleteDirectory(Application.LocalUserAppDataPath);

                OtherFunctions.CustomMessageBoxShow("All data deleted!");
                this.Close();
            }
        }

        private void deletedata_button_Click(object sender = null, EventArgs e = null)
        {
            OtherFunctions.DeleteDirectory(GachaPlusForm.ExtractedDirName);
            OtherFunctions.DeleteFile(GachaPlusForm.DownloadZipName);

            OtherFunctions.CustomMessageBoxShow("Datas deleted!");
        }

        private void custompath_button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            var res = dialog.ShowDialog();
            if(res == DialogResult.OK)
            {
                File.WriteAllText(GachaPlusForm.pathPath, dialog.SelectedPath);
                SettingsForm_Load();
                OtherFunctions.CustomMessageBoxShow("Custom path selected!");
            }
        }

        private void originalpath_button_Click(object sender, EventArgs e)
        {
            OtherFunctions.DeleteFile(GachaPlusForm.pathPath);
            SettingsForm_Load();
            OtherFunctions.CustomMessageBoxShow("Original path restored!");
        }

        private void SettingsForm_Load(object sender = null, EventArgs e = null)
        {
            string pth = Application.LocalUserAppDataPath;
            if (File.Exists(GachaPlusForm.pathPath))
                pth = File.ReadAllText(GachaPlusForm.pathPath);

            path_label.Text = "Game directory path:\n" + pth;

            originalpath_button.Enabled = File.Exists(GachaPlusForm.pathPath);
        }

        private void customdiropem_button_Click(object sender, EventArgs e)
        {
            string pth = Application.LocalUserAppDataPath;
            if (File.Exists(GachaPlusForm.pathPath))
                pth = File.ReadAllText(GachaPlusForm.pathPath);

            if(!Directory.Exists(pth))
                Directory.CreateDirectory(pth);

            Process.Start("explorer.exe", pth);
        }
    }
}
