using System;
using System.Collections.Generic;
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
    }
}
