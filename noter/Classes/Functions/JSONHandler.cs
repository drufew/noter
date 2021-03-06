using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.IO;
using System.Linq;

namespace noter.Classes.Functions
{
    public static class JSONHandler
    {
        public static DataTable Tabulate(string json)
        {
            var jsonLinq = JObject.Parse(json);
            var srcArray = jsonLinq.Descendants().Where(d => d is JArray).First();
            var trgArray = new JArray();
            foreach (JObject row in srcArray.Children<JObject>())
            {
                var cleanRow = new JObject();
                foreach (JProperty column in row.Properties())
                {
                    // Only include JValue types
                    if (column.Value is JValue)
                    {
                        cleanRow.Add(column.Name, column.Value);
                    }
                }

                trgArray.Add(cleanRow);
            }

            return JsonConvert.DeserializeObject<DataTable>(trgArray.ToString());
        }

        public static string LookupDictionary(string search, string path)
        {
            string returnFile = "";

            if (string.IsNullOrEmpty(search))
                search = "directory";

            var jsonLinq = JObject.Parse(File.ReadAllText(path+ @"\dictionary\dictionary.json"));
            var srcArray = jsonLinq.Descendants().Where(d => d is JArray).First();
            var trgArray = new JArray();

            try
            {
                foreach (JProperty element in jsonLinq.Children<JProperty>())
                {
                    var parent = (path + @"\" + element.Name);

                    try
                    {
                        var childElements = element.Descendants().Where(d => d is JArray).First();

                        foreach (JObject childElement in childElements.Children<JObject>())
                        {
                            foreach (JProperty property in childElement.Properties())
                            {
                                if (search.Split('.').Last() == property.Name)
                                    returnFile = property.Value.ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }

            return returnFile;
        }     

        public static void GenerateDirectoriesFromJson(string json, string path)
        {
            var jsonLinq = JObject.Parse(json);
            var srcArray = jsonLinq.Descendants().Where(d => d is JArray).First();
            var trgArray = new JArray();

            try
            {
                foreach (JProperty element in jsonLinq.Children<JProperty>())
                {
                    var parent = (path + @"\" + element.Name);

                    if (!Directory.Exists(parent))
                        Directory.CreateDirectory(parent);

                    try
                    {
                        var childElements = element.Descendants().Where(d => d is JArray).First();

                        foreach (JObject childElement in childElements.Children<JObject>())
                        {
                            foreach (JProperty property in childElement.Properties())
                            {
                                var child = parent + @"\" + property.Value;

                                if (!Directory.Exists(child))
                                    Directory.CreateDirectory(child);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
