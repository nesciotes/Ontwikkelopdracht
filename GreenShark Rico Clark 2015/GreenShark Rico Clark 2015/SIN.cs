using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenShark_Rico_Clark_2015
{
    class SIN : Mission
    {
        public string name { get; set; }
        public List<Incident> incidents { get; set; }

        public SIN(DateTime startdate, Point location, string description, bool type, string name)
            : base(startdate, location, description, type)
        {
            this.name = name;
            this.incidents = incidents;
        }

        //Alleen voor unit tests
        public SIN(int x, int y) : base(x, y)
        {
            //
        }

    }
}
