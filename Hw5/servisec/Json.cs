using Hw5.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hw5.servisec
{
    public static class Json
    {
        private static string pathToProduct = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        private static string pathToStock = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        public static string SerializeObject(object obj, string fileName)
        {
            string input = fileName.ToLower();
            string path;

            var jsonToFile = JsonConvert.SerializeObject(obj);

            if (input == "product")
            {
                path = pathToProduct;

            }else if(input == "stock")
            {
                path = pathToStock;
            }
            else //need workd!!!
            {
                throw new Exception("not valid!");
            }

            File.AppendAllText(path, jsonToFile);

            return $"file succesfully adde to {type}";
        }
        
    }
}
