using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace StackOverflow.Account
{
    public partial class Login : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
            login.Click += new EventHandler(this.Login_);
            
            
            RegisterHyperLink.NavigateUrl = "Register";

        }

        public void Login_(object sender, System.EventArgs e)
        {
            Administration.Administration_.login(UserName.Text, Password.Text);
            User user = Administration.Administration_.user;
            if(user != null)
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                  1,
                  user.username,
                  DateTime.Now,
                  DateTime.Now.AddMinutes(10000),
                  true,
                  "SO", 
                  FormsAuthentication.FormsCookiePath);

                string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);

                Response.Redirect("~/Latest");
            }
            else
            {
                FailureText.Text = "Please enter valid login credentials";
            }
        }
    }
}