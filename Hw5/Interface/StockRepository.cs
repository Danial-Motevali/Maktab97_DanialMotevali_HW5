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
            var fileToJson = Json.StockDeserialize();

            var status = (from product in fileToJson
                         where product.ProductId == productInStock.ProductId
                         select product).Any();

            if (status)
            {

            }
            else
            {
                try
                {
                    int stockId = StockServisec.StockId(productInStock);
                    var j = new Stock(stockId);
                }catch (Exception ex)
                {
                    throw new Exception();
                }
            }
            return "hello";
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
