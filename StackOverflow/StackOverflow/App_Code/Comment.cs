using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackOverflow
{
    public class Comment
    {
        public int ID { get; private set; }
        public string text { get; set; }
        public DateTime date { get; set; }

        public Comment(int ID, string text, DateTime date)
        {
            this.ID = ID;
            this.text = text;
            this.date = date;
        }
    }
}