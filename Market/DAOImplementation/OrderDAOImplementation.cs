using Market.DAO;
using Market.DTO;
using Market.model;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market.DAOImplementation
{
    internal class OrderDAOImplementation : OrderDAO
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["market"].ConnectionString;

        public bool create(Order order, Deliverer deliverer)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            string query = $"INSERT INTO `narudzba` (datum, dostavljac_id) VALUES ('{getNowDateTimeStringMYSQL()}', '{deliverer.Id}');";
            command.CommandText = query;
            // command.Parameters.AddWithValue("@date", getNowDateTimeStringMYSQL());
            // command.Parameters.AddWithValue("@id", bill.EmployeeCashDesk.ID);
            command.Connection = connection;
            try
            {
                command.ExecuteNonQuery();
                order.Id = (int)command.LastInsertedId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                // connection.Close(); 
            }
            foreach (Article article in order.Articles)
            {
                query = $"INSERT INTO `artikl_narudzba` VALUES ( {order.Id}, {article.Barcode}, {article.Price}, {article.Amount});";
                command.CommandText = query;
                // command.Parameters.AddWithValue("@id_bill", bill.Id);
                // command.Parameters.AddWithValue("@barcode", article.Barcode);
                // command.Parameters.AddWithValue("@price", article.Price);
                // command.Parameters.AddWithValue("@amount", article.Amount);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                query = $"CALL povecajArtikl({article.Barcode}, {article.Amount});";
                command.CommandText = query;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            connection.Close();
            return true;
        }

        public List<Order> GetAll()
        {
            List<Order> rez = new List<Order>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText =
                "SELECT n.id, n.datum, d.id, d.naziv FROM narudzba n, dostavljac d WHERE n.dostavljac_id = d.id;";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Order order = new Order();
                order.Id = reader.GetInt32(0);
                order.DateTime = reader.GetDateTime(1);
                order.Deliverer.Id= reader.GetInt32(2);
                order.Deliverer.Name = reader.GetString(3);
                order.Articles = GetArticlesForOrder(order.Id);
                rez.Add(order);
            }
            connection.Close();
            return rez;
        }

        public List<Article> GetArticlesForOrder(int idOrder)
        {
            List<Article> articles = new List<Article>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText =
                $"SELECT a.barkod, a.naziv, an.cjena, an.kolicina FROM artikl a, artikl_narudzba an WHERE narudzba_id = {idOrder} AND a.barkod = an.artikl_barkod;";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Article article = new Article();
                article.Barcode  = reader.GetString(0);
                article.Name = reader.GetString(1);
                article.Price = reader.GetDecimal(2);
                article.Amount = reader.GetDecimal(3);
                articles.Add(article);
            }
            connection.Close();
            return articles;
        }

        private string getNowDateTimeStringMYSQL()
        {
            string dt = DateTime.Now.ToString();
            string[] dateTime = dt.Split(' ');
            string[] date = dateTime[0].Split('/');
            return date[2] + "-" + date[0] + "-" + date[1] + " " + dateTime[1];
        }
    }
}
