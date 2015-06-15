using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StackOverflow
{
    public partial class Ask : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ask.Click += new EventHandler(this.Ask_);
            if(Administration.Administration_.user == null)
            {
                Response.Redirect("~/Account/Login");
            }
        }

        public void Ask_(object sender, System.EventArgs e)
        {
            int id = Administration.Administration_.addquestion(title.Text, question.Text, tags.Text);
            if(id > 0)
            {
                Response.Redirect("~/Question?id=" + id);
            }
            else if(id == -1)
            {
                FailureText.Text = "Something went wrong while posting your question. Please try again";
            }
            else
            {
                FailureText.Text = "Please log in first";
            }
        }
    }
}