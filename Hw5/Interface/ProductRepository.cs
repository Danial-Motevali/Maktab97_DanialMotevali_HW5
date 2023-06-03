using Hw5.Domain;
using Hw5.servisec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hw5.Interface
{
    public class ProductRepository : IProductRepository
    {
        public string AddProduct(Product product)
        {
            string name = product.ProductName;
            bool status = CheckProductName(product.ProductName);

            if (status)
            {
                var id = GiveProductId();
                int barcode = RandomNumberGenerator.GetInt32(100000000, 999999999);

                var newProduct = new Product(id , name, barcode);

                Json.SerializeObject(newProduct, "Product");

                return "product added";
            }
            return "not valid name";
        }

        public string GetProductById(int id)
        {
            var fileToJson = Json.ProductDeserialize();
            
            foreach(var line in fileToJson)
            {
                if(line.ProductId == id)
                {
                    return $"your product is: {line.ProductName}";
                }
            }
            return "no product found";
        }

        public List<Product> GetProductList()
        {
            List<Product> produtList = new List<Product>();

            var fileToJson = Json.ProductDeserialize();

            foreach(var line in fileToJson)
            {
                produtList.Add(line);
            }
            return produtList;
        }
    }
}
