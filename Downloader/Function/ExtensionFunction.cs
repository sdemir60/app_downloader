using Downloader.Abstract;
using Downloader.Definition;
using Downloader.Interface;
using Downloader.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Downloader.Function
{
    public static class ExtensionFunction
    {
        public static void write(this string text, int duration = 50)
        {
            text.write(ConsoleColor.White, duration);
        }

        public static void write(this string text, ConsoleColor color, int duration = 50)
        {
            char[] characters;

            characters = text.ToArray();

            foreach (char character in characters)
            {
                Console.ForegroundColor = color;
                Console.Write(character);
                Thread.Sleep(duration);
            }

            Console.ResetColor();
        }

        public static void writeInfo(this string text, int duration = 50)
        {
            text.write(ConsoleColor.Green, duration);
        }

        public static void writeError(this string text, int duration = 50)
        {
            text.write(ConsoleColor.Red, duration);
        }

        public static void writeWarn(this string text, int duration = 50)
        {
            text.write(ConsoleColor.Yellow, duration);
        }

        public static void writeQuestion(this string text, int duration = 50)
        {
            text.write(ConsoleColor.Yellow, duration);
        }

        //TODO: Düzelt. Her metot extension oldu.

        public static string ReadFile(this string path)
        {
            FileStream fileStream;
            string fileData;

            fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                fileData = streamReader.ReadToEnd();
            }

            return fileData;
        }


        public static string GetSourceData(this string source)
        {
            string sourceData;

            if (!string.IsNullOrEmpty(source) && Constant.regexFilePath.IsMatch(source))
            {
                sourceData = source.ReadFile();
            }
            else { 
                sourceData = source; 
            }

            return sourceData;
        }

        public static FileInformation GetFileInformation(this string source)
        {
            string[] sourceInformation;
            FileInformation fileInformation;

            fileInformation = new FileInformation();

            if (!string.IsNullOrEmpty(source))
            {
                sourceInformation = source.Split(" ");

                fileInformation.URI = sourceInformation[0];
                fileInformation.Name = sourceInformation[1];
                fileInformation.Timeout = int.Parse(sourceInformation[2]);
            }

            return fileInformation;
        }

        public static IDownloader GetDownloader(this FileInformation fileInformation)
        {
            IDownloader? downloader = null;

            if (fileInformation!=null)
            {
                if (Constant.regexURL.IsMatch(fileInformation.URI))
                {
                    downloader = new HttpClientDownloader();
                }
            }
 
            return downloader;
        }
    }
}
