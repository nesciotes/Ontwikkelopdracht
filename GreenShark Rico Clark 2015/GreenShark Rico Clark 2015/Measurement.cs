using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenShark_Rico_Clark_2015
{
    class Measurement
    {
        public string value { get; set; }
        public string type { get; set; }
        public Point location { get; set; }
        public DateTime date { get; set; }

        public Measurement(string value, string type, Point location, DateTime date)
        {
            this.value = value;
            this.type = type;
            this.location = location;
            this.date = date;
        }
    }
}
