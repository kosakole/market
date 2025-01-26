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

namespace Market.DAOImplementation
{
    public class AdminDAOImplemetation : AdminDAO
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["market"].ConnectionString;
        public bool check(string username, string password)
        {
            bool ret = false;
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText
                = $"SELECT * FROM administrator WHERE korisnicko_ime = '{username}' and sifra = '{password}';";
            MySqlDataReader reader = command.ExecuteReader();
            if(reader.Read()) 
                ret = true; 
            connection.Close();
            return ret;
        }
    }
}
