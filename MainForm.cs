using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace HotkeyDownloader
{
    public partial class MainForm : Form
    {
        Hotkey startDownloadHotkey;
        Settings settings;

        string defaultSavePath = "W:\\";

        public MainForm()
        {
            InitializeComponent();
            startDownloadHotkey = new Hotkey(this.Handle);
            startDownloadHotkey.Register(Hotkey.Modifiers.Ctrl, Keys.R);
            settings = new Settings();
        }

        ~MainForm()
        {
            startDownloadHotkey.Unregister();
        }

        void StartDownloadDialog()
        {
            string url = "";
            string saveName = settings.DefaultSavePath;

            string clipboardString = SelectedTextReader.GetStringFromClipboard();

            if (URLParser.IsURL(clipboardString))
            {
                url = clipboardString;
            }

            string selected = SelectedTextReader.GetSelectedText();
            if (selected != "")
            {
                saveName += selected;
                string extension = URLParser.GetExtension(url) ;
                if (extension != "")
                    saveName += "." + extension;
            }
            
            AddDownloadForm addDownloadForm = new AddDownloadForm(url, saveName, this);
            addDownloadForm.Show();
        }

        protected override void WndProc(ref Message m)
        {
            if (startDownloadHotkey != null && startDownloadHotkey.IsPressed(ref m))
                StartDownloadDialog();

            base.WndProc(ref m);
        }

        private void buttonAddDownload_Click(object sender, EventArgs e)
        {
            StartDownloadDialog();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(settings);
            settingsForm.Show();
        }
    }
}
