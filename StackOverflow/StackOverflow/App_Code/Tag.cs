using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackOverflow
{
    public class Tag
    {
        public string name { get; set; }

        public Tag(string name)
        {
            this.name = name;
        }
    }
}