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
            Download(
                "https://psv4.userapi.com/c613824/u116484139/audios/d32e5eb628f1.mp3?extra=whDGzpzFl5P5lcp33cA2liSMeQStkC8aJ3bWLfQSuTQAuk8vxm6lYyDFIzTdBj9VOGuMGLd-26e-v9flgY6y6JZY4kKoHT_UMukuHcoYDv3LxUzmdUNuUCHpxy5o9RHVLyp-A-_S-mGJoA",
                "W:\\Save That Fire.mp3");
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

        string GetStringFromClipboard()
        {
            string clipboardString;

            if (Clipboard.ContainsData(DataFormats.Text))
            {
                clipboardString = Clipboard.GetData(DataFormats.Text) as string;
                return clipboardString;
            }

            return "";
        }

        void GetUrl()
        {
            string clipboardString = GetStringFromClipboard();
            url = clipboardString;

            // TODO: check whether clipboartString is URL
        }

        void StartDownload()
        {
            string clipboardString = GetStringFromClipboard();
            if (clipboardString == "")
                return;

            saveName = savePath + clipboardString;

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
