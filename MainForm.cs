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

        string url = "";
        string saveName = "";
        string savePath = "W:\\";

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
            notifyIcon.ShowBalloonTip(3000, "Download", "To " + saveName, ToolTipIcon.None);
        }

        private void Download(string url, string saveName)
        {
            WebClient webClient = new WebClient();

            try
            {
                DateTime localDate = DateTime.Now;

                ListViewItem item = new ListViewItem(saveName);
                item.SubItems.Add("0%");
                item.SubItems.Add(localDate.ToString());

                ListViewItem listItem = listDownloads.Items.Add(item);

                webClient.DownloadProgressChanged += (object sender, DownloadProgressChangedEventArgs e) => {
                    string strPersents = e.ProgressPercentage.ToString() + "%";
                    listItem.SubItems[1].Text = strPersents;
                };

                System.Uri uri = new System.Uri(url);

                webClient.DownloadFileAsync(uri, saveName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void GetUrl()
        {
            string clipboardString = SelectedTextReader.GetStringFromClipboard();
            url = clipboardString;

            if (URLParser.IsURL(url))
            {
                // do nothing
            }
        }

        void StartDownload()
        {
            GetUrl();

            string name = SelectedTextReader.GetSelectedText();
            if (name == "")
                return;

            saveName = savePath + name;
            string extension = URLParser.GetExtension(url);
            if (extension.Length > 0)
                saveName += "." + extension;

            notifyIcon.ShowBalloonTip(3000, "Download", "To " + saveName, ToolTipIcon.None);

            Download(url, saveName);
        }

        protected override void WndProc(ref Message m)
        {
            if (getURLHotkey != null && getURLHotkey.IsPressed(ref m))
                GetUrl();

            if (startDownloadHotkey != null && startDownloadHotkey.IsPressed(ref m))
                StartDownload();

            base.WndProc(ref m);
        }
    }
}
