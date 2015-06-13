using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackOverflow
{
    public class Administration
    {
        protected Database database;
        public User user;
        public List<Question> popularquestions;

        public Administration()
        {
            database = new Database();
        }
    }
}