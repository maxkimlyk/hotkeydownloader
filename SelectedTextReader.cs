using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace HotkeyDownloader
{
    class SelectedTextReader
    {
        public static string GetStringFromClipboard()
        {
            string clipboardString;

            if (Clipboard.ContainsData(DataFormats.UnicodeText))
            {
                clipboardString = Clipboard.GetData(DataFormats.UnicodeText).ToString();
                return clipboardString;
            }

            return "";
        }

        public static string GetSelectedText()
        {
            string oldString = "";

            var clipboardData = Clipboard.GetData(DataFormats.UnicodeText);
            if (clipboardData != null)
            {
                oldString = clipboardData.ToString();
            }

            SendKeys.SendWait("^c");
            SendKeys.Flush();

            string newString = GetStringFromClipboard();

            if (oldString == newString)
            {
                newString = "";
            }

            Clipboard.SetData(DataFormats.UnicodeText, oldString);

            return newString;
        }
    }
}
