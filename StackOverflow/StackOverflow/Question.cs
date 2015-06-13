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
        public DateTime date { get; set; }
        public List<Comment> comments { get; set; }
        public List<Answer> answers { get; set; }
        public List<Tag> tags { get; set; }

        public Question(int ID, string title, string text, DateTime date, List<Comment> comments, List<Answer> answers, List<Tag> tags)
        {
            this.ID = ID;
            this.title = title;
            this.text = text;
            this.date = date;
            this.comments = comments;
            this.answers = answers;
            this.tags = tags;
        }
    }
}