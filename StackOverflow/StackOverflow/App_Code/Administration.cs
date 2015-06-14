using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackOverflow
{
    public class Administration
    {
        private static Administration administration;
        protected Database database;
        public User user;

        private Administration()
        {
            database = new Database();
        }

        public static Administration Administration_
        {
            get
            {
                if(administration == null)
                {
                    administration = new Administration();
                }
                return administration;
            }
        }

        public List<Question> popularquestions()
        {
            return database.latestQuestions();
        }
    }
}