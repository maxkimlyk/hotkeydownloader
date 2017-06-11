using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotkeyDownloader
{
    public partial class AddDownloadForm : Form
    {
        MainForm mainForm = null;

        private int ExtensionPos(string filename)
        {
            int lastPointPos = filename.LastIndexOf(".");
            if (filename.Length - lastPointPos < 5)
                return lastPointPos;
            return -1;
        }

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public AddDownloadForm(string url, string saveName, MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            textBoxURL.Text = url;
            textBoxSavePath.Text = (string)(Properties.Settings.Default["DefaultSavePath"]);
            textBoxSaveName.Text = saveName;

            int saveNameExtensionPos = ExtensionPos(saveName);
            if (saveNameExtensionPos > 0)
            {
                textBoxSaveName.SelectionStart = 0;
                textBoxSaveName.SelectionLength = saveNameExtensionPos;
            }

            SetForegroundWindow(this.Handle);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Downloader downloader = new Downloader(mainForm);
            string url = textBoxURL.Text;

            string fullSavePath = textBoxSavePath.Text;
            if (!fullSavePath.EndsWith(@"\"))
                fullSavePath = fullSavePath.Insert(fullSavePath.Length, @"\");
            string saveName = fullSavePath + textBoxSaveName.Text;

            downloader.Download(url, saveName);
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            string currentPath = Path.GetDirectoryName(textBoxSavePath.Text);   
            string currentName = Path.GetFileName(textBoxSavePath.Text);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = currentPath;
            dialog.FileName = currentName;

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxSavePath.Text = dialog.FileName;
            }
        }
    }
}
