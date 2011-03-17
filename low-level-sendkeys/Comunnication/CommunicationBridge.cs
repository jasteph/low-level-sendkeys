using System;
using System.Linq;
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
            var resp = SendRawKeys.SendKeys(keys);
            if (resp)
            {
                return ResponseOk;
            }
            return string.Format("{0} {1}", ResponseError, "SendKeys did not responded");
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
    }

}