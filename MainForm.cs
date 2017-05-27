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
        Hotkey getURLHotkey;
        Hotkey startDownloadHotkey;

        string defaultSavePath = "W:\\";

        public MainForm()
        {
            InitializeComponent();

            getURLHotkey = new Hotkey(this.Handle);
            startDownloadHotkey = new Hotkey(this.Handle);
            getURLHotkey.Register(Hotkey.Modifiers.Ctrl, Keys.T);
            startDownloadHotkey.Register(Hotkey.Modifiers.Ctrl, Keys.R);
        }

        ~MainForm()
        {
            getURLHotkey.Unregister();
            startDownloadHotkey.Unregister();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        void StartDownloadDialog()
        {
            string url = "";
            string saveName = defaultSavePath;

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
    }
}
