using System.Data.SqlClient;
using System.Text;

namespace _02_CRUD_Interface
{
    class SportShopDb
    {
        //CRUD Interface
        //[C]reate
        //[R]ead
        //[U]pdate
        //[D]elete
        
        SqlConnection conn;
        public SportShopDb(string connectionString)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
        }
        ~SportShopDb()
        {
            conn.Close();   
        }
        public void Create(Product product)
        {
            string cmdText = $@"INSERT INTO Products
                              VALUES ('{product.Name}', 
                                      '{product.Type}', 
                                       {product.Quantity}, 
                                       {product.CostPrice}, 
                                      '{product.Producer}', 
                                       {product.Price})";

            SqlCommand command = new SqlCommand(cmdText, conn);
            command.CommandTimeout = 5; // default - 30sec


            int rows = command.ExecuteNonQuery();
            Console.WriteLine(rows + " rows affected!");

        }
        public List<Product> GetALL()
        {
            string cmdText = @"select * from Products";

            SqlCommand command = new SqlCommand(cmdText, conn);

            SqlDataReader reader = command.ExecuteReader();

            Console.OutputEncoding = Encoding.UTF8;
            List<Product> products = new List<Product>();
           
            while (reader.Read())
            {
                products.Add(new Product()
                {
                    Id =(int) reader[0],
                    Name =(string) reader[1],
                    Type =(string) reader[2],
                    Quantity =(int) reader[3],
                    CostPrice = (int) reader[4],
                    Producer = (string) reader[5],
                    Price =(int) reader[6]
                });
            }

            reader.Close();
            return products;
        }
        public Product GetById(int id)
        {
            #region Execute Reader
            string cmdText = $@"select * from Products where Id = {id}";

            SqlCommand command = new SqlCommand(cmdText, conn);

            SqlDataReader reader = command.ExecuteReader();

            Product product = new Product();

            while (reader.Read())
            {

                product.Id = (int)reader[0];
                product.Name = (string)reader[1];
                product.Type = (string)reader[2];
                product.Quantity = (int)reader[3];
                product.CostPrice = (int)reader[4];
                product.Producer = (string)reader[5];
                product.Price = (int)reader[6];

            }
            reader.Close();
            return product;
            #endregion

        }
        public void Update(Product product)
        {
            string cmdText = $@"UPDATE Products
                              SET Name ='{product.Name}', 
                                  TypeProduct ='{product.Type}', 
                                  Quantity ={product.Quantity}, 
                                  CostPrice ={product.CostPrice}, 
                                  Producer ='{product.Producer}', 
                                  Price ={product.Price}
                                  where Id = {product.Id}";

            SqlCommand command = new SqlCommand(cmdText, conn);
            command.CommandTimeout = 5; // default - 30sec

            command.ExecuteNonQuery();
        }
        public void Delete(int id)
        {
            string cmdText = $@"delete Products where Id = {id}";

            SqlCommand command = new SqlCommand(cmdText, conn);

            command.ExecuteNonQuery();
        }
    }
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

            var products = sportShop.GetALL();
            foreach (var product in products) {
                Console.WriteLine(product);
            }

            sportShop.Delete(47);

           var changeProduct =  sportShop.GetById(2);
            changeProduct.Price = 500;
            changeProduct.CostPrice = 300;
            sportShop.Update(changeProduct);    
        }
    }
}
