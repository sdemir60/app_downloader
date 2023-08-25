using Downloader.Interface;
using Downloader.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Downloader.Abstract
{
    public abstract class AHttpClientDownloader : IHttpClientDownloader
    {
        public virtual async Task Download(FileInformation fileInformation)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    byte[] bytes = await client.GetByteArrayAsync(fileInformation.URI);

                    File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads", bytes);
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //TODO SD: yazdırma dön ana sayfaya orada yazdır
            }
            
        }
    }
}


//TODO SD : heryere Task async eklendi hepsini kontrol et. recursive de yazabiliriz