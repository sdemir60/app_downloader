using Downloader.Constants;
using Downloader.Factories;
using Downloader.Functions;
using Downloader.Interfaces;
using Downloader.Objects;

namespace Downloader.UnitTest
{
    public class HttpClientDownloaderTests
    {
        string standartURI, uriToEncode;

        [SetUp]
        public void Setup()
        {
            standartURI = "https://freetestdata.com/wp-content/uploads/2021/09/Free_Test_Data_100KB_MP3.mp3";
            uriToEncode = "https://texttospeech.responsivevoice.org/v1/text:synthesize?text={{ses deneme 1 2 3}}&lang=tr&engine=g3&name=&pitch=0.5&rate=0.55&volume=1&key=vfjuY3PM&gender=male";
        }

        [Test]
        public async Task Download_StandartURI_Success()
        {
            IDownloader downloader;
            FileInformation fileInformation;

            fileInformation = new($"{standartURI} Free_Test_Data_100KB_MP3.mp3 3000");
            downloader = DownloaderFactory.Create(fileInformation);

            await downloader.Download(fileInformation, successCallbackDelegate: (message) => { Assert.AreEqual(InfoConstant.DownloadCompleted, message); });
        }

        [Test]
        public async Task Download_URItoEncode_Success()
        {
            IDownloader downloader;
            FileInformation fileInformation;

            fileInformation = new($"{uriToEncode} Ses_Deneme_1_2_3.mp3 5000");
            downloader = DownloaderFactory.Create(fileInformation);

            await downloader.Download(fileInformation, successCallbackDelegate: (message) => { Assert.AreEqual(InfoConstant.DownloadCompleted, message); });
        }
    }
}