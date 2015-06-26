// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdministrationCommit.cs" company="ICT4Events">
//   S22T-2
// </copyright>
// <summary>
//   The administration commit.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SMEEvent
{
    #region

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    ///     The administration commit.
    /// </summary>
    public class AdministrationCommit : Administration
    {
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
        /// Not done
        /// </exception>
        public Commit SearchCommit(byte type, string query)
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
        /// Not done
        /// </exception>
        public void PostCommit(Commit commit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The remove commit.
        /// </summary>
        /// <param name="commit">
        /// The commit.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// Not done
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
        /// Not done
        /// </exception>
        public void RemoveReport(AccountCommit report)
        {
            throw new NotImplementedException();
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
        /// Not done
        /// </exception>
        public void LikeReport(Commit commit, byte type)
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
        /// Not done
        /// </exception>
        public List<Commit> GetCommits(byte type)
        {
            return DatabaseCommit
        }

        /// <summary>
        /// The edit commit.
        /// </summary>
        /// <param name="commit">
        /// The commit.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// Not done
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
        ///     Not done
        /// </exception>
        public List<AccountCommit> GetAllReports()
        {
            throw new NotImplementedException();
        }
    }
}