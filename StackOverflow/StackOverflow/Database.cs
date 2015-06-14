using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace StackOverflow
{
    public class Database
    {
        protected OracleConnection connection;

        public void OpenConnection()
        {
            if (connection == null)
            {
                connection = new OracleConnection();
            }
            if (connection.State == ConnectionState.Closed)
            {
                try
                {
                    this.connection.ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVER=XE)));User Id=system;Password=b;";
                    connection.Open();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        protected void CloseConnection()
        {
            connection.Close();
        }

        public List<Question> UnansweredQuestions()
        {
            List<Question> questions = new List<Question>();
            this.OpenConnection();
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    string CommandText = String.Format( "SELECT questionid, titel, gebruikersnaam, totalviews, datum FROM Question q, Gebruiker g WHERE questionID NOT IN( SELECT questionID FROM Answer) AND q.gebruikerID = g.gebruikerID");
                    OracleCommand checkCommand = new OracleCommand(CommandText, connection);
                    checkCommand.CommandType = CommandType.Text;
                    OracleDataReader checkReader = checkCommand.ExecuteReader();

                    if (checkReader.HasRows)
                    {
                        while (checkReader.Read())
                        {
                            int id = Convert.ToInt32(checkReader["questionid"]);
                            string titel = Convert.ToString(checkReader["titel"]);
                            string gebruikersnaam = Convert.ToString(checkReader["gebruikersnaam"]);
                            int totalviews = Convert.ToInt32(checkReader["totalviews"]);
                            string date = Convert.ToString(checkReader["datum"]);
                            questions.Add(new Question(id, titel, gebruikersnaam, totalviews, date)); 
                        }
                    }
                    checkReader.Close();
                }
                else
                {
                    Console.WriteLine("Could not connect to database");
                }
            }
            catch (OracleException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.CloseConnection();
            }
            return questions;
        }

        public List<Question> NewestQuestions()
        {
            List<Question> questions = new List<Question>();
            this.OpenConnection();
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    string CommandText = String.Format("SELECT questionid, titel, gebruikersnaam, totalviews, datum FROM Question q, Gebruiker g WHERE q.gebruikerID = g.gebruikerID ORDER BY questionid DESC");
                    OracleCommand checkCommand = new OracleCommand(CommandText, connection);
                    checkCommand.CommandType = CommandType.Text;
                    OracleDataReader checkReader = checkCommand.ExecuteReader();

                    if (checkReader.HasRows)
                    {
                        while (checkReader.Read())
                        {
                            int id = Convert.ToInt32(checkReader["questionid"]);
                            string titel = Convert.ToString(checkReader["titel"]);
                            string gebruikersnaam = Convert.ToString(checkReader["gebruikersnaam"]);
                            int totalviews = Convert.ToInt32(checkReader["totalviews"]);
                            string date = Convert.ToString(checkReader["datum"]);
                            questions.Add(new Question(id, titel, gebruikersnaam, totalviews, date));
                        }
                    }
                    checkReader.Close();
                }
                else
                {
                    Console.WriteLine("Could not connect to database");
                }
            }
            catch (OracleException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.CloseConnection();
            }
            return questions;
        }

        public User Register(string username, string password, string email)
        {
            User user = null;
            this.OpenConnection();
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    string CommandText = String.Format("SELECT gebruikersnaam FROM gebruiker WHERE lower(gebruikersnaam) = lower('{0}')", username);
                    OracleCommand checkCommand = new OracleCommand(CommandText, connection);
                    checkCommand.CommandType = CommandType.Text;
                    OracleDataReader checkReader = checkCommand.ExecuteReader();

                    if (!checkReader.HasRows)
                    {
                                CommandText = String.Format("INSERT INTO GEBRUIKER (gebruikersnaam, wachtwoord, email, inschrijfdatum) VALUES (LOWER('{0}'), '{1}', '{2}', SYSDATE)", username, password, email);
                                checkCommand = new OracleCommand(CommandText, connection);
                                checkCommand.CommandType = CommandType.Text;
                                checkCommand.ExecuteNonQuery(); 
                                                        user = new User(username, email, "", Convert.ToString(DateTime.Now), 0, 0, false);
                }
                    checkReader.Close();
                }
                else
                {
                    Console.WriteLine("Could not connect to database");
                }
            }
            catch (OracleException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.CloseConnection();
            }
            return user;
        }

        public User Login(string username, string password)
        {
            User user = null;
            this.OpenConnection();
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    string CommandText = String.Format("SELECT gebruikersnaam, wachtwoord, email, bio, inschrijfdatum, reputatie, profileviews, isadmin FROM gebruiker WHERE lower(gebruikersnaam) = lower('{0}') AND wachtwoord = '{1}'", username, password);
                    OracleCommand checkCommand = new OracleCommand(CommandText, connection);
                    checkCommand.CommandType = CommandType.Text;
                    OracleDataReader checkReader = checkCommand.ExecuteReader();

                    if (checkReader.HasRows)
                    {
                        while (checkReader.Read())
                        {
                            string gebruikersnaam = Convert.ToString(checkReader["gebruikersnaam"]);
                            string wachtwoord = Convert.ToString(checkReader["wachtwoord"]);
                            string email = Convert.ToString(checkReader["email"]);
                            string bio = Convert.ToString(checkReader["bio"]);
                            string inschrijfdatum = Convert.ToString(checkReader["inschrijfdatum"]);
                            int reputatie = Convert.ToInt32(checkReader["reputatie"]);
                            int profileviews = Convert.ToInt32(checkReader["profileviews"]);
                            bool isadmin = Convert.ToBoolean(checkReader["isadmin"]);
                            user = new User(gebruikersnaam, email, bio, inschrijfdatum, reputatie, profileviews, isadmin);
                        }
                    }
                    checkReader.Close();
                }
                else
                {
                    Console.WriteLine("Could not connect to database");
                }
            }
            catch (OracleException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.CloseConnection();
            }
            return user;
        }
    }
}