using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                    this.connection.ConnectionString =
                        "User Id=dbi329153;Password=guG3TM3oxe;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=fhictora01.fhict.local)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=fhictora)));";
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
            List<MissionProfile> profiles = new List<MissionProfile>();
            try
            {
                //Open connectie
                this.OpenConnection();

                string CommandText =
                    "SELECT mp.MissieprofielID AS MID, mp.beschrijving, mp.type, mp.naam, bt.naam AS bootnaam, bt.personen, bt.snelheid FROM Missieprofiel mp, Boottype bt WHERE mp.TypeID = bt.BoottypeID";
                OracleCommand checkCommand = new OracleCommand(CommandText, this.connection);
                checkCommand.CommandType = CommandType.Text;

                OracleDataReader reader = this.Read(CommandText, null);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int mid = Convert.ToInt32(reader["MID"]);
                        //Data lezen om missieprofiel te maken
                        MissionProfile m = new MissionProfile(
                            Convert.ToInt32(reader["type"]) == 1,
                            Convert.ToString(reader["beschrijving"]),
                            Convert.ToString(reader["naam"]),
                            new Boat(Convert.ToString(reader["bootnaam"]),
                                Convert.ToInt32(reader["personen"]),
                                Convert.ToInt32(reader["snelheid"])));

                        //Data lezen om bijbehorende materialen en gebruikers bij een missieprofiel te doen
                        string CommandText2 =
                            "SELECT m1.naam, mm1.aantal FROM Materiaal m1, Missieprofiel_Materiaal mm1 WHERE m1.MateriaalID IN ( SELECT mm.MateriaalID FROM Missieprofiel_Materiaal mm WHERE mm.MissieprofielID = :mid ) AND m1.MateriaalID = mm1.MateriaalID AND mm1.MissieProfielID = :mid";

                        OracleCommand checkCommand2 = new OracleCommand(CommandText, this.connection);
                        List<OracleParameter> parameters = new List<OracleParameter>();
                        parameters.Add(new OracleParameter(":mid", mid));
                        checkCommand.CommandType = CommandType.Text;

                        OracleDataReader reader2 = this.Read(CommandText2, parameters);
                        if (reader2.HasRows)
                        {
                            while (reader2.Read())
                            {
                                for (int i = 0; i < Convert.ToInt32(reader2["aantal"]); i++)
                                {
                                    m.boattype.materials.Add(
                                        new Material(Convert.ToString(reader2["naam"])));
                                }
                            }
                        }

                        reader2.Close();

                        string CommandText3 =
                            "SELECT f1.naam, mf1.aantal FROM Functie f1, Missieprofiel_Functie mf1 WHERE f1.FunctieID IN ( SELECT mf.FunctieID FROM Missieprofiel_Functie mf WHERE mf.MissieprofielID = :mid ) AND f1.FunctieID = mf1.FunctieID AND mf1.MissieProfielID = :mid";

                        OracleCommand checkCommand3 = new OracleCommand(CommandText, this.connection);
                        parameters = new List<OracleParameter>();
                        parameters.Add(new OracleParameter(":mid", mid));
                        checkCommand.CommandType = CommandType.Text;

                        OracleDataReader reader3 = this.Read(CommandText3, parameters);
                        if (reader3.HasRows)
                        {
                            while (reader3.Read())
                            {
                                for (int i = 0; i < Convert.ToInt32(reader3["aantal"]); i++)
                                {
                                    m.boattype.materials.Add(
                                        new Material(Convert.ToString(reader3["naam"])));
                                }
                            }
                        }
                        profiles.Add(m);
                        reader3.Close();
                    }
                }
                reader.Close();
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (this.connection.State == ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }
            return profiles;
        }

        public bool AddMission(SIN mission)
        {
            try
            {
                //Open connectie
                this.OpenConnection();

                OracleCommand editCommand =
                    new OracleCommand(
                        "INSERT INTO Missie (startdatum, x, y, beschrijving, type) VALUES (:startdatum, :x, :y, :beschrijving: type)");
                editCommand.Parameters.Add(new OracleParameter(":startdatum", mission.startdate));
                editCommand.Parameters.Add(new OracleParameter(":x", mission.location.X));
                editCommand.Parameters.Add(new OracleParameter(":y", mission.location.Y));
                editCommand.Parameters.Add(new OracleParameter(":beschrijving", mission.description));
                editCommand.Parameters.Add(new OracleParameter(":type", Convert.ToInt32(mission.type)));

                editCommand.CommandType = CommandType.Text;
                editCommand.ExecuteNonQuery();

                editCommand =
                    new OracleCommand(
                        "INSERT INTO SIN (MissieID, naam) VALUES ( ( SELECT MAX(m.MissieID) FROM Missie m), :name)");
                editCommand.Parameters.Add(new OracleParameter(":name", mission.name));

                editCommand.CommandType = CommandType.Text;
                editCommand.ExecuteNonQuery();


            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (this.connection.State == ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }
            return true;
        }

        protected internal OracleDataReader Read(string selectQuery, List<OracleParameter> parameters)
        {
            OracleDataReader result = null;
            try
            {
                this.OpenConnection();
                OracleCommand selectCommand = new OracleCommand(selectQuery, this.connection);

                if (parameters != null)
                {
                    foreach (OracleParameter parameter in parameters)
                    {
                        selectCommand.Parameters.Add(parameter);
                    }
                }

                selectCommand.CommandType = CommandType.Text;
                result = selectCommand.ExecuteReader();
            }
            catch (OracleException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }
    }
}
