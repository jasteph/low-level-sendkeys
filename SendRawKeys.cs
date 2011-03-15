using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using low_level_sendkeys.KernelHotkey;
using System.Threading;
using low_level_sendkeys.Keys;

namespace low_level_sendkeys
{
    public static class SendRawKeys
    {

        public static bool SendCommands(string commands)
        {
            if (string.IsNullOrEmpty(commands)) return false;

            KeyboardManager keyboardManager = new KeyboardManager();

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
                    kbdIndex = 0;
                }
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

                    if (textValue.EndsWith("_DOWN", StringComparison.InvariantCultureIgnoreCase))
                    {
                        keyName = textValue.Substring(0, textValue.Length - 5);
                        sendUp = false;
                    }
                    if (textValue.EndsWith("_UP", StringComparison.InvariantCultureIgnoreCase))
                    {
                        keyName = textValue.Substring(0, textValue.Length - 3);
                        sendDown = false;
                    }

                    var currentKey = KeyManager.Keys.SingleOrDefault(k => k.Name.Equals(keyName, StringComparison.InvariantCultureIgnoreCase));
                    if (currentKey == null) return false;

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

            keyboardManager.ListenKeyBoard();
            while (!keyboardManager.KeyboardListening)
            {
                
            }

            foreach (IExecuteCommand executeCommand in executeCommands)
            {
                executeCommand.Execute();
                Thread.Sleep(50);
            }
            keyboardManager.StopListenKeyBoard();


            return true;
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
