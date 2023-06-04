using Hw5.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw5.servisec
{
    public static class StockServisec
    {
        private static string pathToStock = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Database\\StockJson.json";

        public static int CheckProductQuantity(int productId)
        {
            var lines = Json.StockDeserialize();

            foreach(var line in lines)
            {
                if (line.ProductId == productId)
                {
                    return line.ProductQuantity;
                }
            }
            return 0;
        }
        public static int FindTargetLine(int id)
        {
            string[] lines = File.ReadAllLines(pathToStock);

            for (int i = 0; i < lines.Length; i++)
            {
                var specificProduct = JsonConvert.DeserializeObject<Stock>(lines[i]);
                if (id == specificProduct.ProductId)
                {
                    return i;
                }
            }
            return 0;
        }
    }
}
