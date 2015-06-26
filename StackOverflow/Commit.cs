// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Commit.cs" company="ICT4Events">
//   S22T-2
// </copyright>
// <summary>
//   The commit.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SMEEvent
{
    #region

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    ///     The commit.
    /// </summary>
    public class Commit
    {
        public int id { get; set; }
        public string poster { get; set; }
        public string date { get; set; }
        public int likes { get; set; }
        public string title { get; set; }
        public string text { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Commit"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="accountProp">
        /// The account prop.
        /// </param>
        /// <param name="date">
        /// The date.
        /// </param>
        /// <param name="likesAndReports">
        /// The likes and reports.
        /// </param>
        public Commit(int id, Account accountProp, DateTime date, List<AccountCommit> likesAndReports)
        {
            this.id = id;
            this.AccountProp = accountProp;
            this.Date = date;
            this.LikesAndReports = likesAndReports;
        }

        public Commit(int id, string poster, string date, int likes, string title, string text)
        {
            this.id = id;
            this.poster = poster;
            this.date = date;
            this.likes = likes;
            this.title = title;
            this.text = text;
        }

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        ///     Gets or sets the account prop.
        /// </summary>
        public Account AccountProp { get; set; }

        /// <summary>
        ///     Gets or sets the date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        ///     Gets or sets the likes and reports.
        /// </summary>
        public List<AccountCommit> LikesAndReports { get; set; }
    }
}