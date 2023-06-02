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
        private bool CheckProductName (string productName)
        {
            string regexPattern = "[A-Z][a-z]{3,5}[_][0-9]{3}";

            bool status = Regex.IsMatch(productName, regexPattern);

            if (status)
            {
                return true;
            }
            return false;
        }
        private int GiveProductId ()
        {
            int id = 1;
            var fileTOJson = Json.ProductDeserialize();
            
            foreach(var line in fileTOJson)
            {
                if(line.ProductId == id)
                {
                    id++;
                }
                else
                {
                    return id;
                }
            }
            return id;
        }

        public string GetProductById(int id)
        {
            var fileTo
        }

        public List<Product> GetProductList()
        {
            throw new NotImplementedException();
        }
    }
}
