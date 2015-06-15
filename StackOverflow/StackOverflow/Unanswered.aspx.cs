using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StackOverflow
{
    public partial class Unanswered : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            List<Question> unansweredquestions = Administration.Administration_.unansweredQuestions();
            foreach (Question q in unansweredquestions)
            {
                content.InnerHtml += "<div class='box'><h3>" + q.poster + " | " + q.views + " views | " + q.date + "</h3><p><a href='Question?id=" + q.ID + "'>" + q.title + "</a></p></div>";
            }
        }
    }
}