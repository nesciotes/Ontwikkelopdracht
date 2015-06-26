using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenShark_Rico_Clark_2015
{
    abstract class Mission
    {
        public DateTime startdate { get; set; }
        public Point location { get; set; }
        public string description { get; set; }
        public bool type { get; set; }
        public Boat boat { get; set; }

        public Mission(DateTime startdate, Point location, string description, bool type, Boat boat)
        {
            this.startdate = startdate;
            this.location = location;
            this.description = description;
            this.type = type;
            this.boat = boat;
        }

        public Mission(DateTime startdate, Point location, string description, bool type)
        {
            this.startdate = startdate;
            this.location = location;
            this.description = description;
            this.type = type;
        }

        //Voor unittests
        public Mission(int x, int y)
        {
            this.location = new Point(x, y);
        }
    }
}
