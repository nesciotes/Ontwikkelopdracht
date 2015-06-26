using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenShark_Rico_Clark_2015
{
    class MissionProfile
    {
        public bool type { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string boattype { get; set; }

        public MissionProfile(bool type, string description, string name, string boattype)
        {
            this.type = type;
            this.description = description;
            this.name = name;
            this.boattype = boattype;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
