using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader
{
    class FileDownloadExecutor
    {
        private static readonly FileDownloader fileDownloader = new FileDownloader();
        private Dictionary<int, byte[]> results = new Dictionary<int,byte[]>();
        private Task<byte[]> currentTask;

        public Dictionary<int,byte[]> Results
        {
            private set { }
            get { return results; }
        }

        public void AddNewDownload(String url)
        {
            if (currentTask == null)
            {
                currentTask = Task<byte[]>.Factory.StartNew(() => (fileDownloader.Download(url)));
            }
            else
            {
                currentTask = currentTask.ContinueWith(
                    (previousTask) => 
                    { 
                        results.Add(previousTask.Id, previousTask.Result); 
                        return fileDownloader.Download(url); 
                    });
            }
        }

        public Boolean isAllDownloadsCompleted()
        {
            return currentTask.IsCompleted;
        }
    }
}
