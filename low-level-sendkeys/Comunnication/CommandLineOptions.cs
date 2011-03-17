using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandLine;
using CommandLine.Text;

namespace low_level_sendkeys.Comunnication
{
    public sealed class CommandLineOptions
    {
        #region Standard Option Attribute
        [Option("s", "sendkeys", Required = false, HelpText = "Keys sequence to send.")]
        public string SendKeys = String.Empty;

        [Option(null, "close", HelpText = "Clone the alread running instance")]
        public bool CloseInstance=false;

        [Option(null, "nosocket", HelpText = "Do not start the socket server")]
        public bool NoSocket = false;

        [Option("l", "listkeys", HelpText = "List all avaliable keys")]
        public bool ListKeys = false;

        [Option(null, "quit", HelpText = "Do not keep application in memory. This option will run it in commandline mode, process and quit.")]
        public bool Quit = false;

        #endregion

        #region Specialized Option Attribute
        [ValueList(typeof(List<string>))]
        public IList<string> DefinitionFiles = null;

        //[OptionList("o", "operators", Separator=';',
        //    HelpText = "Operators included in processing (+;-;...).")]
        //[OptionList("o", "operators", Separator = ';',
        //    HelpText = "Operators included in processing (+;-;...)." +
        //    " Separate each operator with a semicolon." +
        //    " Do not include spaces between operators and separator.")]
        //public IList<string> AllowedOperators = null;

        [HelpOption(HelpText = "Dispaly this help screen.")]
        public string GetUsage()
        {
            var help = new HelpText(new HeadingInfo("low-level-sendkeys", "0.5b"));
            help.AdditionalNewLineAfterOption = true;
            help.Copyright = new CopyrightInfo("Teus", 2011);
            help.AddPreOptionsLine("This is free software. You may redistribute copies of it under the terms of");
            help.AddPreOptionsLine("the MIT License <http://www.opensource.org/licenses/mit-license.php>.");
            help.AddPreOptionsLine("Usage: SampleApp -rMyData.in -wMyData.out --calculate");
            help.AddPreOptionsLine(string.Format("       SampleApp -rMyData.in -i -j{0} file0.def file1.def", 9.7));
            help.AddPreOptionsLine("       SampleApp -rMath.xml -wReport.bin -o *;/;+;-");
            help.AddOptions(this);

            return help;
        }
        #endregion
    }
}
