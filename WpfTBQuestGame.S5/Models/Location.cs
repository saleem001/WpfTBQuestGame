using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WpfTheAionProject.Models
{
    public class Location:ObservableObject
    {


        int _id; public int id { get { return _id; } set { _id = value; } }
        string _name; public string name { get { return _name; } set { _name = value; } }
        string _description; public string description { get { return _description; } set { _description = value; } }
        Boolean _accessible; public Boolean accessible { get { return _accessible; } set { _accessible = value; } }
        private string _message;
        private int x_cord, y_cord,_xp;
        private ObservableCollection<Npc> _npcs;

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        int _modifyExperientsPoints;public int modifyExperientsPoints { get { return _modifyExperientsPoints; }set { _modifyExperientsPoints=value;} }
        int _modifyLives; public int modifyLives{ get { return _modifyLives; } set { _modifyLives = value; } }
        private int _modifyHealth;public int ModifyHealth { get { return _modifyHealth; } set { _modifyHealth = value; } }
        int _requiredExperientsPoints; public int requiredExperientsPoints { get { return _requiredExperientsPoints; } set { _requiredExperientsPoints = value; } }
        private ObservableCollection<GameItemQuantity> _gameItems; public ObservableCollection<GameItemQuantity> GameItems { get { return _gameItems; }set { _gameItems = value; } }
        private int _requiredRelicid;public int RequiredRelicid { get { return _requiredRelicid; } set { _requiredRelicid = value; } }
        //public Location(int _id, string _name, string _description, Boolean _accessible)
        //{
        //    this._id = _id; this._name = _name;this._description = _description;this._accessible = _accessible;
        //}

      
        public ObservableCollection<Npc> Npcs
        {
            get { return _npcs; }
            set { _npcs = value; }
        }

        public int XP
        {
            get { return _xp; }
            set { _xp = value; }
        }

        public int XCORD { get { return x_cord; } set { x_cord = value; } }
        public int YCORD { get { return y_cord; } set { y_cord = value; } }


        public Location()
        {
            _gameItems = new ObservableCollection<GameItemQuantity>();
        }

        public void ModifyExperiencePoints()
        {

        }

       



        public void UpdateLocationGameItems()
        {
            ObservableCollection<GameItemQuantity> updatedLocationGameItems = new ObservableCollection<GameItemQuantity>();

            foreach (GameItemQuantity gameItemQuantity in _gameItems)
            {
                updatedLocationGameItems.Add(gameItemQuantity);
            }

            GameItems.Clear();

            foreach (GameItemQuantity gameItemQuantity in updatedLocationGameItems)
            {
                GameItems.Add(gameItemQuantity);
            }
        }
        public void AddGameItemQuantityToLocation(GameItemQuantity selectedGameItemQuantity)
        {
            //
            // locate selected item in location
            //
            GameItemQuantity gameItemQuantity = _gameItems.FirstOrDefault(i => i.GameItem.id == selectedGameItemQuantity.GameItem.id);

            if (gameItemQuantity == null)
            {
                GameItemQuantity newGameItemQuantity = new GameItemQuantity();
                newGameItemQuantity.GameItem = selectedGameItemQuantity.GameItem;
                newGameItemQuantity.Quantity = 1;

                _gameItems.Add(newGameItemQuantity);
            }
            else
            {
                gameItemQuantity.Quantity++;
            }

            UpdateLocationGameItems();
        }

        public void RemoveGameItemQuantityFromLocation(GameItemQuantity selectedGameItemQuantity)
        {
            //
            // locate selected item in location
            //
            GameItemQuantity gameItemQuantity = _gameItems.FirstOrDefault(i => i.GameItem.id == selectedGameItemQuantity.GameItem.id);

            if (gameItemQuantity != null)
            {
                if (selectedGameItemQuantity.Quantity == 1)
                {
                    _gameItems.Remove(gameItemQuantity);
                }
                else
                {
                    gameItemQuantity.Quantity--;
                }
            }

            UpdateLocationGameItems();
        }
        public bool IsAccessibleByExperiencePoints(int playerExperiencePoints)
        {
            return playerExperiencePoints >= _requiredExperientsPoints ? true : false;
        }
    }
}
