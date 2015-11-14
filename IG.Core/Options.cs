using System;
using System.Collections.Generic;
using System.Linq;
using NDesk.Options;

namespace IG.Core {
    public class Options {
        public string TargetUrlBase { get; set; }
        public string OutDirectory { get; set; }
        private bool ShowHelp { get; set; }
        private OptionSet OurOptions { get; set; }

        public Options(IEnumerable<string> args) {
            Process(args);
            TargetUrlBase = EnsureSuffix(TargetUrlBase, OptionEnum.Url);
            OutDirectory = EnsureSuffix(OutDirectory, OptionEnum.DirectoryPath);
        }

        private static string EnsureSuffix(string input, OptionEnum type) {
            switch (type) {
                case OptionEnum.Url:
                    if (!input.EndsWith("/")) {
                        input = input + "/";
                    }
                    break;
                case OptionEnum.DirectoryPath:
                    if (!input.EndsWith(@"\")) {
                        input = input + @"\";
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("type", type, null);
            }
            return input;
        }

        private void Process(IEnumerable<string> args) {
            OurOptions = new OptionSet {
                {"h|help", "show this message and exit", v => ShowHelp = v != null}, {"t|target=", "the target url", t => TargetUrlBase = t}, {"o|outdirectory=", "directory to output files to", o => OutDirectory = o}
            };

            OurOptions.Parse(args);
            if (!args.Any() || args.Count() < 2 || ShowHelp) {
                OurOptions.WriteOptionDescriptions(Console.Out);
            }
        }
    }
}