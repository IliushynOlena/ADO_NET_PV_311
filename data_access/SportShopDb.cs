using System.Data.SqlClient;
using data_access.Models;

namespace _02_CRUD_Interface
{
    public class SportShopDb
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
                              VALUES (@name, 
                                      @Type, 
                                      @Quantity, 
                                      @CostPrice, 
                                      @Producer, 
                                      @Price)";

            SqlCommand command = new SqlCommand(cmdText, conn);
            command.Parameters.AddWithValue("name", product.Name);
            command.Parameters.AddWithValue("Type", product.Type);
            command.Parameters.AddWithValue("Quantity", product.Quantity);
            command.Parameters.AddWithValue("CostPrice", product.CostPrice);
            command.Parameters.AddWithValue("Producer", product.Producer);
            command.Parameters.AddWithValue("Price", product.Price);
            command.CommandTimeout = 5; // default - 30sec


            int rows = command.ExecuteNonQuery();
            Console.WriteLine(rows + " rows affected!");

        }
        public List<Product> GetALL()
        {
            string cmdText = @"select * from Products";

            SqlCommand command = new SqlCommand(cmdText, conn);

            SqlDataReader reader = command.ExecuteReader();
            return this.GetProductByQuery(reader);
        }
        public List<Product> GetByName(string name)
        {
            //Stanga';drop database SportShop;--'
            string cmdText = $@"select * from Products where Name = @name";
            //name = "Ball"; 
            SqlCommand command = new SqlCommand(cmdText, conn);
            //command.Parameters.Add("name",System.Data.SqlDbType.NVarChar).Value = name; 
            SqlParameter parameter = new SqlParameter()
            {
                ParameterName = "name",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Value = name
            };
            command.Parameters.Add(parameter);  
            SqlDataReader reader = command.ExecuteReader();
            return this.GetProductByQuery(reader);
        }
        private List<Product> GetProductByQuery(SqlDataReader reader)
        { 
            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                products.Add(new Product()
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    Type = (string)reader[2],
                    Quantity = (int)reader[3],
                    CostPrice = (int)reader[4],
                    Producer = (string)reader[5],
                    Price = (int)reader[6]
                });
            }
            reader.Close();
            return products;
        }
        public Product GetById(int id)
        {
    
            string cmdText = $@"select * from Products where Id = {id}";

            SqlCommand command = new SqlCommand(cmdText, conn);

            SqlDataReader reader = command.ExecuteReader();

            return this.GetProductByQuery(reader).FirstOrDefault()!;

        }
        public void Update(Product product)
        {
            string cmdText = $@"UPDATE Products
                              SET Name =@name, 
                                  TypeProduct =@Type, 
                                  Quantity =@Quantity, 
                                  CostPrice =@CostPrice, 
                                  Producer =@Producer, 
                                  Price =@Price
                                  where Id = {product.Id}";

            SqlCommand command = new SqlCommand(cmdText, conn);
            command.Parameters.AddWithValue("name", product.Name);
            command.Parameters.AddWithValue("Type", product.Type);
            command.Parameters.AddWithValue("Quantity", product.Quantity);
            command.Parameters.AddWithValue("CostPrice", product.CostPrice);
            command.Parameters.AddWithValue("Producer", product.Producer);
            command.Parameters.AddWithValue("Price", product.Price);
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
}
