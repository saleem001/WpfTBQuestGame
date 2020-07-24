using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTheAionProject.Models;

namespace WpfTheAionProject.PresentationLayer
{
    public class MissionStatusViewModel:ObservableObject
    {
        private string _missionInformation;
        private List<Mission> _missions;

        public string MissionInformation
        {
            get { return _missionInformation; }
            set
            {
                _missionInformation = value;
                OnPropertyChanged(nameof(MissionInformation));
                OnPropertyChanged(nameof(_missionInformation));
            }
        }

        public List<Mission> Missions
        {
            get { return _missions; }
            set { _missions = value; }
        }
    }
}
