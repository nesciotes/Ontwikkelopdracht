using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;

namespace StackOverflow.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            register.Click += new EventHandler(this.Register_);
        }

        public void Register_(object sender, System.EventArgs e)
        {
            if (Password.Text == Password2.Text)
            {
                if (Email.Text.IndexOf("@") != -1 && Email.Text.IndexOf(".") > Email.Text.IndexOf("@"))
                {
                    Administration.Administration_.register(UserName.Text, Password.Text, Email.Text);
                    User user = Administration.Administration_.user;
                    if (user != null)
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
                        ErrorMessage.Text = "That username is already taken";
                    }
                }
                else
                {
                    ErrorMessage.Text = "Please enter a valid e-mail address";
                }
            }
            else
            {
                ErrorMessage.Text = "The second password you entered did not match with the first";
            }
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            /*FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);

            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (!OpenAuth.IsLocalUrl(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect(continueUrl);*/
        }
    }
}