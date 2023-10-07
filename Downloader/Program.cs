using Downloader.Enums;
using Downloader.Factories;
using Downloader.Functions;
using Downloader.Interfaces;
using Downloader.Objects;

do
{
    try
    {
        IDownloader downloader;
        string? inputData = string.Empty, fileSourceData;
        List<string> fileSourceList = new List<string>();
        List<FileInformation> fileInformationList = new List<FileInformation>();

        inputData = ConsoleHelper.ReadLine();
        fileSourceData = FileHelper.ReadFile(inputData);
        fileSourceList = fileSourceData.ToList("\r\n", "\r", "\n", ";");
        fileInformationList.AddRange(fileSourceList.Select(fileSource => new FileInformation(fileSource)));

        foreach (FileInformation fileInformation in fileInformationList)
        {
            try
            {
                downloader = DownloaderFactory.Create(fileInformation);

                await downloader.Download(fileInformation, ConsoleHelper.PercentageCallback, ConsoleHelper.SuccessCallback, ConsoleHelper.ErrorCallback);
            }
            catch (Exception exception)
            {
                exception.Message.WriteError(speed: WritingSpeed.UltraFast, moveNewLineAfterWriting: true);
            }
        }
    }
    catch (Exception exception)
    {
        exception.Message.WriteError(speed: WritingSpeed.UltraFast, moveNewLineAfterWriting: true);
    }

} while (ConsoleHelper.IsContinue());
