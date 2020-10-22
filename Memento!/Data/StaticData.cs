using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;
using Memento;
using Newtonsoft.Json;

namespace Memento_.Data
{
    public static class StaticData
    {
        public static string dataFile = Environment.CurrentDirectory + "/data.json";
        public static void Save(List<Item> obj)
        {
            File.WriteAllText(dataFile, JsonConvert.SerializeObject(obj));
        }
        public static void Load()
        {
            var content = File.ReadAllText(dataFile);
            RunTimeData.MemorizableItems = JsonConvert.DeserializeObject<List<Item>>(content);
        }
    }
}
