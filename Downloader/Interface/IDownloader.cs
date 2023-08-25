using Downloader.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader.Interface
{
    public interface IDownloader
    {
        public Task Download(FileInformation fileInformation );
    }
}
