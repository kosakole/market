using Market.DAO;
using Market.DTO;
using Market.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market.DAOImplementation
{
    internal class BillDAOImplementation : BillDAO
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["market"].ConnectionString;
        public bool create(Bill bill)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            string query = $"INSERT INTO `racun` (vrijeme, kasa_zaposleni_id) VALUES ('{getNowDateTimeStringMYSQL()}', {bill.EmployeeCashDesk.ID});";
            command.CommandText = query;
            // command.Parameters.AddWithValue("@date", getNowDateTimeStringMYSQL());
            // command.Parameters.AddWithValue("@id", bill.EmployeeCashDesk.ID);
            command.Connection = connection;
            try
            {
                command.ExecuteNonQuery();
                bill.Id = (int)command.LastInsertedId;
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
            foreach(Article article in bill.Articles)
            {
                query = $"INSERT INTO `racun_artikl` VALUES ( {bill.Id}, {article.Barcode}, {article.Price}, {article.Amount});";
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
                query = $"CALL umanjiArtikl({article.Barcode}, {article.Amount});";
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

        public List<Bill> GetAll() 
        {
            List<Bill> rez = new List<Bill>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select r.id, r.vrijeme, z.jmbg, z.korisnicko_ime, k.id from racun r, kasa_zaposleni kz, kasa k, zaposleni z where kz.id = r.kasa_zaposleni_id AND kz.zaposleni_jmbg = z.jmbg AND k.id = kz.kasa_id;";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Bill bill= new Bill();
                bill.Id = reader.GetInt32(0);
                bill.DateTime = reader.GetDateTime(1);
                bill.EmployeeCashDesk.User.Id = reader.GetString(2);
                bill.EmployeeCashDesk.User.Username = reader.GetString(3);
                bill.EmployeeCashDesk.CashDesk.Id = reader.GetInt32(4);
                rez.Add(bill);
            }
            connection.Close();
            return rez;
            
        }
        
        private string getNowDateTimeStringMYSQL()
        {
            string dt = DateTime.Now.ToString();
            string[] dateTime = dt.Split(' ');
            string[] date = dateTime[0].Split('/');
            return date[2] + "-" + date[0] + "-" + date[1] + " " + dateTime[1];
        }

        private DateTime getDateTimeFromString(string input)
        {
            DateTime ret = new DateTime();
            string[] dateTime = input.Split(' ');
            string[] date = dateTime[0].Split('/');
            
            return ret;
        }

        public Bill GetBill(int id)
        {
            Bill bill = new Bill();
            bill.Id = id;   
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText 
                = $"SELECT artikl_barkode, naziv, racun_artikl.cjena, racun_artikl.kolicina FROM racun_artikl , artikl  WHERE racun_id = {id} and racun_artikl.artikl_barkode = artikl.barkod;;";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Article article = new Article();
                article.Barcode = reader.GetString(0);
                article.Name = reader.GetString(1);
                article.Price= reader.GetDecimal(2);
                article.Amount = reader.GetDecimal(3);
                bill.Articles.Add(article);
            }
            connection.Close();
            connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command2 = connection.CreateCommand();
            command2.CommandText
                = $"SELECT r.vrijeme, kz.kasa_id, z.korisnicko_ime FROM racun r, kasa_zaposleni kz, zaposleni z where r.id = {id} and r.kasa_zaposleni_id = kz.id and kz.zaposleni_jmbg = z.jmbg;";
            MySqlDataReader reader2  = command2.ExecuteReader(); ;
            while (reader2.Read())
            {
                bill.DateTime = reader2.GetDateTime(0);
                bill.EmployeeCashDesk.CashDesk.Id = reader2.GetInt32(1);
                bill.EmployeeCashDesk.User.Username = reader2.GetString(2);
            }
            
            connection.Close();
            return bill;
        }

        public bool delete(int id)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText
                = $"DELETE FROM racun_artikl WHERE racun_id={id};";
            MySqlDataReader reader = command.ExecuteReader();
            connection.Close();
            connection = new MySqlConnection(connectionString);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText
                = $"DELETE FROM racun WHERE id={id};";
            reader = command.ExecuteReader();
            connection.Close();
            return true;
        }
    }
}
