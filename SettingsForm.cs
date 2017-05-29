using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotkeyDownloader
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SaveSettings()
        {
            if (!textBoxDefaultSavePath.Text.EndsWith(@"\"))
                textBoxDefaultSavePath.AppendText(@"\");

            Properties.Settings.Default["DefaultSavePath"] = textBoxDefaultSavePath.Text;
            Properties.Settings.Default.Save();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            textBoxDefaultSavePath.Text = (string)(Properties.Settings.Default["DefaultSavePath"]);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxDefaultSavePath.Text = dialog.SelectedPath;
            }
        }
    }
}
