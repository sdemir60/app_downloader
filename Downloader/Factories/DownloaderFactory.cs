using Downloader.Constants;
using Downloader.Interfaces;
using Downloader.Objects;

namespace Downloader.Factories
{
    public static class DownloaderFactory
    {
        public static IDownloader Create(this FileInformation fileInformation)
        {
            IDownloader downloader = new NullDownloader();

            if (fileInformation != null && RegexConstant.URL.IsMatch(fileInformation.URI))
            {
                downloader = new HttpClientDownloader();
            }

            return downloader;
        }
    }
}
