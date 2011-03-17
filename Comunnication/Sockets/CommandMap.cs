using System;
using System.Collections;

namespace low_level_sendkeys.Comunnication.Sockets
{
    public class CommandMap
    {
        public enum Commands
        {
            None,
            Sendkeys,
            Loadfile,
            RemapKey,
            UnloadApplication,
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
            CommandsMap["SENDKEYS"] = Commands.Sendkeys;
            CommandsMap["LOADFILE"] = Commands.Loadfile;
            CommandsMap["REMAPKEY"] = Commands.RemapKey;
            CommandsMap["UNLOADAPPLICATION"] = Commands.UnloadApplication;
            CommandsMap["QUIT"] = Commands.Quit;
            CommandsMap["HELP"] = Commands.Help;
            CommandsMap["?"] = Commands.Help;
        }

    }
}