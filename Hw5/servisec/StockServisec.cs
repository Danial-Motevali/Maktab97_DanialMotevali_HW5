using Hw5.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public static int GetQuantity(Stock stock)
        {
            var fileToJson = Json.StockDeserialize();
            int oldquantity = 0;
            int newquntity = 0;

            foreach(var line in fileToJson)
            {
                if(line.ProductId == stock.ProductId)
                {
                    oldquantity = line.ProductQuantity;
                }
            }

            newquntity = oldquantity + stock.ProductQuantity;

            return newquntity;
        }
        public static int GetPrice(Stock stock)
        {
            int price = 1000;
            int finalPrice = 0;
            var fileToJson = Json.StockDeserialize();
            int oldQuantity = 0;
            int quantity = GetQuantity(stock);

            foreach(var line in fileToJson)
            {
                if(line.ProductId == stock.ProductId)
                {
                    line.ProductQuantity = oldQuantity;
                }
            }

            finalPrice = (stock.ProductQuantity * price) + (oldQuantity * price) / quantity;

            return finalPrice;
        }
    }
}
