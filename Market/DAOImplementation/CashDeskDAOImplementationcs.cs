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
    internal class CashDeskDAOImplementationcs : CashDeskDAO
    {

        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["market"].ConnectionString;
        public CashDesk creat()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = 
                "INSERT INTO 'racun' (vrijeme, kasa_zaposleni_id) VALUES (@time, @id)";
          
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                
            }
            connection.Close();
            return null;
        }

        public List<CashDesk> GetAll()
        {
            List<CashDesk> rez = new List<CashDesk>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT id FROM kasa;";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                CashDesk cd = new CashDesk();
                cd.Id = reader.GetInt32(0);
                rez.Add(cd);
            }
            connection.Close();
            return rez;
        }

        private string getDateTimeStringMYSQL() 
        {
            string dt = DateTime.Now.ToString();
            string[] dateTime = dt.Split(' ');
            string[] date = dateTime[0].Split('/');
            return date[2] + "-" + date[1] + "-" + date[0] + " " + dateTime[1];
        }

        public int getNextID()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            string query = $"INSERT INTO `kasa` () VALUES ();";
            command.CommandText = query;
            // command.Parameters.AddWithValue("@date", getNowDateTimeStringMYSQL());
            // command.Parameters.AddWithValue("@id", bill.EmployeeCashDesk.ID);
            command.Connection = connection;
            try
            {
                command.ExecuteNonQuery();
                return (int)command.LastInsertedId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                connection.Close(); 
            }
        }
    }
}
