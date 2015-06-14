using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackOverflow
{
    public class Answer
    {
        public int ID { get; private set; }
        public string text { get; set; }
        public DateTime date { get; set; }
        public bool accepted { get; set; }
        public List<Comment> comments { get; set; }

        public Answer(int ID, string text, DateTime date, bool accepted, List<Comment> comments)
        {
            this.ID = ID;
            this.text = text;
            this.date = date;
            this.accepted = accepted;
            this.comments = comments;
        }
    }
}