using Hw5.Domain;
using Hw5.servisec;

namespace Hw5.Interface
{
    public class StockRepository : IStockRepository
    {
        public string BuyProduct(Stock productInStock)
        {
            
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
