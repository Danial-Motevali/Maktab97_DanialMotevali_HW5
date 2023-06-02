using Hw5.Domain;
using Hw5.Interface;

namespace Hw5.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductRepository productRe = new ProductRepository();
            Product newProduct = new Product();

            string? firstMenuInput;
            string? productmenu;
            string? addingProduct;

            do 
            {
                Console.Clear();
                Console.Write("--1.Product menu/2.Stock menu--\n-");
                firstMenuInput = Console.ReadLine();

                if (firstMenuInput == "1") 
                {
                    Console.Clear();
                    Console.Write("---You are in product menu---\n--1.Adding Product/2.Get Product by Id\n-");
                    productmenu = Console.ReadLine();

                    if(productmenu == "1")
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("warning: ");
                        Console.ForegroundColor= ConsoleColor.White;

                        Console.Write("For naming the product you must first start with capital latter falo with three of four small letter one \"_\" \nand three digit\n\nProduct Name: ");
                        addingProduct = Console.ReadLine();
                        newProduct.ProductName = addingProduct;

                        productRe.AddProduct(newProduct);

                    }else if(productmenu == "2")
                    {
                        Console.Clear();
                        Console.Write("Give me the produt id: ");
                        productRe.GetProductById();
                    }
                }
                else if (firstMenuInput == "2") { }
                else
                {
                    Console.WriteLine("not valid input");
                }
            } while (true);
            
        }
    }
}