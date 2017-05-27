using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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
            string extension = "";

            int questPos = url.LastIndexOf('?');
            if (questPos > 0)
            {
                url = url.Substring(0, questPos);
            }
            int pointPos = url.LastIndexOf('.');
            int extLength = url.Length - pointPos - 1;
            if (extLength > 0 && extLength <= 5)
                extension = url.Substring(pointPos + 1, extLength);

            return extension;
        }
    }
}
