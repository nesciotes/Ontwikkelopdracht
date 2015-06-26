using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenShark_Rico_Clark_2015
{
    class Boat
    {
        public string name { get; set; }
        public string type { get; set; }
        public int speed { get; set; }
        public int people { get; set; }
        public Point location { get; set; }
        public List<User> users { get; set; }
        public List<Material> materials { get; set; }

        public Boat(string name, string type, int speed, int people, Point location, List<User> users,
            List<Material> materials)
        {
            this.name = name;
            this.type = type;
            this.speed = speed;
            this.people = people;
            this.location=location;
            this.users = users;
            this.materials = materials;
        }

        public Boat(string name, string type, int speed, int people, List<User> users , List<Material> materials)
        {
            this.name = name;
            this.type = type;
            this.speed = speed;
            this.people = people;
            this.materials = materials;
        }
    }
}
