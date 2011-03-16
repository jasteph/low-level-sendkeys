using System.Collections.Generic;
using System.Linq;
using System;

namespace SocketTesteConnection
{
    class Program
    {
        static void Main(string[] args)
        {

            var c = new SocketConnection("localhost", 2005);

            c.Connect();
            RetornoSocket executarComando = c.ExecutarComando("HELP");
            Console.WriteLine(executarComando.RespostaArray);

            c.Disconnect();
        }



    }
}

