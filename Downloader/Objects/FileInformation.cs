using Downloader.Functions;
using System.Net;
using System.Text.RegularExpressions;

namespace Downloader.Objects
{
    public class FileInformation
    {
        public FileInformation(string uri, string name) => (URI, Name, Timeout) = (uri, name, 0);
        public FileInformation(string uri, string name, int timeout) => (URI, Name, Timeout) = (uri, name, timeout);
        public FileInformation(string source) => Source = source;

        public string Source
        {
            get => String.Format("{0} {1} {2}", URI, Name, Timeout);
            set
            {
                string sourceValue;
                string urlToEncode;
                List<string> fileProperties;

                sourceValue = value;

                if (!string.IsNullOrEmpty(sourceValue))
                {
                    if (sourceValue.Contains("{{"))
                    {
                        urlToEncode = sourceValue.Substring(sourceValue.IndexOf("{{"), sourceValue.IndexOf("}}") - sourceValue.IndexOf("{{") + 2);
                        sourceValue = sourceValue.Replace(urlToEncode, WebUtility.UrlEncode(urlToEncode));
                    }

                    fileProperties = Regex.Replace(sourceValue, @"\s+", " ").Split(" ").ToList();

                    URI = fileProperties.GetItem<string>(0, string.Empty);
                    Name = fileProperties.GetItem<string>(1, string.Empty);
                    Timeout = fileProperties.GetItem<int>(2, 0);
                }
            }
        }

        public string URI { get; set; } = string.Empty;
        public string Name { get; set; } = String.Empty;
        public int Timeout { get; set; } = 0;
    }
}
