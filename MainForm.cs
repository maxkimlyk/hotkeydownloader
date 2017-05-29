using System;
using System.Windows.Forms;

namespace HotkeyDownloader
{
    public partial class MainForm : Form
    {
        Hotkey startDownloadHotkey;

        public MainForm()
        {
            InitializeComponent();
            startDownloadHotkey = new Hotkey(this.Handle);
            startDownloadHotkey.Register(Hotkey.Modifiers.Ctrl, Keys.R);
        }

        ~MainForm()
        {
            startDownloadHotkey.Unregister();
        }

        void StartDownloadDialog()
        {
            string url = "";
            string saveName = (string)(Properties.Settings.Default["DefaultSavePath"]);
            string clipboardString = SelectedTextReader.GetStringFromClipboard();

            bool isUrl = URLParser.IsURL(clipboardString);
            string nameFromUrl = "";
            if (isUrl)
            {
                nameFromUrl = URLParser.GetFileName(clipboardString);
            }

            string selected = SelectedTextReader.GetSelectedText();
            if (selected != "")
            {
                saveName += selected;
                string extension = URLParser.GetExtension(clipboardString);
                if (extension != "")
                    saveName += "." + extension;
            }
            else if (nameFromUrl != "")
            {
                saveName += nameFromUrl;
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
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();
        }
    }
}
