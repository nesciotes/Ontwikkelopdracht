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

        public Boat(string name, int speed, int people, List<User> users,
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

        public Boat(string name, int speed, int people)
        {
            this.name = name;
            this.speed = speed;
            this.people = people;
        }

        //Voor unittests
        public Boat(int x, int y)
        {
            this.location = new Point(x, y);
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
