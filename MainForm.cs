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

        string defaultSavePath = "W:\\";

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
