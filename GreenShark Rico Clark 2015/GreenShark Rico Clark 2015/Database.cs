using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace GreenShark_Rico_Clark_2015
{
    class Database
    {
        protected OracleConnection connection { get; set; }

        //Openen connectie als deze nog niet bestaat
        protected void OpenConnection()
        {
            if (this.connection == null)
            {
                this.connection = new OracleConnection();
            }

            if (this.connection.State == ConnectionState.Closed)
            {
                try
                {
                    this.connection.ConnectionString = "User Id=dbi329153;Password=guG3TM3oxe;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=fhictora01.fhict.local)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=fhictora)));"
                    this.connection.Open();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        protected void CloseConnection()
        {
            //Connectie sluiten
            this.connection.Close();
        }

        public List<MissionProfile> LoadAllTemplates()
        {
                this.OpenConnection();

                string CommandText =
                    "SELECT mp.\"beschrijving\", mp.\"type\", mp.\"naam\", ;
                OracleCommand checkCommand = new OracleCommand(CommandText, this.Con);
                checkCommand.CommandType = CommandType.Text;

                OracleDataReader reader = this.Read(CommandText, null);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        messages.Add(
                            new Message(
                                Convert.ToInt32(reader["bijdrage_id"]), 
                                Convert.ToString(reader["gebruikersnaam"]), 
                                Convert.ToDateTime(reader["datum"]), 
                                Convert.ToInt32(reader["likes"]), 
                                Convert.ToString(reader["titel"]), 
                                Convert.ToString(reader["inhoud"])));
                    }
                }
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (this.Con.State == ConnectionState.Open)
                {
                    this.Con.Close();
                }
            }

            return messages;
        }
    }
}
