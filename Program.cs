// See https://aka.ms/new-console-template for more information
using System;
using MySql.Data.MySqlClient;

namespace MySQLExample
{

    //comando per installare la libreria 
    //dotnet add package MySql.Data
    public class Program
    {
       

        public static void Main(string[] args)
        {
            string connectionString = "server=localhost;user=root;password=telemedicina2123;database=db_pharm;";

            // Creazione del database
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string createDatabaseQuery = "CREATE DATABASE IF NOT EXISTS Ixla";
                using (MySqlCommand cmd = new MySqlCommand(createDatabaseQuery, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            // Creazione della tabella
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string createTableQuery = "CREATE TABLE IF NOT EXISTS UserIxla (id INT AUTO_INCREMENT PRIMARY KEY, name VARCHAR(255), age INT)";
                using (MySqlCommand cmd = new MySqlCommand(createTableQuery, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Database and table created successfully.");
            
            
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Inserimento dei dati nella tabella
                string insertDataQuery = "INSERT INTO UserIxla (name, age) VALUES (@name, @age)";
                using (MySqlCommand cmd = new MySqlCommand(insertDataQuery, connection))
                {
                    Console.WriteLine("enter name: ");
                    string name=Console.ReadLine();

                    Console.WriteLine("enter age: ");
                    int age=Convert.ToInt32(Console.ReadLine());
                 
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.ExecuteNonQuery();
                    
                }
            }

            Console.WriteLine("record add successfully");
        }
    }
}
