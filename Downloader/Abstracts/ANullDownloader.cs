using Downloader.Constants;
using Downloader.Interfaces;
using Downloader.Objects;

namespace Downloader.Abstracts
{
    public abstract class ANullDownloader : INullDownloader
    {
        public virtual Task Download(FileInformation fileInformation, Action<dynamic>? percentageCallbackDelegate = null, Action<dynamic>? successCallbackDelegate = null, Action<dynamic>? errorCallbackDelegate = null) => throw new Exception(string.Format(ErrorConstant.DownloaderNotFound, fileInformation.URI));

        public bool Validate(FileInformation fileInformation, out string message) => throw new Exception(string.Format(ErrorConstant.DownloaderNotFound, fileInformation.URI));
    }
}