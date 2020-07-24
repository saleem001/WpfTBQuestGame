using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTheAionProject.Models
{
    public abstract class Npc : Character
    {
        public string Description { get; set; }
        public string Information
        {
            get
            {
                return InformationText();
            }
            set { }
        }

        public Npc()
        {

        }

        public Npc(int id, string name,HouseName house,string description) 
            : base(id, name, house)
        {
            Id = id;
            Name = name;
            House = house;
            Description = description;
        }

        protected abstract string InformationText();
    }
}
