using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTheAionProject.Models
{
    public class MissionGather:Mission
    {
        int _id;
        string _name;
        string _description;
        MissionStatus _status;
        string _statusDetails;
        int _experiencePoints;

        List<GameItemQuantity> _requiredGameItemQuantities;

        public List<GameItemQuantity> RequiredGameItemQuantities
        {
            get { return _requiredGameItemQuantities; }
            set { _requiredGameItemQuantities = value; }
        }

        public MissionGather()
        {

        }
        public MissionGather(int id, string name, MissionStatus status, List<GameItemQuantity> requiredGameItemQuantities) : base(id, name, status)
        {
            _id = id;
            _name = name;
            _status = status;
            _requiredGameItemQuantities = requiredGameItemQuantities;
        }
        public List<GameItemQuantity> GameItemQuantitiesNotCompleted(List<GameItemQuantity> inventory)
        {
            List<GameItemQuantity> gameItemQuantitiesToComp1ete = new List<GameItemQuantity>();
            foreach (var missionGameItem in _requiredGameItemQuantities)
            {
                GameItemQuantity inventoryItemMatch = inventory.FirstOrDefault(gi => gi.GameItem.id == missionGameItem.GameItem.id);
                if(inventoryItemMatch==null)
                {
                    gameItemQuantitiesToComp1ete.Add(missionGameItem);
                }
                else 
                {
                    if(inventoryItemMatch.Quantity<missionGameItem.Quantity)
                    {
                        gameItemQuantitiesToComp1ete.Add(missionGameItem);
                    }
                }
            }
            return gameItemQuantitiesToComp1ete;
        }
    }
}
