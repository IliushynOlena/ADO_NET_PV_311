using data_access.Models;
using System.Text;

namespace _02_CRUD_Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=DESKTOP-1LCG8OH\SQLEXPRESS;
                                        Integrated Security=True;
                                        Initial Catalog=SportShop;
                                        Connect Timeout=3;
                                        Encrypt=False;";
            SportShopDb sportShop = new SportShopDb(connectionString);
            Product pr = new Product()
            {
                Name = "Ball",
                Type = "Equipment",
                Quantity = 10,
                CostPrice = 100,
                Producer = "China",
                Price = 200
            };
            //sportShop.Create(pr);
            Console.WriteLine("Enter name of product to search : ");
            string name = Console.ReadLine()!;
            var products = sportShop.GetByName(name);
            foreach (var product in products) {
                Console.WriteLine(product);
            }

            sportShop.Delete(47);

           var changeProduct =  sportShop.GetById(3);
            changeProduct.Price += 500;
            changeProduct.CostPrice += 300;
            sportShop.Update(changeProduct);    
        }
    }
}
