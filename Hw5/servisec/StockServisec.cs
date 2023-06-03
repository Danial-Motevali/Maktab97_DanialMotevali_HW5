using Hw5.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw5.servisec
{
    public static class StockServisec
    {
        public static int StockId(Stock stock)
        {
            int id = 1;
            var fileToJson = Json.StockDeserialize();

            foreach(var line in fileToJson)
            {
                if(line.StockId == stock.StockId)
                {
                    id++;
                }
            }
            return id;
        }
        public static string FindProductName(Stock stock)
        {
            var fileToJson = Json.StockDeserialize();

            foreach(var line in fileToJson)
            {
                if (stock.Name == line.Name)
                {
                    return line.Name;
                }
            }
            return "";
        }
    }
}
