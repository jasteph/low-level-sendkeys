using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace low_level_sendkeys.Comunnication
{
    public static class CommunicationBridge
    {
        public const string ResponseOk = "OK";
        public const string ResponseError = "#ERROR#";
        private static MainForm GetMainForm()
        {
            return Application.OpenForms.OfType<MainForm>().FirstOrDefault();
        }


        public static string SendKeys(string keys)
        {
            return SendRawKeys.SendKeys(keys);
        }

        public static string UnloadApplication()
        {
            MainForm form = GetMainForm();
            if (form != null)
            {
                form.Close();
            }
            Application.Exit();

            return ResponseOk;
        }

        public static string ListKeys()
        {
            var sb = new StringBuilder();
            Keys.KeyManager.Keys.ForEach(k => sb.AppendLine(k.Name));

            sb.AppendLine(ResponseOk);
            return sb.ToString();
        }

        public static string StartSocketServer()
        {
            if (Sockets.SocketConnection.IsSocketServerRunnig())
            {
                return ResponseError + " socket server already running at port " + Sockets.SocketConnection.ServerPort;
            }

            Sockets.SocketConnection.StartSocketServer();

            return ResponseOk;
        }

        public static string StopSocketServer()
        {
            if (!Sockets.SocketConnection.IsSocketServerRunnig())
            {
                return ResponseError + " Server was not running";
            }

            Sockets.SocketConnection.StopSocketServer();
            return ResponseOk;
        }
    }

}