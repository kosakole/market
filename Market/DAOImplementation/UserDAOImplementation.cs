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
    internal class UserDAOImplementation : UserDAO
    {

        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["market"].ConnectionString;

        public UserDAOImplementation()
        { 
        }
        public bool AddUser(User user)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            string query = "SELECT * FROM zaposleni WHERE jmbg=@id AND obrisan=1;";
            command.CommandText = query;
            command.Parameters.AddWithValue("@id", user.Id);
            command.Connection = connection;
            try
            {
                MySqlDataReader reader = command.ExecuteReader();
                bool hasNext = reader.Read();
                connection.Close();
                if (hasNext)
                {
                    return UpdateUser(new UserDTO(user), user.Id.ToString(), true);
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
            query = "INSERT INTO `zaposleni` (jmbg, ime, prezime, korisnicko_ime, sifra, zaposlen) VALUES (@id, @firstName, @lastName, @userName, @password, @employed);";
            command.CommandText = query;
            command.Parameters.AddWithValue("@id", user.Id);
            command.Parameters.AddWithValue("@firstName", user.FirstName);
            command.Parameters.AddWithValue("@lastName", user.LastName);
            command.Parameters.AddWithValue("@userName", user.Username);
            command.Parameters.AddWithValue("@password", user.Password);
            command.Parameters.AddWithValue("@employed", user.Employed ? 1 : 0);
            command.Connection = connection;
            try 
            {
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());  
                return false;
            }
            
            connection.Close();
            return true;

        }

        public bool changePassword(UserDTO user, string pass)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            string query = "UPDATE zaposleni SET sifra = @pass where jmbg = @id;";
            command.CommandText = query;
            command.Parameters.AddWithValue("@pass", pass);
            command.Parameters.AddWithValue("@id", user.Id);
            command.Connection = connection;
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

        public bool DeleteUser(UserDTO user)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            string query = "UPDATE `zaposleni` SET obrisan = 1 WHERE jmbg=@id";
            command.CommandText = query;
            command.Parameters.AddWithValue("@id", user.Id);
            command.Connection = connection;
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

        public List<UserDTO> GetAll()
        {
            List<UserDTO> list = new List<UserDTO>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT jmbg, ime, prezime, korisnicko_ime, zaposlen FROM `zaposleni` WHERE obrisan = 0;";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                UserDTO user = new UserDTO();
                user.Id = reader.GetString(0);
                user.FirstName = reader.GetString(1); 
                user.LastName = reader.GetString(2);
                user.Username = reader.GetString(3);
                user.Employed = reader.GetInt32(4) == 1 ? true : false;
                list.Add(user);
            }
            return list;
        }

        public UserDTO GetUser(string id)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT jmbg, ime, prezime, korisnicko_ime, zaposlen FROM `zaposleni` WHERE jmbg=@id and obrisan = 0;";
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader;
            try
            {
                reader = command.ExecuteReader();
            }
            catch (Exception)
            {
                return null;
            } 
            if (reader.Read())
            {
                UserDTO user= new UserDTO();
                user.Id = reader.GetString(0);
                user.FirstName = reader.GetString(1);   
                user.LastName = reader.GetString(2);
                user.Username = reader.GetString(3);
                user.Employed = reader.GetInt32(4) == 1 ? true : false;
                return user;
            }
            return null;
        }

        public UserDTO GetUser(string username, string password)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM `zaposleni` WHERE korisnicko_ime=@username and sifra=@password and obrisan = 0;";
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            MySqlDataReader reader;
            try
            {
                reader = command.ExecuteReader();
            }
            catch (Exception)
            {
                return null;
            }
            if (reader.Read())
            {
                UserDTO user = new UserDTO();
                user.Id = reader.GetString(0);
                user.FirstName = reader.GetString(1);
                user.LastName = reader.GetString(2);
                user.Username = reader.GetString(3);
                user.Employed = reader.GetInt32(5) == 1 ? true : false;
                return user;
            }
            return null;
        }

        public bool UpdateUser(UserDTO user, string id)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            string query = "UPDATE `zaposleni` SET jmbg = @idNew, ime = @firstName, prezime = @lastName, korisnicko_ime = @userName, zaposlen = @employed WHERE jmbg = @id;";
            command.CommandText = query;
            command.Parameters.AddWithValue("@idNew", user.Id);
            command.Parameters.AddWithValue("@firstName", user.FirstName);
            command.Parameters.AddWithValue("@lastName", user.LastName);
            command.Parameters.AddWithValue("@userName", user.Username);
            command.Parameters.AddWithValue("@employed", user.Employed ? 1 : 0);
            command.Parameters.AddWithValue("@id", id);
            command.Connection = connection;
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            connection.Close();
            return true;
        }

        public bool UpdateUser(UserDTO user, string id, bool isDeleted)
        {
            if(!isDeleted)
                return UpdateUser(user, id);

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            string query = "UPDATE `zaposleni` SET jmbg = @idNew, ime = @firstName, prezime = @lastName, korisnicko_ime = @userName, zaposlen = @employed, obrisan=0 WHERE jmbg = @id;";
            command.CommandText = query;
            command.Parameters.AddWithValue("@idNew", user.Id);
            command.Parameters.AddWithValue("@firstName", user.FirstName);
            command.Parameters.AddWithValue("@lastName", user.LastName);
            command.Parameters.AddWithValue("@userName", user.Username);
            command.Parameters.AddWithValue("@employed", user.Employed ? 1 : 0);
            command.Parameters.AddWithValue("@id", id);
            command.Connection = connection;
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            connection.Close();
            return true;
        }
    }
}
