using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader
{
    class Program
    {
        private static readonly FileDownloadExecutor fileDownloadExecutor = new FileDownloadExecutor();
        private static readonly String yesAnswer = "y";
        private static readonly String noAnswer = "n";
        private static readonly String userInputMessage = "Do you want to download a file? y/n";

        static void Main(string[] args)
        {
            UserInput userInput;
            Console.WriteLine(userInputMessage);
            while ((userInput = UserInputAnalyze(Console.ReadLine())) != UserInput.No)
            {
                if (userInput == UserInput.Yes)
                {
                    fileDownloadExecutor.AddNewDownload(generateRandomString());
                }
                else if (userInput == UserInput.Unknown)
                {
                    Console.WriteLine("Please, input y or n");
                }
                Console.WriteLine(userInputMessage);
            }
            Console.WriteLine("Waiting for all downloads to be completed");
            while (!fileDownloadExecutor.isAllDownloadsCompleted()) { }
            Console.WriteLine("Downloads result listing:");
            foreach(var currentDownload in fileDownloadExecutor.Results)
            {
                Console.WriteLine(String.Format("Download id: {0} \nDownload result: {1}", currentDownload.Key, String.Join(" ", currentDownload.Value)));
            }
            Console.WriteLine("Ending of main thread");
            Console.ReadKey();
        }

        private static UserInput UserInputAnalyze(String userInput)
        {
            if(userInput == null)
            {
                return UserInput.Unknown;
            }
            else if (userInput == yesAnswer || userInput.ToLower() == yesAnswer)
            {
                return UserInput.Yes;
            }
            else if (userInput == noAnswer || userInput.ToLower() == noAnswer)
            {
                return UserInput.No;
            }
            else
            {
                return UserInput.Unknown;
            }
        }

        private enum UserInput
        {
            Yes, No, Unknown
        }

        private static String generateRandomString()
        {
            int stringLength = (new Random()).Next(1, 6);
            StringBuilder result = new StringBuilder();
            for (int currentSymbol = 0; currentSymbol < stringLength; currentSymbol++)
            {
                result.Append("a");
            }
            return result.ToString();
        }
    }
}
