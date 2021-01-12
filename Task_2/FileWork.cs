using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Task_2.Model;
using Newtonsoft.Json;

namespace Task_2
{
    public static class FileWork
    {
        public static List<Currency> Read()
        {
            var json = File.ReadAllText("cache.json");
            return JsonConvert.DeserializeObject<List<Currency>>(json); 
        }
        public static void Write(string json)
        {
            File.WriteAllText("cache.json", json);
        }
    }
}
