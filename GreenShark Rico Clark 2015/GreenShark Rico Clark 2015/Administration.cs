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

        //Het instellen van alle fields (Met name singleton administration, en User die ingelogd is)
        private static Administration administration;
        protected Database database;
        public User user { get; set; }
        public List<MissionProfile> profiles { get; set; }

        private Administration()
        {
            database = new Database();
            profiles = new List<MissionProfile>();
            CreateProfiles();
        }

        private void CreateProfiles()
        {
            //Aanmaken missie profielen om te gebruiken bij aanmaken van missie
            List<Material> materials = new List<Material>();
            List<User> users = new List<User>();

            //Alle materialen voor het eerste missieprofiel
            materials.Add(new Material("Navigatiesysteem"));
            materials.Add(new Material("Verrekijker"));
            materials.Add(new Material("Meetapparatuur"));
            materials.Add(new Material("Gereedschapskist"));
            
            //Alle personeel voor het eerste missieprofiel
            users.Add(new User(new Function("Kapitein")));
            users.Add(new User(new Function("Bioloog")));
            users.Add(new User(new Function("Bioloog")));
            users.Add(new User(new Function("Technicus")));

            //Alle profielen toevoegen
            profiles.Add(new MissionProfile(false, "Missie voor kleine HOPE", "Small HOPE", new Boat("Klein", 50, 4, users, materials)));
            profiles.Add(new MissionProfile(false, "Missie voor Grote HOPE", "Big HOPE", new Boat("Klein", 45, 8)));
            profiles.Add(new MissionProfile(true, "Missie voor kleine SIN", "Small SIN", new Boat("Klein", 50, 4)));
            profiles.Add(new MissionProfile(true, "Missie voor middel SIN", "Middle SIN", new Boat("Middel", 45, 8)));
            profiles.Add(new MissionProfile(true, "Missie voor grote SIN", "Big SIN", new Boat("Groot", 32, 15)));
 
        }

        public static Administration Administration_
        {
            //Singleton Administration
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
            //Deze werkte niet en daar ben ik veel tijd aan kwijt geweest
            return Administration_.database.LoadAllTemplates();
        }

        public double Distance(Point a, Point b)
        {
            //Afstand berekenen met stelling van Pythagoras
            return Math.Sqrt(
                Math.Pow(
                    Math.Abs(a.X - b.X), 2)
                + Math.Pow(
                    Math.Abs(a.Y - b.Y), 2));
        }

        public Boat Nearestboat(List<Boat> boats, Mission m)
        {
            //Door alle boten loopen en kortst gevonden afstand en boot opslaan
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

        public bool AddMission(SIN mission)
        {
            //Functie doorsturen naar database
            return database.AddMission(mission);
        }

        public SIN LoadMission(string name)
        {
            //Functie doorsturen naar database
            return database.LoadMission(name);
        }
    }
}
