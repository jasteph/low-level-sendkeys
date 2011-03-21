using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using low_level_sendkeys.KernelHotkey;
using System.Threading;
using low_level_sendkeys.Keys;
using low_level_sendkeys.Comunnication;
using low_level_sendkeys.Macros;

namespace low_level_sendkeys
{
    public static class SendRawKeys
    {
        static KeyboardManager keyboardManager = new KeyboardManager();

        private static readonly object LockSendKeys = new object();
        private static bool _executingCommands = false;
        private static int _interval = 5;
        public static void StartService()
        {
            string result = ConfigurationManager.AppSettings["MakeCodesInterval"];
            if (string.IsNullOrEmpty(result) || !int.TryParse(result, out _interval))
            {
                _interval = 5;
            }
            keyboardManager.ListenKeyBoard();
        }
        public static void StopService()
        {
            keyboardManager.StopListenKeyBoard();
        }

        public static string SendMacro(string macroName)
        {
            return SendMacro(macroName, true);
        }
        public static string SendMacro(string macroName, bool waitFinish)
        {
            var macro = MacroManager.Macros.SingleOrDefault(m => m.Name.Equals(macroName, StringComparison.InvariantCultureIgnoreCase));
            if (macro == null)
            {
                return CommunicationBridge.ResponseError + string.Format(" Macro '{0}' does not exist.", macroName);
            }

            return SendKeys(macro.MacroCommand, waitFinish);
        }

        public static string SendKeys(string commands)
        {
            return SendKeys(commands, true);
        }
        public static string SendKeys(string commands, bool waitFinish)
        {
            const string sendKeysErrorPrefix = CommunicationBridge.ResponseError + "SendKeys not executed. Reason: ";
            if (string.IsNullOrEmpty(commands))
            {

                return sendKeysErrorPrefix + "No command was informed.";
            }

            int startIndex = 0;
            int kbdIndex = 0;
            var executeCommands = new List<IExecuteCommand>();

            var stringCommands = commands.Split(',');
            if (int.TryParse(stringCommands[0], out kbdIndex))
            {
                if (kbdIndex <= 9)
                {
                    startIndex = 1;
                }
                else
                {
                    kbdIndex = KeyboardManager.FirstActiveKeyboard;
                }
            }
            else
            {
                kbdIndex = KeyboardManager.FirstActiveKeyboard;
            }

            for (int i = startIndex; i < stringCommands.Length; i++)
            {
                int numericValue;
                string textValue = stringCommands[i];

                if (int.TryParse(textValue, out numericValue))
                {
                    executeCommands.Add(new WaitTime(numericValue));
                }
                else
                {
                    string keyName = textValue;
                    bool sendDown = true;
                    bool sendUp = true;

                    if (textValue.Length > 1 && textValue.StartsWith("+"))
                    {
                        keyName = textValue.Substring(1);
                        sendUp = false;
                    }
                    if (textValue.Length > 1 && textValue.StartsWith("-"))
                    {
                        keyName = textValue.Substring(1);
                        sendDown = false;
                    }

                    var currentKey = KeyManager.Keys.SingleOrDefault(k => k.Name.Equals(keyName, StringComparison.InvariantCultureIgnoreCase));
                    if (currentKey == null)
                    {

                        return sendKeysErrorPrefix + string.Format(" The command '{0}' does not exist.", keyName);
                    }

                    if (sendDown)
                    {
                        executeCommands.AddRange(currentKey.KeyDownStrokes.Select(keyDownStroke => new SendMakeCommand(keyDownStroke, keyboardManager, kbdIndex)).Cast<IExecuteCommand>());
                    }

                    if (sendUp)
                    {
                        executeCommands.AddRange(currentKey.KeyUpStrokes.Select(keyUpStroke => new SendMakeCommand(keyUpStroke, keyboardManager, kbdIndex)).Cast<IExecuteCommand>());
                    }
                }
            }

            lock (LockSendKeys)
            {
                Debug.WriteLine("ENTROU");
                var threadExecute = new Thread(
                  delegate()
                  {
                      while (_executingCommands)
                      {
                          Thread.Sleep(100);
                      }
                      _executingCommands = true;
                      foreach (IExecuteCommand executeCommand in executeCommands)
                      {
                          executeCommand.Execute();
                          Thread.Sleep(_interval);
                      }
                      _executingCommands = false;
                  });

                threadExecute.Start();
                if (waitFinish) threadExecute.Join();
            }

            return CommunicationBridge.ResponseOk;
        }



        private interface IExecuteCommand
        {
            void Execute();
        }
        private class SendMakeCommand : IExecuteCommand
        {
            private readonly KeyStroke _keyStroke;
            private readonly KeyboardManager _keyboardManager;
            private readonly int _keyboardNumber;

            internal SendMakeCommand(KeyStroke keyStroke, KeyboardManager keyboardManager, int keyboardNumber)
            {
                _keyStroke = keyStroke;
                _keyboardManager = keyboardManager;
                _keyboardNumber = keyboardNumber;
            }

            public void Execute()
            {
                _keyboardManager.SendKeystroke(_keyStroke, _keyboardNumber);
            }
        }
        private class WaitTime : IExecuteCommand
        {
            private readonly int _timeout;

            internal WaitTime(int timeout)
            {
                _timeout = timeout;
            }

            public void Execute()
            {
                Thread.Sleep(_timeout);
            }
        }
    }
}
