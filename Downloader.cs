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
    class Downloader
    {
        MainForm mainForm = null;

        public Downloader(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }

        public void Download(string url, string saveName)
        {
            WebClient webClient = new WebClient();

            try
            {
                DateTime localDate = DateTime.Now;

                ListViewItem item = new ListViewItem(saveName);
                item.SubItems.Add("0%");
                item.SubItems.Add(localDate.ToString());

                ListViewItem listItem = mainForm.listDownloads.Items.Add(item);

                webClient.DownloadProgressChanged += (object sender, DownloadProgressChangedEventArgs e) => {
                    string strPersents = e.ProgressPercentage.ToString() + "%";
                    listItem.SubItems[1].Text = strPersents;
                };

                System.Uri uri = new System.Uri(url);

                webClient.DownloadFileAsync(uri, saveName);

                mainForm.notifyIcon.ShowBalloonTip(3000, "New download", saveName, ToolTipIcon.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
