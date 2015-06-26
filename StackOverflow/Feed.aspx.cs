// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Feed.aspx.cs" company="ICT4Events">
//   S22T-2
// </copyright>
// <summary>
//   The feed.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SMEEvent.GUI.Pages.Guest
{
    #region

    using System;
    using System.Text;
    using System.Web.UI;

    using SMEEvent.Handlers;

    #endregion

    /// <summary>
    ///     The feed.
    /// </summary>
    public partial class Feed : Page
    {
        /// <summary>
        /// The page pre init.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_PreInit(object sender, EventArgs e)
        {
            this.MasterPageFile = Functions.MasterPage();
        }

        /// <summary>
        /// The page load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void postMessage(object sender, EventArgs e)
        {
            Database.postMessage(message.Text);
            loadAllMessages();
        }

        private void loadAllMessages()
        {
            StringBuilder htmlBuilder = new StringBuilder(); 

            foreach(Commit m in DatabaseCommit.ALLECOMMITS()))
            {
                htmlBuilder.Append("<div class='panel panel-default'><div class='panel-heading'>"+m.title+" | "m.poster+" | "+m.date+"</div><div class='panel-body'>"+m.inhoud+"</div></div><br />");
            }

            feed.InnerHtml = htmlBuilder.ToString();
        }
    }
}