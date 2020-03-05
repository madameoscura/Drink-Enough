using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UIKit;

namespace Drink_Enough
{
    class JsonHelper
    {
        static string filename = "Drink.json";
        string filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), filename);

        //zum speichern eines amounts
        public bool jsonWrite(Dictionary<string, int> jsonDict) 
        {
            Console.WriteLine(filepath);
            JObject jobject = new JObject(
            new JProperty("weight", jsonDict["weight"]),
            new JProperty("amount", jsonDict["amount"]));

            try
            {
                using (StreamWriter file = File.CreateText(filepath))
                using (JsonTextWriter writer = new JsonTextWriter(file))
                {
                    jobject.WriteTo(writer);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public Dictionary<string, int> jsonGetAllData()
        {
            Dictionary<string, int> dataDict = new Dictionary<string, int>();
            try
            { if (File.Exists(filepath))
                {
                    var content = File.ReadAllText(filepath);
                    dataDict = JsonConvert.DeserializeObject<Dictionary<string, int>>(content);
                }
                else
                {
                    dataDict.Add("weight", 0);
                    dataDict.Add("amount", 0);
                }
                return dataDict;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null; ;
            }
        }

        public void deleteAllamounts()
        {         
            //Datei löschen, wenn vorhanden
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }
    }
}