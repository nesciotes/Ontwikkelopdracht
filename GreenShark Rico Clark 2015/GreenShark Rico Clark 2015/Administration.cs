using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenShark_Rico_Clark_2015
{
    class Administration
    {
        private static Administration administration;
        protected Database database;
        public User user { get; set; }
        public List<MissionProfile> profiles { get; set; }

        private Administration()
        {
            database = new Database();
            profiles = new List<MissionProfile>();
        }

        public static Administration Administration_
        {
            get
            {
                if (administration == null)
                {
                    administration = new Administration();
                }
                return administration;
            }
        }

        public List<MissionProfile> LoadAllTemplates()
        {
            return Administration_.database.LoadAllTemplates();
        }

        public double Distance(Point a, Point b)
        {
            return Math.Sqrt(
                Math.Pow(
                    Math.Abs(a.X - b.X), 2)
                + Math.Pow(
                    Math.Abs(a.Y - b.Y), 2));
        }

        public Boat Nearestboat(List<Boat> boats, Mission m)
        {
            double shortestdistance = -1;
            Boat nearestboat = null;
            foreach (Boat b in boats)
            {
                double distancefound = Distance(b.location, m.location);
                if(distancefound < shortestdistance || shortestdistance == -1)
                {
                    shortestdistance = distancefound;
                    nearestboat = b;
                }
            }
            return nearestboat;
        }
    }
}
