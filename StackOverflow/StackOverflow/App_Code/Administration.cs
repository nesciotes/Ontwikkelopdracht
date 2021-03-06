﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackOverflow
{
    public class Administration
    {
        private static Administration administration;
        protected Database database;
        public User user {get; set;}

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

        public List<Question> unansweredQuestions()
        {
            return database.UnansweredQuestions();
        }

        public List<Question> newestQuestions()
        {
            return database.NewestQuestions();
        }

        public User login(string username, string password)
        {
            user = database.Login(username, password);
            return user;
        }

        public User register(string username, string password, string email)
        {
            user = database.Register(username, password, email);
            return user;
        }

        public int addquestion(string title, string text, string tags)
        {
            return database.Addquestion(title, text, tags);
        }

        public Question loadQuestion(int id)
        {
            return database.Loadquestion(id);
        }

        public List<Answer> loadAnswers(int id)
        {
            return database.Loadanswers(id);
        }
    }
}