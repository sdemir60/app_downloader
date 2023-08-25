using Downloader.Definition;
using Downloader.Function;
using Downloader.Interface;
using Downloader.Object;


string sourceData;
List<string> sourceList;
IDownloader downloader;
List<FileInformation> fileInformationList;

fileInformationList = new List<FileInformation>();

sourceData = Console.ReadLine().GetSourceData();
sourceList = sourceData.Split(';').ToList();

foreach (string source in sourceList)
{
    fileInformationList.Add(source.GetFileInformation());
}


foreach (FileInformation fileInformation in fileInformationList)
{
    downloader = fileInformation.GetDownloader();

    if (downloader != null)
        await downloader.Download(fileInformation);
}


Console.ReadLine();



// TODO SD: trycache
// TODO SD: proje klasör yapısı
// TODO SD: https://www.gencayyildiz.com/blog/c-factory-method-design-patternfactory-method-tasarim-deseni/ 