using System;
using System.Collections;
using System.IO;
using System.Net.Sockets;

namespace low_level_sendkeys.Comunnication.Sockets
{
    public class SocketCommandsStream
    {
        private readonly TextReader _sockerReader;
        private readonly TextWriter _socketWriter;
        private readonly BitArray _commandRun;

        public SocketCommandsStream(TextReader reader, TextWriter writer)
        {
            _sockerReader = reader;
            _socketWriter = writer;
            _commandRun = new BitArray((int)CommandMap.Commands.Help + 1);
            _commandRun.SetAll(false);
        }


        protected string DispatchCommand(CommandMap.Commands command, string parameters)
        {
            switch (command)
            {
                case CommandMap.Commands.None:
                    break;
                case CommandMap.Commands.Sendkeys:
                    return CommunicationBridge.SendKeys(GetParams(parameters, ' ', 1)[0]);
                case CommandMap.Commands.Loadfile:
                    break;
                case CommandMap.Commands.RemapKey:
                    break;
                case CommandMap.Commands.UnloadApplication:
                    var resp = CommunicationBridge.UnloadApplication();
                    if (resp == CommunicationBridge.ResponseOk)
                    {
                        _socketWriter.WriteLine(resp);
                        _socketWriter.Flush();
                        throw new EndOfStreamException();
                    }
                    return resp;
                case CommandMap.Commands.Quit:
                    _socketWriter.WriteLine(CommunicationBridge.ResponseOk);
                    _socketWriter.Flush();
                    throw new EndOfStreamException();
                case CommandMap.Commands.Help:
                    ShowHelp();
                    return CommunicationBridge.ResponseOk;
                case CommandMap.Commands.ListKeys:
                    return CommunicationBridge.ListKeys();

            }

            return (CommunicationBridge.ResponseError + " Invalid Command.");
        }

        public void ShowHelp()
        {
            _socketWriter.WriteLine("LISTKEYS");
            _socketWriter.WriteLine("SENDKEYS");
            _socketWriter.WriteLine("LOADFILE");
            _socketWriter.WriteLine("REMAPKEY");
            _socketWriter.WriteLine("UNLOADAPPLICATION");
            _socketWriter.WriteLine("QUIT");
            _socketWriter.WriteLine("HELP");
            _socketWriter.WriteLine("?");
            _socketWriter.WriteLine();
        }

        #region SupportCommands

        public void ListenCommands()
        {
            try
            {
                string sComando;
                while (true)
                {
                    try
                    {
                        do
                        {
                            sComando = _sockerReader.ReadLine();
                            if (sComando == null)
                            {
                                throw new EndOfStreamException();
                            }

                            sComando = sComando.Trim();

                        } while (sComando.Length == 0);

                        string[] aTokens = sComando.Split(' ');

                        CommandMap.Commands command = CommandMap.FindCommand(aTokens[0]);
                        if (command == CommandMap.Commands.None)
                        {
                            throw new ArgumentException(string.Format("Unknow Command: {0}", aTokens[0]));
                        }

                        string resp = DispatchCommand(command, String.Join(" ", aTokens, 1, aTokens.Length - 1));
                        _socketWriter.WriteLine(resp);
                    }
                    catch (ArgumentException ex)
                    {
                        _socketWriter.WriteLine(ex.Message);
                    }
                    catch (EndOfStreamException)
                    {
                        _socketWriter.Flush();
                        throw;
                    }
                    catch (IOException ex)
                    {
                        if (ex.InnerException is SocketException)
                        {
                            throw new EndOfStreamException();
                        }
                    }
                    catch (Exception ex)
                    {
                        _socketWriter.WriteLine(CommunicationBridge.ResponseError + " Unknow Error: " + ex.Message);
                    }
                    _socketWriter.Flush();
                }
            }
            catch (EndOfStreamException)
            {
            }
            catch (SocketException)
            {
            }
        }

        protected string GetUntilLineEmpty()
        {
            using (var sw = new StringWriter())
            {
                string sLinha = _sockerReader.ReadLine();
                while (!string.IsNullOrEmpty(sLinha))
                {
                    sw.WriteLine(sLinha);
                    sLinha = _sockerReader.ReadLine();
                }
                return sw.ToString();
            }
        }

        protected string[] GetParams(string parameterString, char delimiter, int requiredParams)
        {
            string[] asRet = parameterString.Split(delimiter);
            if (asRet.Length < requiredParams)
                throw new ArgumentException("Missing Parameters");
            return asRet;
        }

        #endregion
    }
}