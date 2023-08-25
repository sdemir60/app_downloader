using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader.Object
{
    public class FileInformation
    {
        public string Name { get; set; }
        public string URI { get; set; }
        public int Timeout { get; set; }
    }
}

//TODO SD: Timeout burada olmayabilir. Obje kalıtılabilir. Farklı indirme türleri içinde kalıtım kullanılabilir.