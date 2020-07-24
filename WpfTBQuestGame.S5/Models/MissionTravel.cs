using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTheAionProject.Models
{
    public class MissionTravel : Mission
    {
        int _id;
        string _name;
        string _description;
        MissionStatus _status;
        string _statusDetails;
        int _experiencePoints;

        List<Location> _requiredLocations;

        public List<Location> RequiredLocations
        {
            get { return _requiredLocations; }
            set { _requiredLocations = value; }
        }
        public MissionTravel()
        {
        }
        public MissionTravel(int id, string name, MissionStatus status, List<Location> requiredLocations) : base(id, name, status)
        {
            _id = id;
            _name = name;
            _status = status;
            _requiredLocations = requiredLocations;
        }
        public List<Location> LocationsNotCompleted(List<Location> locationTraveled)
        {
            List<Location> locationsToComp1ete = new List<Location>();
            foreach (var requiredLocation in _requiredLocations)
                if (!locationTraveled.Any(l => l.id == requiredLocation.id))
                {
                    locationsToComp1ete.Add(requiredLocation);
                }
            return locationsToComp1ete;
        }
    }
}
