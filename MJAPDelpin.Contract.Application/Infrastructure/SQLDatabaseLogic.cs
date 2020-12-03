using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MJAPDelpin.Contract.Application.Interface;
using MJAPDelpin.Contract.Domain;
using MJAPDelpin.Contract.Domain.DTO;
using MJAPDelpin.Contract.Domain.Models;

namespace MJAPDelpin.Contract.Application.Infrastructure
{
   public class SQLDatabaseLogic: IDatabaseLogic
    {
        public string ConnectionString = Utillities.ConnectionString;
        public SqlConnection conn;

        public SQLDatabaseLogic()
        {
            conn = new SqlConnection(ConnectionString);
        }

        public void InsertCustomerIntoDatabase(DTOCustomer customer)
        {
            string query = $"insert into customers(Id, Name) values(@id,@name)";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@id",customer.CustomerId);
                command.Parameters.AddWithValue("@name", customer.Name);

                conn.Open();
                int result = command.ExecuteNonQuery();
                conn.Close();
                // Check Error
                if (result < 0)
                    Console.WriteLine("Error inserting data into Database!");
                else
                {
                    Console.WriteLine("nu er der vistnok skrevet en kunde i databasen");
                }
            }
        }

        public void UpdateCustomerInDatabase(DTOCustomer customer)
        {
            string query = $"update Customers set Name = @name where id = @id";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@id", customer.CustomerId);
                command.Parameters.AddWithValue("@name", customer.Name);

                conn.Open();
                int result = command.ExecuteNonQuery();
                conn.Close();

                // Check Error
                if (result < 0)
                    Console.WriteLine("Error inserting data into Database!");
                else
                {
                    Console.WriteLine("nu er der vistnok opdateret en kunde i databasen");
                }
            }
            
        }

        public void InsertResourceInDataBase(DTORessource resource)
        {
            //skriv en rosurce ind i databasen

            

                string query = $"insert into Ressources(Id, Modelstring, Price) values(@id, @modelstring, @price)";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@id", resource.RessourceId);
                command.Parameters.AddWithValue("@modelstring", resource.RessourceModelString);
                command.Parameters.AddWithValue("@price", resource.Price);

                conn.Open();
                int result = command.ExecuteNonQuery();
                conn.Close();

                // Check Error
                if (result < 0)
                    Console.WriteLine("Error inserting data into Database!");
                else
                {
                    Console.WriteLine("nu er der vistnok skrevet en resurse i databasen");
                }
            }
        }

        public void UpdataResourceInDataBase(DTORessource resource)
        {
            //Opdater resource i databasen

            string query = $"update Ressources set price = @price where id = @id";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@id", resource.RessourceId);
                
                command.Parameters.AddWithValue("@price", resource.Price);

                conn.Open();
                int result = command.ExecuteNonQuery();
                conn.Close();

                // Check Error
                if (result < 0)
                    Console.WriteLine("Error inserting data into Database!");
                else
                {
                    Console.WriteLine("nu er der vistnok skrevet en resurse i databasen");
                }
            }
        }

        public bool CheckIfCustomerExist(int customerID)
        {



            string query = $"SELECT COUNT(1) as count FROM Customers WHERE id={customerID} ";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                conn.Open();
                int result = (int)command.ExecuteScalar();

                if (result!=0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }

        public bool CheckIfRessourceExist(int ressourceID)
        {

            string query = $"SELECT COUNT(*) FROM Ressources WHERE id = {ressourceID}";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                conn.Open();
                int result = (int)command.ExecuteScalar();

                if (result != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }
    }
}
