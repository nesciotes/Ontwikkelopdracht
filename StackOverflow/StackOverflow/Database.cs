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
                    string CommandText = String.Format( "SELECT questionid, titel, gebruikersnaam, totalviews, datum FROM Question q, Gebruiker g WHERE questionID NOT IN( SELECT questionID FROM Answer) AND q.gebruikerID = g.gebruikerID AND ROWNUM < 25");
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
                    string CommandText = String.Format("SELECT questionid, titel, gebruikersnaam, totalviews, datum FROM Question q, Gebruiker g WHERE q.gebruikerID = g.gebruikerID AND ROWNUM < 25 ORDER BY questionid DESC");
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

                        CommandText = String.Format("SELECT gebruikerid FROM GEBRUIKER WHERE gebruikersnaam=LOWER('{0}')", username);
                        checkCommand = new OracleCommand(CommandText, connection);
                        checkCommand.CommandType = CommandType.Text;
                        checkCommand.ExecuteNonQuery();

                        if (checkReader.HasRows)
                        {
                            while (checkReader.Read())
                            {
                                user = new User(Convert.ToInt32(checkReader["gebruikerid"]), username, email, "", Convert.ToString(DateTime.Now), 0, 0, false);
                            }
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

        public User Login(string username, string password)
        {
            User user = null;
            this.OpenConnection();
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    string CommandText = String.Format("SELECT gebruikerid, gebruikersnaam, wachtwoord, email, bio, inschrijfdatum, reputatie, profileviews, isadmin FROM gebruiker WHERE lower(gebruikersnaam) = lower('{0}') AND wachtwoord = '{1}'", username, password);
                    OracleCommand checkCommand = new OracleCommand(CommandText, connection);
                    checkCommand.CommandType = CommandType.Text;
                    OracleDataReader checkReader = checkCommand.ExecuteReader();

                    if (checkReader.HasRows)
                    {
                        while (checkReader.Read())
                        {
                            int gebruikerid = Convert.ToInt32(checkReader["gebruikerid"]);
                            string gebruikersnaam = Convert.ToString(checkReader["gebruikersnaam"]);
                            string wachtwoord = Convert.ToString(checkReader["wachtwoord"]);
                            string email = Convert.ToString(checkReader["email"]);
                            string bio = Convert.ToString(checkReader["bio"]);
                            string inschrijfdatum = Convert.ToString(checkReader["inschrijfdatum"]);
                            int reputatie = Convert.ToInt32(checkReader["reputatie"]);
                            int profileviews = Convert.ToInt32(checkReader["profileviews"]);
                            bool isadmin = Convert.ToBoolean(checkReader["isadmin"]);
                            user = new User(gebruikerid, gebruikersnaam, email, bio, inschrijfdatum, reputatie, profileviews, isadmin);
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

        public int Addquestion(string title, string question, string tags)
        {
            int id = 0;
            
            if(Administration.Administration_.user != null) {
                id = -1;
            this.OpenConnection();
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    string CommandText = String.Format("INSERT INTO QUESTION (gebruikerid, titel, tekst, datum) VALUES ({0}, '{1}', '{2}', SYSDATE)", Administration.Administration_.user.ID, title, question);
                    OracleCommand checkCommand = new OracleCommand(CommandText, connection);
                    checkCommand.CommandType = CommandType.Text;
                    checkCommand.ExecuteNonQuery();

                    CommandText = String.Format("SELECT questionid FROM question WHERE ROWNUM < 2 ORDER BY questionid DESC");
                    checkCommand = new OracleCommand(CommandText, connection);
                    checkCommand.CommandType = CommandType.Text;
                    OracleDataReader checkReader = checkCommand.ExecuteReader();

                    if (checkReader.HasRows)
                    {
                        while (checkReader.Read())
                        {
                            id = Convert.ToInt32(checkReader["questionid"]);
                        }
                    }
                    checkReader.Close();

                    foreach(string tag in tags.Split(','))
                    {
                        CommandText = String.Format("INSERT INTO tag (naam) VALUES ('{0}')", tag);
                        checkCommand = new OracleCommand(CommandText, connection);
                        checkCommand.CommandType = CommandType.Text;
                        checkCommand.ExecuteNonQuery();

                        CommandText = String.Format("SELECT tagid FROM tag WHERE ROWNUM < 2 ORDER BY tagid DESC");
                        checkCommand = new OracleCommand(CommandText, connection);
                        checkCommand.CommandType = CommandType.Text;
                        checkReader = checkCommand.ExecuteReader();

                        if (checkReader.HasRows)
                        {
                            int tagid = 0;
                            while (checkReader.Read())
                            {
                                tagid = Convert.ToInt32(checkReader["tagid"]);
                            }
                            CommandText = String.Format("INSERT INTO tag_question (tagid, questionid) VALUES ({0}, {1})", tagid, id);
                            checkCommand = new OracleCommand(CommandText, connection);
                            checkCommand.CommandType = CommandType.Text;
                            checkCommand.ExecuteNonQuery();
                        }
                        checkReader.Close();
                    }
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
            }
            return id;
        }
    }
}