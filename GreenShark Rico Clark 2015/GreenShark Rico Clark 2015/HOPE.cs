using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenShark_Rico_Clark_2015
{
    class HOPE : Mission
    {
        public string name { get; set; }
        public DateTime enddate { get; set; }
        public bool approved { get; set; }
        public List<Measurement> measurements { get; set; }

        public HOPE(DateTime startdate, Point location, string description, bool type, Boat boat, string name, DateTime enddate, bool approved, List<Measurement>  measurements): base(startdate, location, description, type, boat)
        {
            this.name = name;
            this.enddate = enddate;
            this.approved = approved;
            this.measurements = measurements;
        }
    }
}
