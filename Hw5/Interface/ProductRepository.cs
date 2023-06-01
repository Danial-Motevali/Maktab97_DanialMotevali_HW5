using Hw5.Domain;
using Hw5.servisec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hw5.Interface
{
    public class ProductRepository : IProductRepository
    {
        public string AddProduct(Product product)
        {
            bool status = CheckProductName(product.ProductName);

            if (status)
            {

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
