using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

namespace low_level_sendkeys.Macros
{
    public static class MacroManager
    {
        public static MacroList Macros = new MacroList();

        private static string GetDefaultMacrosFileName()
        {
            string assemblyName = Assembly.GetExecutingAssembly().Location;

            string fullPath = Path.GetDirectoryName(assemblyName);
            string fileName = Path.GetFileNameWithoutExtension(assemblyName);

            return Path.Combine(fullPath, fileName + ".macros");

        }

        public static void SaveMacroListToDisk()
        {
            SaveMacroListToDisk(GetDefaultMacrosFileName());
        }
        public static void SaveMacroListToDisk(string fullPath)
        {
            var binaryFormatter = new BinaryFormatter { AssemblyFormat = FormatterAssemblyStyle.Simple };

            using (var fs = File.Open(fullPath, FileMode.Create))
            {
                binaryFormatter.Serialize(fs, Macros);
            }
        }

        public static void LoadMacroListFromDisk()
        {
            LoadMacroListFromDisk(GetDefaultMacrosFileName());
        }
        public static void LoadMacroListFromDisk(string fullPath)
        {
            var binaryFormatter = new BinaryFormatter { AssemblyFormat = FormatterAssemblyStyle.Simple };

            if (File.Exists(fullPath))
            {
                using (var fs = File.Open(fullPath, FileMode.Open))
                {
                    Macros = (MacroList)binaryFormatter.Deserialize(fs);
                }
            }
        }
    }
}