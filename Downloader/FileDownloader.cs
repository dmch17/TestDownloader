using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Downloader
{
    class FileDownloader
    {
        private static readonly int singleStep = 3000;

        public byte[] Download(string url)
        {
            List<byte> result = new List<byte>();
            Random randomizer = new Random();
            for (int currentByte = randomizer.Next(1, 6); currentByte > 0; currentByte--)
            {
                result.Add((Byte)randomizer.Next(Byte.MinValue, Byte.MaxValue));
            }
            Console.WriteLine(String.Format("Download {0} starts", Task.CurrentId));
            Thread.Sleep(url.Length * FileDownloader.singleStep);
            Console.WriteLine(String.Format("Download {0} ends", Task.CurrentId));
            return result.ToArray<byte>();
        }
    }
}
