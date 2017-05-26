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
            this.listDownloads = new System.Windows.Forms.ListView();
            this.File = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Progress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
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
            this.listDownloads.Size = new System.Drawing.Size(552, 168);
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
            this.Date.Width = 95;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 285);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listDownloads);
            this.Name = "MainForm";
            this.Text = "Hotkey Downloader";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listDownloads;
        private System.Windows.Forms.ColumnHeader File;
        private System.Windows.Forms.ColumnHeader Progress;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.Button button1;
    }
}

