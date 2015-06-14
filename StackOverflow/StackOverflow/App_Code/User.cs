using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackOverflow
{
    public class User
    {
        public int ID { get; private set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string bio { get; set; }
        public DateTime registerdate { get; set; }
        public int reputation { get; set; }
        public int views { get; set; }
        public bool admin { get; set; }
        public List<Badge> badges { get; set; }
        public List<Question> favorites { get; set; }
        public List<Question> questions { get; set; }
        public List<Answer> answers { get; set; }
        public List<Comment> comments { get; set; }

        public User(int ID, string username, bool admin)
        {
            this.ID = ID;
            this.username = username;
            this.admin = admin;
        }
    }
}