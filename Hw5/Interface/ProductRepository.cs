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
        Product newProduct = new Product();
        public string AddProduct(Product product)
        {
            bool status = CheckProductName(product.ProductName);

            if (status)
            {
                var id = GiveProductId();
                int barcode = RandomNumberGenerator.GetInt32(12, 13);

                var j = newProduct(id, product.ProductName, barcode);
            }
            return "not valid name";
        }
        public bool CheckProductName (string productName)
        {
            string regexPattern = "[A-Z][a-z]{3,5}[_][0-9]{3}";

            bool status = Regex.IsMatch(productName, regexPattern);

            if (status)
            {
                return true;
            }
            return false;
        }
        public int GiveProductId ()
        {
            int id = 0;
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
            throw new NotImplementedException();
        }

        public List<Product> GetProductList()
        {
            throw new NotImplementedException();
        }
    }
}
