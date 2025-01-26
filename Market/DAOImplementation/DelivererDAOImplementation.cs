using Market.DAO;
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
    internal class DelivererDAOImplementation : DelivererDAO
    {

        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["market"].ConnectionString;
        public List<Deliverer> GetAll()
        {
            List<Deliverer> list = new List<Deliverer>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM `dostavljac`";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Deliverer deliver = new Deliverer();
                deliver.Id = reader.GetInt32(0);
                deliver.Name = reader.GetString(1);
                deliver.Place = reader.GetString(2);
                list.Add(deliver);
            }
            return list;
        }
    }
}
