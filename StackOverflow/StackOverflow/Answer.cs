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
        public string date { get; set; }
        public bool accepted { get; set; }
        public List<Comment> comments { get; set; }

        public Answer(string text, string date)
        {

            this.text = text;
            this.date = date;

        }
    }
}