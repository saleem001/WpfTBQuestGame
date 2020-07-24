using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTheAionProject.Models
{
    public class Treasure :GameItem
    {
        private TreasureType _treasurtype;
        public TreasureType TreasureTypeProp { get { return _treasurtype; }set { _treasurtype = value; } }
        public enum TreasureType
        {
            Gold,
            Diamond,
            Silver,
            Brinze
        }
        public Treasure(int id, string name, int value, TreasureType type, string description, int experiencePoints)
            : base(id, name, value, description, experiencePoints)
        {
            TreasureTypeProp = type;
        }
        public override string InformationString()
        {
            return $"{Name}: {Description}\nValue: {Value}";
        }

    }
}
