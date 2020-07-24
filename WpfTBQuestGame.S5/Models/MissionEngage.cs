using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTheAionProject.Models
{
    public class MissionEngage:Mission
    {
        int _id; 
        string _name; 
        string _description; 
        MissionStatus _status; 
        string _statusDetails; 
        int _experiencePoints;

        List<Npc> _requiredNpcs;

        public List<Npc> requiredNpcs
        {
           get { return _requiredNpcs; }
            set { _requiredNpcs = value; }
        }

        public MissionEngage()
        {

        }
        public MissionEngage(int id, string name, MissionStatus status,List<Npc> requiredNpcs):base(id,name,status)
        {
            _id = id;
            _name = name;
            _status = status;
            _requiredNpcs = requiredNpcs;
        }
        public void NpcsNotCompleted(List<Npc> NpcsEngaged)
        {

        }

        public List<Npc> NpcsNotComp1eted(List<Npc> NpcsEngaged)
        {
            List<Npc> npcsToComp1ete=new List<Npc>();
            foreach (var requiredNpc in _requiredNpcs)
                if (!NpcsEngaged.Any(l => l.Id == requiredNpc.Id))
                {
                    npcsToComp1ete.Add(requiredNpc);
                }
            return npcsToComp1ete;
        }

    }
}
