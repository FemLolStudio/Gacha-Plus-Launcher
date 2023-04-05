using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
            Process.Start("explorer.exe", BackupManager.backupDirectory);
        }

        private void deletealldata_button_Click(object sender, EventArgs e)
        {

        }

        private void deletedata_button_Click(object sender, EventArgs e)
        {

        }

        private void custompath_button_Click(object sender, EventArgs e)
        {

        }

        private void originalpath_button_Click(object sender, EventArgs e)
        {

        }
    }
}
