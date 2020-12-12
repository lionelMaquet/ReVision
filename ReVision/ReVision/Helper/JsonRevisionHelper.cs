using Newtonsoft.Json;
using ReVision.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ReVision.Helper
{
    static class JsonRevisionHelper
    {

        static private string DbPath = "C:/Users/lione/Desktop/Side Projects/ReVision/ReVision/ReVision/jsondb.json";

        static public void WriteSubjects(object myObj)
        {
            using (StreamWriter myFile = new StreamWriter(DbPath))
            {
                myFile.WriteLine(JsonConvert.SerializeObject(myObj));
            }
        }

        static public List<Subject> ReadSubjects()
        {
            List<Subject> result = new List<Subject>();
            using (StreamReader file = new StreamReader(DbPath))
            {
                result = JsonConvert.DeserializeObject<List<Subject>>(file.ReadToEnd());
                file.Close();
            }
            return result;
        }

        static public List<Subject> RewriteAndReload(object myObj)
        {
            WriteSubjects(myObj);
            return ReadSubjects();
        }

        

        
    }
}
