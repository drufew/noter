using System.Data;
using System.IO;

namespace noter.Classes.Init
{
    public static class BuildStructure
    {
        static string path = System.IO.Path.GetDirectoryName(
       System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);

        public static void BuildDirectories()
        {
            Classes.Functions.JSONHandler.GenerateDirectoriesFromJson(File.ReadAllText(path + @"\struct.json"),path);
        }            
    }
}
