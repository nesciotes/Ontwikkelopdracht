using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace StackOverflow
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlGenericControl BodyContent = (HtmlGenericControl)Page.FindControl("BodyContent");
            List<Question> popularquestions = Administration.Administration_.popularquestions();
            foreach (Question q in popularquestions)
            {
                BodyContent.Controls.Add(new LiteralControl("<div class='box'><h2>" + q.poster + " | " + q.views + "</h2><p><a href='~/question?id=" + q.ID + "</a>" + q.title + "</p></div>"));
            }
        }
    }
}