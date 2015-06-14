using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StackOverflow
{
    public partial class Latest : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            List<Question> newestquestions = Administration.Administration_.newestQuestions();
            foreach (Question q in newestquestions)
            {
                content.InnerHtml += "<div class='box'><h3>" + q.poster + " | " + q.views + " views | " + q.date + "</h3><p><a href='~/question?id=" + q.ID + "'>" + q.title + "</a></p></div><br />";
            }
        }
    }
}