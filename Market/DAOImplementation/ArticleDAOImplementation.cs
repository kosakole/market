using Market.DAO;
using Market.DTO;
using Market.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAOImplementation
{
    internal class ArticleDAOImplementation : ArticleDAO
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["market"].ConnectionString;
        public bool AddArticle(Article articl)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();

            string query = "SELECT * FROM artikl WHERE barkod=@id AND obrisan=1;";
            command.CommandText = query;
            command.Parameters.AddWithValue("@id", articl.Barcode);
            command.Connection = connection;
            try
            {
                MySqlDataReader reader = command.ExecuteReader();
                bool hasNext = reader.Read();
                connection.Close();
                if (hasNext)
                {
                    return UpdateArticle(articl, articl.Barcode, true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            command.Parameters.Clear();
            connection.Close();
            connection = new MySqlConnection(connectionString);
            connection.Open();
            query = "INSERT INTO `artikl`(barkod, naziv, cjena, kolicina) VALUES (@barcode, @name, @price, @amount);";
            command.CommandText = query;
            command.Parameters.AddWithValue("@barcode", articl.Barcode);
            command.Parameters.AddWithValue("@name", articl.Name);
            command.Parameters.AddWithValue("@price", articl.Price);
            command.Parameters.AddWithValue("@amount", articl.Amount);
            command.Connection = connection;
            int row;
            try
            {
                row = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine (ex.ToString());
                return  false;
            }
            connection.Close();
            if (row > 0)
                return true;
            return false;
        }

        public bool DeleteArticle(Article articl)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            string query = "UPDATE`artikl` SET obrisan=1 WHERE barkod=@barcode;";
            command.CommandText = query;
            command.Parameters.AddWithValue("@barcode", articl.Barcode);
            command.Connection = connection;
            try
            {
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }

            return true;
        }

        public List<Article> GetAll()
        {
            List<Article> list = new List<Article>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM `artikl` WHERE obrisan=0";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Article articl = new Article();
                articl.Barcode = reader.GetString(0);
                articl.Name = reader.GetString(1);
                articl.Price = reader.GetDecimal(2);
                articl.Amount = reader.GetDecimal(3);
                list.Add(articl);
            }
            return list;
        }

        public Article GetArticle(string barcode)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM `artikl` WHERE barkod=@barcode AND obrisan=0";
            command.Parameters.AddWithValue("@barcode", barcode);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read()) 
            {
                Article articl = new Article();
                articl.Barcode = reader.GetString(0);
                articl.Name = reader.GetString(1);
                articl.Price = reader.GetDecimal(2);
                articl.Amount = reader.GetDecimal(3);
                connection.Close();
                return articl; 
            }
            connection.Close();
            return null;
        }

        public bool UpdateArticle(Article articlel, string barcode)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            string query = "UPDATE `artikl` SET barkod = @barcode, naziv = @name, cjena = @price, kolicina = @amount WHERE barkod = @barcodeOld;";
            command.CommandText = query;
            command.Parameters.AddWithValue("@barcode", articlel.Barcode);
            command.Parameters.AddWithValue("@name", articlel.Name);
            command.Parameters.AddWithValue("@price", articlel.Price);
            command.Parameters.AddWithValue("@amount", articlel.Amount);
            command.Parameters.AddWithValue("@barcodeOld", barcode);
            command.Connection = connection;
            Console.WriteLine($"Name: {articlel.Name}; barcode: {articlel.Barcode}; amount: {articlel.Amount}; old barcode: {barcode}");
            try
            {
                command.ExecuteNonQuery();
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally 
            { 
                connection.Close(); 
            }
            return true;
        }

        public bool UpdateArticle(Article articlel, string barcode, bool isDeleted)
        {
            if(!isDeleted)
            {
                UpdateArticle(articlel, barcode);
            }
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            string query = "UPDATE `artikl` SET barkod = @barcode, naziv = @name, cjena = @price, kolicina = @amount, obrisan=0 WHERE barkod = @barcodeOld;";
            command.CommandText = query;
            command.Parameters.AddWithValue("@barcode", articlel.Barcode);
            command.Parameters.AddWithValue("@name", articlel.Name);
            command.Parameters.AddWithValue("@price", articlel.Price);
            command.Parameters.AddWithValue("@amount", articlel.Amount);
            command.Parameters.AddWithValue("@barcodeOld", barcode);
            command.Connection = connection;
            Console.WriteLine($"Name: {articlel.Name}; barcode: {articlel.Barcode}; amount: {articlel.Amount}; old barcode: {barcode}");
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
    }
}
