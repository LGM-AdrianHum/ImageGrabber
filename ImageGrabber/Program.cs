using System;
using System.Net;
using IG.Core;

namespace ImageGrabber {
    internal class Program {
        private static void Main(string[] args) {
            var options = new Options(args);

            using (var webClient = new WebClient()) {
                for (var i = 1; i < 5000; i++) {
                    var filename = i + ".jpg";
                    var sourceFile = options.TargetUrlBase + filename;
                    var outFile = options.OutDirectory + filename;
                    try {
                        webClient.DownloadFile(new Uri(sourceFile), outFile);
                        Console.WriteLine($"Downloaded {sourceFile} to {outFile}.");
                    }
                    catch (WebException w) {
                        Console.WriteLine($"{sourceFile} does not exist.");
                        if (w.Status == WebExceptionStatus.Timeout)
                        {
                            //Do Retry/Handling Sequence Here.
                        }
                    }
                }
            }
        }
    }
}
