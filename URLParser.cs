using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace HotkeyDownloader
{
    class URLParser
    {
        public static bool IsURL(string text)
        {
            string pattern = @"((([A-Za-z]{3,9}:(?:\/\/)?)(?:[\-;:&=\+\$,\w]+@)?[A-Za-z0-9\.\-]+|(?:www\.|[\-;:&=\+\$,\w]+@)[A-Za-z0-9\.\-]+)((?:\/[\+~%\/\.\w\-_]*)?\??(?:[\-\+=&;%@\.\w_]*)#?(?:[\.\!\/\\\w]*))?)";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(text);
        }

        public static string GetExtension(string url)
        {
            try
            {
                string extension = "";

                Uri uri = new Uri(url);
                if (Path.HasExtension(uri.AbsoluteUri))
                {
                    extension = Path.GetExtension(uri.AbsolutePath);
                }

                extension = extension.Replace(".", "");

                return extension;
            }
            catch
            {
                return "";
            }
        }

        public static string GetFileName(string url)
        {
            Uri uri = new Uri(url);
            return Path.GetFileName(uri.AbsolutePath);
        }
    }
}
