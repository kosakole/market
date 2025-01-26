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
    internal class EmployeeCashDeskDAOImplementation : EmployeeCashDeskDAO
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["market"].ConnectionString;

        public List<EmployeeCashDesk> GetAll()
        {
            List<EmployeeCashDesk> list = new List<EmployeeCashDesk>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT kz.id, z.jmbg, z.korisnicko_ime, kasa_id, od FROM kasa_zaposleni kz, zaposleni z WHERE z.jmbg = kz.zaposleni_jmbg;";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                EmployeeCashDesk ecd = new EmployeeCashDesk();
                ecd.ID = reader.GetInt32(0);
                ecd.User.Id = reader.GetString(1);
                ecd.User.Username = reader.GetString(2);
                ecd.CashDesk.Id = reader.GetInt32(3);
                ecd.Created = reader.GetDateTime(4);
                list.Add(ecd);
            }
            return list;
        }

        public EmployeeCashDesk getNext(UserDTO user, CashDesk cash)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            string query = "INSERT INTO `kasa_zaposleni`(zaposleni_jmbg, kasa_id, od) VALUES (@idUser, @idCashDesk, @date);";
            command.CommandText = query;
            command.Parameters.AddWithValue("@idUser", user.Id);
            command.Parameters.AddWithValue("@idCashDesk", cash.Id);
            command.Parameters.AddWithValue("@date", getNowDateTimeStringMYSQL());
            command.Connection = connection;
            int row;
            EmployeeCashDesk ret = new EmployeeCashDesk();
            ret.User = user;
            ret.CashDesk = cash;
            try
            {
                row = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
            ret.ID = (int)command.LastInsertedId;
            return ret;
        }

        private string getNowDateTimeStringMYSQL()
        {
            string dt = DateTime.Now.ToString();
            string[] dateTime = dt.Split(' ');
            string[] date = dateTime[0].Split('/');
            return date[2] + "-" + date[0] + "-" + date[1] + " " + dateTime[1];
        }

        private DateTime GetDateTimeFromString(string s)
        {
            Console.WriteLine($"Ovo je string: {s}");
            // DateTime ret = DateTime.ParseExact(s, "MM/dd/yyyy HH:mm:ss",
            //                            System.Globalization.CultureInfo.InvariantCulture);
            return new DateTime();
        }
    }
}
