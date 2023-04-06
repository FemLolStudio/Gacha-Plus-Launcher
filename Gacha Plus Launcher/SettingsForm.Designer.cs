namespace Gacha_Plus_Launcher
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.deletealldata_button = new System.Windows.Forms.Button();
            this.deletedata_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Ok_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.originalpath_button = new System.Windows.Forms.Button();
            this.custompath_button = new System.Windows.Forms.Button();
            this.path_label = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.backupdir_button = new System.Windows.Forms.Button();
            this.customdiropem_button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // deletealldata_button
            // 
            this.deletealldata_button.AutoSize = true;
            this.deletealldata_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.deletealldata_button.ForeColor = System.Drawing.Color.Red;
            this.deletealldata_button.Location = new System.Drawing.Point(6, 106);
            this.deletealldata_button.Name = "deletealldata_button";
            this.deletealldata_button.Size = new System.Drawing.Size(108, 25);
            this.deletealldata_button.TabIndex = 0;
            this.deletealldata_button.Text = "Delete All data";
            this.deletealldata_button.UseVisualStyleBackColor = true;
            this.deletealldata_button.Click += new System.EventHandler(this.deletealldata_button_Click);
            // 
            // deletedata_button
            // 
            this.deletedata_button.AutoSize = true;
            this.deletedata_button.Location = new System.Drawing.Point(10, 19);
            this.deletedata_button.Name = "deletedata_button";
            this.deletedata_button.Size = new System.Drawing.Size(98, 23);
            this.deletedata_button.TabIndex = 1;
            this.deletedata_button.Text = "Delete game files";
            this.deletedata_button.UseVisualStyleBackColor = true;
            this.deletedata_button.Click += new System.EventHandler(this.deletedata_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "If somewhy the game not starting up try this function.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(341, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "This option will delete your all data from Gacha Plus from this computer.\r\nYour O" +
    "Cs and progress too.";
            // 
            // Ok_button
            // 
            this.Ok_button.Location = new System.Drawing.Point(334, 330);
            this.Ok_button.Name = "Ok_button";
            this.Ok_button.Size = new System.Drawing.Size(75, 23);
            this.Ok_button.TabIndex = 4;
            this.Ok_button.Text = "Ok";
            this.Ok_button.UseVisualStyleBackColor = true;
            this.Ok_button.Click += new System.EventHandler(this.Ok_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.customdiropem_button);
            this.groupBox1.Controls.Add(this.originalpath_button);
            this.groupBox1.Controls.Add(this.custompath_button);
            this.groupBox1.Controls.Add(this.path_label);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 114);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datas";
            // 
            // originalpath_button
            // 
            this.originalpath_button.AutoSize = true;
            this.originalpath_button.Location = new System.Drawing.Point(283, 85);
            this.originalpath_button.Name = "originalpath_button";
            this.originalpath_button.Size = new System.Drawing.Size(108, 23);
            this.originalpath_button.TabIndex = 3;
            this.originalpath_button.Text = "Use original path";
            this.originalpath_button.UseVisualStyleBackColor = true;
            this.originalpath_button.Click += new System.EventHandler(this.originalpath_button_Click);
            // 
            // custompath_button
            // 
            this.custompath_button.AutoSize = true;
            this.custompath_button.Location = new System.Drawing.Point(169, 85);
            this.custompath_button.Name = "custompath_button";
            this.custompath_button.Size = new System.Drawing.Size(108, 23);
            this.custompath_button.TabIndex = 2;
            this.custompath_button.Text = "Select custom path";
            this.custompath_button.UseVisualStyleBackColor = true;
            this.custompath_button.Click += new System.EventHandler(this.custompath_button_Click);
            // 
            // path_label
            // 
            this.path_label.Location = new System.Drawing.Point(7, 20);
            this.path_label.Name = "path_label";
            this.path_label.Size = new System.Drawing.Size(384, 62);
            this.path_label.TabIndex = 0;
            this.path_label.Text = "Game directory path:\r\n-";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.deletedata_button);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.deletealldata_button);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(397, 179);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datas";
            // 
            // backupdir_button
            // 
            this.backupdir_button.AutoSize = true;
            this.backupdir_button.Location = new System.Drawing.Point(12, 330);
            this.backupdir_button.Name = "backupdir_button";
            this.backupdir_button.Size = new System.Drawing.Size(137, 23);
            this.backupdir_button.TabIndex = 9;
            this.backupdir_button.Text = "Open Backup Directory";
            this.backupdir_button.UseVisualStyleBackColor = true;
            this.backupdir_button.Click += new System.EventHandler(this.backupdir_button_Click);
            // 
            // customdiropem_button
            // 
            this.customdiropem_button.AutoSize = true;
            this.customdiropem_button.Location = new System.Drawing.Point(55, 85);
            this.customdiropem_button.Name = "customdiropem_button";
            this.customdiropem_button.Size = new System.Drawing.Size(108, 23);
            this.customdiropem_button.TabIndex = 4;
            this.customdiropem_button.Text = "Open Directory";
            this.customdiropem_button.UseVisualStyleBackColor = true;
            this.customdiropem_button.Click += new System.EventHandler(this.customdiropem_button_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 365);
            this.Controls.Add(this.backupdir_button);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Ok_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button deletealldata_button;
        private System.Windows.Forms.Button deletedata_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Ok_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button originalpath_button;
        private System.Windows.Forms.Button custompath_button;
        private System.Windows.Forms.Label path_label;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button backupdir_button;
        private System.Windows.Forms.Button customdiropem_button;
    }
}