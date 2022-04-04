﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Linq;

namespace noter.Classes.Functions
{
    public static class ConvertJSONToDataTable
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
    }
}
