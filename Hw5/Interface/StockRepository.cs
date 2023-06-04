﻿using Hw5.Domain;
using Hw5.servisec;
using Newtonsoft.Json;
using System.IO;

namespace Hw5.Interface
{
    public class StockRepository : IStockRepository
    {
        public string BuyProduct(Stock productInStock)
        {
            string pathToStock = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Database\\StockJson.json";


            ProductRepository productRepository = new ProductRepository();
            var quantity = StockServisec.CheckProductQuantity(productInStock.ProductId);

            if(quantity != 0) 
            {
                var newQuantity = quantity + productInStock.ProductQuantity;
                var newProductPrice = (productInStock.ProductPrice * quantity) + (productInStock.ProductPrice * productInStock.ProductQuantity) / newQuantity;
                productInStock.ProductQuantity = newQuantity;
                productInStock.ProductPrice = newProductPrice;
                productInStock.Name = StockServisec.FindProductName(productInStock.ProductId);
                productInStock.StockId = StockServisec.GiveStockId();

                var target = StockServisec.FindTargetLine(productInStock.ProductId);
                StockServisec.OverWriting(target, productInStock);

                return productRepository.GetProductById(productInStock.ProductId) + "updateted";
            }
            else
            {
                productInStock.Name = StockServisec.FindProductName(productInStock.ProductId);
                productInStock.StockId = StockServisec.GiveStockId();

                Json.SerializeObject(productInStock, "stock");

                return productRepository.GetProductById(productInStock.ProductId) + "added";
            }
        }

        public List<Stock> GetSalesProductList()
        {
            var lines = Json.StockDeserialize();
            List<Stock> result = new List<Stock>();

            foreach(var line in lines)
            {
                result.Add(line);
            }

            Json.SerializeObject(result, "list");

            return result;
        }

        public string SaleProduct(int productId, int cnt)
        {
            throw new NotImplementedException();
        }
    }
}
