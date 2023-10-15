using Downloader.Constants;
using Downloader.Interfaces;
using Downloader.Objects;

namespace Downloader.Abstracts
{
    public abstract class AHttpClientDownloader : IHttpClientDownloader
    {
        public virtual async Task Download(FileInformation fileInformation, Action<dynamic>? percentageCallbackDelegate = null, Action<dynamic>? successCallbackDelegate = null, Action<dynamic>? errorCallbackDelegate = null)
        {
            if (Validate(fileInformation, out string validationMessage))
            {
                Thread.Sleep(fileInformation.Timeout);

                using HttpClient client = new();
                using HttpResponseMessage response = await client.GetAsync(fileInformation.URI, HttpCompletionOption.ResponseHeadersRead);

                if (response.IsSuccessStatusCode)
                {
                    using Stream contentStream = await response.Content.ReadAsStreamAsync();
                    using FileStream fileStream = File.Create(string.Format("{0}\\Downloads\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), fileInformation.Name));

                    long totalBytes = response.Content.Headers.ContentLength ?? -1;
                    long bytesRead = 0;
                    byte[] buffer = new byte[8192];
                    bool isMoreToRead = true;
                    string emptyPercentage = "";

                    do
                    {
                        double percentage;
                        int bytesReadThisTime = await contentStream.ReadAsync(buffer, 0, buffer.Length);

                        if (bytesReadThisTime == 0)
                        {
                            isMoreToRead = false;
                            continue;
                        }

                        await fileStream.WriteAsync(buffer.AsMemory(0, bytesReadThisTime));

                        bytesRead += bytesReadThisTime;

                        if (totalBytes > 0)
                        {
                            percentage = ((double)bytesRead / totalBytes) * 100;
                            percentageCallbackDelegate?.Invoke(percentage);
                        }
                        else
                        {
                            emptyPercentage = emptyPercentage.Length <= 3 ? string.Format("{0}.", emptyPercentage) : ".";
                            percentageCallbackDelegate?.Invoke(emptyPercentage);
                        }
                    }
                    while (isMoreToRead);

                    successCallbackDelegate?.Invoke(InfoConstant.DownloadCompleted);
                }
                else
                {
                    errorCallbackDelegate?.Invoke($"HTTP hatası: {response.StatusCode}");
                }
            }
            else
            {
                errorCallbackDelegate?.Invoke(validationMessage);
            }
        }

        public bool Validate(FileInformation fileInformation, out string message)
        {
            bool valid = true;

            message = InfoConstant.ValidFile;

            if (string.IsNullOrEmpty(fileInformation.URI))
            {
                valid = false;
                message = ErrorConstant.AddressNotFound;
            }
            else if (string.IsNullOrEmpty(fileInformation.Name))
            {
                valid = false;
                message = ErrorConstant.FileNameNotFound;
            }

            return valid;
        }
    }
}