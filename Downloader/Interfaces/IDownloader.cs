using Downloader.Objects;

namespace Downloader.Interfaces
{
    public interface IDownloader
    {
        public Task Download(FileInformation fileInformation, Action<dynamic>? percentageCallbackDelegate = null, Action<dynamic>? successCallbackDelegate = null, Action<dynamic>? errorCallbackDelegate = null);
        public bool Validate(FileInformation fileInformation, out string message);
    }
}