using Newtonsoft.Json;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawDepot_Assessment.Data
{
    public class ConfigReader
    {
        public string Username { get; set; }
        public string Password { get; set; }

 
        public static ConfigReader ReadConfig(string filePath)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = @"Data\config.json";
            string fullPath = Path.Combine(basePath, relativePath);

            /* if (!File.Exists(filePath))
             {
                 throw new FileNotFoundException($"Config file not found at path: {filePath}");
             }*/
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<ConfigReader>(json);
        }
    }
}
