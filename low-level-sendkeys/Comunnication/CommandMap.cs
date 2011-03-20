using System;
using System.Collections;
using System.Text;

namespace low_level_sendkeys.Comunnication
{
    public class CommandMap
    {
        public enum Commands
        {
            None,
            ListKeys,
            Sendkeys,
            ListMacros,
            SendMacro,
            Loadfile,
            RemapKey,
            UnloadApplication,
            SendToTray,
            RestoreWindow,
            StartSocketServer,
            StopSocketServer,
            Quit,
            Help // Tem que ser sempre o maior valor do enum !!!
        };

        protected static Hashtable CommandsMap;

        public static Commands FindCommand(string token)
        {
            token = token.ToUpper();
            Object o = CommandsMap[token];
            if (o == null)
            {
                return Commands.None;
            }
            return (Commands)o;
        }

        static CommandMap()
        {
            CommandsMap = Hashtable.Synchronized(new Hashtable());
            CommandsMap["LISTKEYS"] = Commands.ListKeys;
            CommandsMap["SENDKEYS"] = Commands.Sendkeys;
            CommandsMap["LISTMACROS"] = Commands.ListMacros;
            CommandsMap["SENDMACRO"] = Commands.SendMacro;
            CommandsMap["LOADFILE"] = Commands.Loadfile;
            CommandsMap["REMAPKEY"] = Commands.RemapKey;
            CommandsMap["UNLOADAPPLICATION"] = Commands.UnloadApplication;
            CommandsMap["SENDTOTRAY"] = Commands.SendToTray;
            CommandsMap["RESTOREWINDOW"] = Commands.RestoreWindow;
            CommandsMap["STARTSOCKETSERVER"] = Commands.StartSocketServer;
            CommandsMap["STOPSOCKETSERVER"] = Commands.StopSocketServer;
            CommandsMap["QUIT"] = Commands.Quit;
            CommandsMap["HELP"] = Commands.Help;
            CommandsMap["?"] = Commands.Help;
        }

        public static string ListCommands()
        {
            var sb = new StringBuilder();
            foreach (DictionaryEntry entry in CommandsMap)
            {
                sb.AppendLine(entry.Key.ToString());
            }

            return sb.ToString();
        }

    }
}