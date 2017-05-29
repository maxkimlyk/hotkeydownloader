using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotkeyDownloader
{
    public partial class AddDownloadForm : Form
    {
        MainForm mainForm = null;

        public AddDownloadForm(string url, string saveName, MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            textBoxURL.Text = url;
            textBoxSaveName.Text = saveName;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Downloader downloader = new Downloader(mainForm);
            string url = textBoxURL.Text;
            string saveName = textBoxSaveName.Text;
            downloader.Download(url, saveName);
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            string currentPath = Path.GetDirectoryName(textBoxSaveName.Text);   
            string currentName = Path.GetFileName(textBoxSaveName.Text);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = currentPath;
            dialog.FileName = currentName;

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxSaveName.Text = dialog.FileName;
            }
        }
    }
}
