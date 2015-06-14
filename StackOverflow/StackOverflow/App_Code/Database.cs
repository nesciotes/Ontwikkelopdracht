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
                    this.connection.ConnectionString = "Data Source=stackoverflow;User Id=system;Password=admin;Integrated Security=no;";
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

        public List<Question> latestQuestions()
        {
            List<Question> questions = new List<Question>();
            this.OpenConnection();
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    string CommandText = String.Format( "SELECT questionid, titel, gebruikersnaam, totalviews FROM Question q, Gebruiker g WHERE questionID NOT IN( SELECT questionID FROM Answer) AND q.gebruikerID = g.gebruikerID;");
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
                            questions.Add(new Question(id, titel, gebruikersnaam, totalviews)); 
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
    }
}