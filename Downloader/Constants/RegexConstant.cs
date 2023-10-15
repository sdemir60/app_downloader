using System.Text.RegularExpressions;

namespace Downloader.Constants
{
    public static class RegexConstant
    {
        public static readonly Regex URL = new Regex("^https?:\\/\\/(?:www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{1,256}\\.[a-zA-Z0-9()]{1,6}\\b(?:[-a-zA-Z0-9()@:%_\\+.~#?&\\/=]*)$");
        public static readonly Regex FilePath = new Regex("^(?:[a-zA-Z]:|(\\\\\\\\|\\/\\/)[\\w\\.]+(\\\\|\\/)[\\w.$]+)((\\\\|\\/)|(\\\\\\\\|\\/\\/))(?:[\\w ]+(\\\\|\\/))*\\w([\\w. ])+[\\.][a-zA-Z]+$");
    }
}