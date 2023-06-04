using Hw5.Domain;
using Hw5.servisec;

namespace Hw5.Interface
{
    public class StockRepository : IStockRepository
    {
        public string BuyProduct(Stock productInStock)
        {
            var quantity = StockServisec.CheckProductQuantity(productInStock.ProductId);

            if(quantity != 0) 
            {
                var newQuantity = quantity + productInStock.ProductQuantity;
                var newProductPrice = (productInStock.ProductPrice * quantity) + (productInStock.ProductPrice * productInStock.ProductQuantity) / newQuantity;
                productInStock.ProductQuantity = newQuantity;
                productInStock.ProductPrice = newProductPrice;

                var target = FindTargetLine(productInStock.ProductId);
                OverWriting(target, productInStock);
            }
            else
            {

            }
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
