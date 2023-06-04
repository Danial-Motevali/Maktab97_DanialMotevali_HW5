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
    }
}
