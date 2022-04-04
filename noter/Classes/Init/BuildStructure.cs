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
            DataTable dir = Classes.Functions.ConvertJSONToDataTable.Tabulate(File.ReadAllText(path + @"\struct.json"));

            foreach(DataRow dr in dir.Rows)
            {
                var parent = (path + @"\" + dr[0]);

                if(!Directory.Exists(parent))
                    Directory.CreateDirectory(parent);

                foreach(DataColumn col in dir.Columns)
                {
                    if(col.Ordinal!=0)
                    {
                        var child = (parent + @"\" + dr[col]);

                        if(!Directory.Exists(child))
                            Directory.CreateDirectory(parent + @"\" + dr[col]);
                    }
                }
            }
        }            
    }
}
