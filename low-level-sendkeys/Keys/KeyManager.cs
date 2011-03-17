
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

namespace low_level_sendkeys.Keys
{
    public static class KeyManager
    {


        public static KeysList Keys = new KeysList();

        private static string GetDefaultKeysFileName()
        {
            string assemblyName = Assembly.GetExecutingAssembly().Location;

            string fullPath = Path.GetDirectoryName(assemblyName);
            string fileName = Path.GetFileNameWithoutExtension(assemblyName);

            return Path.Combine(fullPath, fileName + ".keys");

        }

        public static void SaveKeyListToDisk()
        {
            SaveKeyListToDisk(GetDefaultKeysFileName());
        }
        public static void SaveKeyListToDisk(string fullPath)
        {
            var binaryFormatter = new BinaryFormatter { AssemblyFormat = FormatterAssemblyStyle.Simple };

            using (var fs = File.Open(fullPath, FileMode.Create))
            {
                binaryFormatter.Serialize(fs, Keys);
            }
        }

        public static void LoadKeyListFromDisk()
        {
            LoadKeyListFromDisk(GetDefaultKeysFileName());
        }
        public static void LoadKeyListFromDisk(string fullPath)
        {
            var binaryFormatter = new BinaryFormatter { AssemblyFormat = FormatterAssemblyStyle.Simple };

            if (File.Exists(fullPath))
            {
                using (var fs = File.Open(fullPath, FileMode.Open))
                {
                    Keys = (KeysList)binaryFormatter.Deserialize(fs);
                }
            }
        }
    }
}

