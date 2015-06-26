// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DatabaseCommit.cs" company="ICT4Events">
//   S22T-2
// </copyright>
// <summary>
//   The database commit.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SMEEvent
{
    #region

    using System;
    using System.Collections.Generic;
    using Oracle.ManagedDataAccess.Client;
    using System.Data;

    #endregion

    /// <summary>
    ///     The database commit.
    /// </summary>
    public class DatabaseCommit : Database
    {
        /// <summary>
        /// The edit commit.
        /// </summary>
        /// <param name="commit">
        /// The commit.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void EditCommit(Commit commit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     The get all reports.
        /// </summary>
        /// <returns>
        ///     The <see cref="List" />.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public List<AccountCommit> GetAllReports()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get commits.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public List<Commit> GetCommits(byte type)
        {
            List<Commit> messages = new List<Commit>();
            try
            {
                this.OpenConnection();

                string CommandText = String.Format("SELECT Be.\"bijdrage_id\", (SELECT COUNT(*) FROM account_bijdrage WHERE \"bijdrage_id\" = Be.\"bijdrage_id\" AND \"like\" = 1) AS likes, Be.\"titel\", Be.\"inhoud\", Bi.\"datum\", Bi.\"soort\", A.\"gebruikersnaam\" FROM Bericht Be, Bijdrage Bi, Account A WHERE Bi.ID = Be.\"bijdrage_id\" AND Bi.\"account_id\" = A.id ORDER BY Bi.id DESC;");
                OracleCommand checkCommand = new OracleCommand(CommandText, Con);
                checkCommand.CommandType = CommandType.Text;
                OracleDataReader oracmd = checkCommand.ExecuteReader();

                OracleDataReader reader = oracmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        messages.Add(new Commit(Convert.ToInt32(reader["bijdrage_id"]), Convert.ToString(reader["gebruikersnaam"]), Convert.ToString(reader["datum"]), Convert.ToInt32(reader["likes"]), Convert.ToString(reader["titel"]), Convert.ToString(reader["inhoud")));                 
                    }
                }
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

        /// <summary>
        /// The like report.
        /// </summary>
        /// <param name="commit">
        /// The commit.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void LikeReport(Commit commit, byte type)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The post commit.
        /// </summary>
        /// <param name="commit">
        /// The commit.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void PostCommit(Commit commit)
        {
            try
            {
                this.OpenConnection();
                //deze shit klopt van geen kant
                OracleCommand oracmd = new OracleCommand("Feed.PlaatsBericht", this.Con);
                oracmd.BindByName = true;
                oracmd.CommandType = CommandType.StoredProcedure;

                oracmd.Parameters.Add("message", OracleDbType.Int32, message, ParameterDirection.Input);

                oracmd.ExecuteNonQuery();
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

        /// <summary>
        /// The remove commit.
        /// </summary>
        /// <param name="commit">
        /// The commit.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void RemoveCommit(Commit commit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The remove report.
        /// </summary>
        /// <param name="report">
        /// The report.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void RemoveReport(AccountCommit report)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The search commit. 
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <returns>
        /// The <see cref="Commit"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Commit SearchCommit(byte type, string query)
        {
            throw new NotImplementedException();
        }
    }
}