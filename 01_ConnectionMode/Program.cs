using System.Data.SqlClient;
using System.Text;

namespace _01_ConnectionMode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //connectionString : Property = value;property2 = value;
            /* SQL Server:
              - Windows Authentication:    "Data Source=server_name;Initial Catalog=db_name;Integrated Security=True";
              - SQL Server Authentication: "Data Source=server_name;Initial Catalog=db_name;User ID=login;Password=password";
          */
            /*workstation id=ShopDb123456.mssql.somee.com;
             packet size=4096;
            user id=helen_iliushyn_SQLLogin_1;
            pwd=hi9ub29ivw;
            data source=ShopDb123456.mssql.somee.com;
            persist security info=False;
            initial catalog=ShopDb123456;
            TrustServerCertificate=True*/
                                        
            string connectionString = @"Data Source=DESKTOP-1LCG8OH\SQLEXPRESS;
                                        Integrated Security=True;
                                        Initial Catalog=SportShop;
                                        Connect Timeout=3;
                                        Encrypt=False;
                                        ";

                                        
                                        
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            //hard work with database
            Console.WriteLine("Connetion is success!!!!");

            #region Execute Non-Query
            //string cmdText = @"INSERT INTO Products
            //                  VALUES ('FootballBall', 'Equipment', 14, 1500, 'Ukraine', 2000)";

            //SqlCommand command = new SqlCommand(cmdText, sqlConnection);
            //command.CommandTimeout = 5; // default - 30sec


            ////// ExecuteNonQuery - виконує команду яка не повертає результат 
            /////(insert, update, delete...),
            //////але метод повертає кількітсь рядків, які були задіяні
            //int rows = command.ExecuteNonQuery();

            //Console.WriteLine(rows + " rows affected!");
            #endregion
            #region Execute Scalar
            //string cmdText = @"select AVG(Price) from Products";

            //SqlCommand command = new SqlCommand(cmdText, sqlConnection);

            //// Execute Scalar - виконує команду, яка повертає одне значення
            //int res = (int)command.ExecuteScalar();

            //Console.WriteLine("Result: " + res);
            #endregion
            #region Execute Reader
            string cmdText = @"select * from Products";

            SqlCommand command = new SqlCommand(cmdText, sqlConnection);

            //// ExecuteReader - виконує команду select та повертає результат у вигляді
            //// DbDataReader
            SqlDataReader reader = command.ExecuteReader();

            Console.OutputEncoding = Encoding.UTF8;
           
            //// відображається назви всіх колонок таблиці
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($" {reader.GetName(i),14}");
            }
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");

            //////// відображаємо всі значення кожного рядка
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($" {reader[i],14} ");
                }
                Console.WriteLine();
            }

            reader.Close();
            #endregion





            sqlConnection.Close();
        }
    }
}
