using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StackOverflow
{
    public partial class Question1 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Question q = Administration.Administration_.loadQuestion(Convert.ToInt32(Request.QueryString["id"]));
            if (q != null)
            {
                content.InnerHtml += "<div class='box'><h3>" + q.title + " | " + q.poster + " | " + q.views + " views | " + q.date + "</h3><p>" + q.text + "</p></div><br /><br /><br />";

                foreach (Answer a in Administration.Administration_.loadAnswers(Convert.ToInt32(Request.QueryString["id"])))
                {
                    content.InnerHtml += "<div class='box'><h3>" + a.date + "</h3><p>" + a.text + "</p></div>";

                }
            }
        }
    }
}