using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackOverflow
{
    public class Question
    {
        public int ID { get; private set; }
        public string title { get; set; }
        public string text { get; set; }
        public int views { get; set; }
        public string date { get; set; }
        public List<Comment> comments { get; set; }
        public List<Answer> answers { get; set; }
        public List<Tag> tags { get; set; }
        public string poster { get; set; }

        public Question(int ID, string title, string poster, int views, string date)
        {
            this.ID = ID;
            this.title = title;
            this.poster = poster;
            this.views = views;
            this.date = date;
        }

        public Question(int ID, string title, string text, string poster, int views, string date)
        {
            this.ID = ID;
            this.title = title;
            this.poster = poster;
            this.views = views;
            this.date = date;
            this.text = text;
        }
    }
}