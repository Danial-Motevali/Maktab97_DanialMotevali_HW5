using Hw5.Domain;
using Hw5.servisec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw5.Interface
{
    public class StockRepository : IStockRepository
    {
        public string BuyProduct(Stock productInStock)
        {
            var fileToJson = Json.StockDeserialize;

            var g = (from j in fileToJson()
                    where j.ProductId == productInStock.ProductId
                    select j).Any();

            if (g)
            {
                return "okey";
            }
            return "not okey";
        }


        public List<Stock> GetSalesProductList()
        {
            throw new NotImplementedException();
        }

        public string SaleProduct(int productId, int cnt)
        {
            throw new NotImplementedException();
        }
    }
}
