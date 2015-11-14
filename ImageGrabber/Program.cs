using System;
using System.Net;
using IG.Core;

namespace ImageGrabber
{
    class Program
    {
        private static void Main(string[] args) {
            var options = new Options(args);

            using (var webClient = new WebClient()) {
                for (var i = 1; i < 100000000; i++) {
                    var filename = i + ".jpg";
                    var sourceFile = options.TargetUrlBase + filename;
                    var outFile = options.OutDirectory + filename;
                    try {
                        webClient.DownloadFile(new Uri(sourceFile), outFile);
                        Console.WriteLine("Downloaded {0} to {1}.", sourceFile, outFile);
                    }
                    catch (WebException w) {
                        Console.WriteLine("{0} does not exist.", sourceFile);
                    }
                }
            }


        }
    }
}
