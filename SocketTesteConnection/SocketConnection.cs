using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace SocketTesteConnection
{
    public class SocketConnection
    {
        private readonly string _servidor;
        private readonly int _port;

        private NetworkStream _netStream;
        private TcpClient _clienteTcp;
        private StreamWriter _streamWriter;
        private StreamReader _streamReader;

        public SocketConnection(string servidor, int port)
        {
            this._servidor = servidor;
            _port = port;
        }

        public bool Connect()
        {
            _clienteTcp = new TcpClient(_servidor, _port);
            _clienteTcp.ReceiveTimeout = 5 * 60 * 1000;
            _clienteTcp.SendTimeout = 5 * 60 * 1000;

            _netStream = _clienteTcp.GetStream();
            _streamWriter = new StreamWriter(_netStream, Encoding.Default);
            _streamReader = new StreamReader(_netStream, Encoding.Default);

            return true;
        }

        public bool Disconnect()
        {
            _streamReader.Close();
            _streamReader.Dispose();

            _streamWriter.Close();
            _streamWriter.Dispose();

            _netStream.Close(5000);
            _netStream.Dispose();

            return true;
        }

        public RetornoSocket ExecutarComando(string comando)
        {
            _streamWriter.WriteLine(comando);
            _streamWriter.Flush();

            var linhaRetornada = string.Empty;
            var retorno = string.Empty;
            var existeErro = false;

            while (linhaRetornada != "OK")
            {
                linhaRetornada = _streamReader.ReadLine();
                if (linhaRetornada.StartsWith("CTERROR"))
                {
                    Console.WriteLine(linhaRetornada);
                    retorno = linhaRetornada;
                    existeErro = true;
                    break;
                }
                retorno += linhaRetornada + Environment.NewLine;
            }

            Console.WriteLine(comando + Environment.NewLine + retorno);
            return new RetornoSocket(retorno, existeErro);
        }
    }
}