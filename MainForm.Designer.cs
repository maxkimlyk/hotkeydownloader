namespace HotkeyDownloader
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listDownloads = new System.Windows.Forms.ListView();
            this.File = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Progress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.buttonAddDownload = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listDownloads
            // 
            this.listDownloads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.File,
            this.Progress,
            this.Date});
            this.listDownloads.GridLines = true;
            this.listDownloads.Location = new System.Drawing.Point(12, 12);
            this.listDownloads.MultiSelect = false;
            this.listDownloads.Name = "listDownloads";
            this.listDownloads.Size = new System.Drawing.Size(552, 232);
            this.listDownloads.TabIndex = 1;
            this.listDownloads.UseCompatibleStateImageBehavior = false;
            this.listDownloads.View = System.Windows.Forms.View.Details;
            // 
            // File
            // 
            this.File.Text = "File";
            this.File.Width = 254;
            // 
            // Progress
            // 
            this.Progress.Text = "Progress";
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.Width = 169;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.Visible = true;
            // 
            // buttonAddDownload
            // 
            this.buttonAddDownload.Location = new System.Drawing.Point(12, 250);
            this.buttonAddDownload.Name = "buttonAddDownload";
            this.buttonAddDownload.Size = new System.Drawing.Size(119, 23);
            this.buttonAddDownload.TabIndex = 2;
            this.buttonAddDownload.Text = "Add Download";
            this.buttonAddDownload.UseVisualStyleBackColor = true;
            this.buttonAddDownload.Click += new System.EventHandler(this.buttonAddDownload_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Location = new System.Drawing.Point(489, 250);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(75, 23);
            this.buttonSettings.TabIndex = 3;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 281);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonAddDownload);
            this.Controls.Add(this.listDownloads);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Hotkey Downloader";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader File;
        private System.Windows.Forms.ColumnHeader Progress;
        private System.Windows.Forms.ColumnHeader Date;
        public System.Windows.Forms.ListView listDownloads;
        public System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button buttonAddDownload;
        private System.Windows.Forms.Button buttonSettings;
    }
}

