using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTheAionProject.Models
{
    public class Mission
    {
        public enum MissionStatus
        {
            Unassigned,
            Incomplete,
            Complete
        }
    
        int _id; public int id { get { return _id; } set { _id = value; } }
        string _name; public string name { get { return _name; } set { _name = value; } }
        string _description; public string description { get { return _description; } set { _description = value; } }
        MissionStatus _status; public MissionStatus status { get { return _status; } set { _status = value; } }
        string _statusDetails; public string statusDetails { get { return _statusDetails; } set { _statusDetails = value; } }
        int _experiencePoints; public int experiencePoints { get { return _experiencePoints; } set { _experiencePoints = value; } }

        public Mission()
        {

        }
        public Mission(int id,string name,MissionStatus status)
        {
            _id = id;
            _name = name;
            _status = status;
        }
    }
}
