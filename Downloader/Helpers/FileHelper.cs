using Downloader.Constants;
using System.Text;

namespace Downloader.Functions
{
    public static class FileHelper
    {
        public static string ReadFile(string source)
        {
            FileStream fileStream;
            string fileData;

            if (!string.IsNullOrEmpty(source) && RegexConstant.FilePath.IsMatch(source))
            {
                fileStream = new FileStream(source, FileMode.Open, FileAccess.Read);

                using (StreamReader streamReader = new(fileStream, Encoding.UTF8))
                {
                    fileData = streamReader.ReadToEnd();
                }
            }
            else
            {
                fileData = source ?? string.Empty;
            }

            return fileData;
        }
    }
}
