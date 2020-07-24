using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTheAionProject.Models
{
    public class Animals:Npc
    {
        Random r = new Random();
        public List<string> Messages { get; set; }
        string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public Animals()
        {

        }

        public Animals(int id, string name, HouseName house, string description, List<string> messages,string type)
            : base(id, name, house, description)
        {
            Messages = messages;
            Type = type;
        }
        protected override string InformationText()
        {
            return $"{Name} - {Description}";
        }
        private string GetMessage()
        {
            int messageIndex = r.Next(0, Messages.Count());
            return Messages[messageIndex];
        }
    }
}
