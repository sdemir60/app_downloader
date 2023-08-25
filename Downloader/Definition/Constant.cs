using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Downloader.Definition
{
    public class Constant
    {
        public static readonly Regex regexFilePath = new Regex("\t\r\n^([a-zA-Z]\\:|\\\\\\\\[^\\/\\\\:*?\"<>|]+\\\\[^\\/\\\\:*?\"<>|]+)(\\\\[^\\/\\\\:*?\"<>|]+)+(\\.[^\\/\\\\:*?\"<>|]+)$");
        public static readonly Regex regexURL = new Regex("^https?:\\/\\/(?:www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{1,256}\\.[a-zA-Z0-9()]{1,6}\\b(?:[-a-zA-Z0-9()@:%_\\+.~#?&\\/=]*)$");
    }
}
