using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;

namespace _02_DemoController
{
    public class JsonTool
    {
        //renvoie une chaine JSON
        public static string ToJson<T>(T obj)
        {
            string result = null;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            MemoryStream memoryStream = new MemoryStream();
            serializer.WriteObject(memoryStream, obj);
            result = Encoding.UTF8.GetString(memoryStream.ToArray());  
            
            memoryStream.Close();
            return result;
        }
    }
}