using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenShark_Rico_Clark_2015
{
    class User
    {
        public string username { get; set; }
        public Function function { get; set; }

        public User(string username, Function function)
        {
            this.username = username;
            this.function = function;
        }

        public User(Function function)
        {
            this.function = function;
        }
    }
}
