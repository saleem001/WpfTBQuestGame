using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WpfTheAionProject.Models
{
    public class Player : Character, IBattle
    {

        private int _lives, _health, _experiencePoints, _wealth;
        private ArmyName _armyname;

        private List<Location> _locationVisited;
        private List<Npc> _npcsEngaged;

        private const int DEFENDER_DAMAGE_ADJUSTMENT = 10;
        private const int MAXIMUM_RETREAT_DAMAGE = 10;

        private int _skillLevel;
        private Weapon _currentWeapon;
        private BattleModeName _battleMode;


        private ObservableCollection<GameItemQuantity> _inventory; public ObservableCollection<GameItemQuantity> Inventory { get { return _inventory; } set { _inventory = value; } }
        private ObservableCollection<GameItemQuantity> _potions; public ObservableCollection<GameItemQuantity> Potions { get { return _potions; } set { _potions = value; } }
        private ObservableCollection<GameItemQuantity> _treasures; public ObservableCollection<GameItemQuantity> Treasures { get { return _treasures; } set { _treasures = value; } }
        private ObservableCollection<GameItemQuantity> _weapons; public ObservableCollection<GameItemQuantity> Weapons { get { return _weapons; } set { _weapons = value; } }
        private ObservableCollection<GameItemQuantity> _allies; public ObservableCollection<GameItemQuantity> Allies { get { return _allies; } set { _allies = value; } }
        private ObservableCollection<Mission> _missions; public ObservableCollection<Mission> Missions { get { return _missions; } set { _missions = value; } }

        public enum ArmyName
        {
            Dothraki,
            Unsullied,
            Stark,
            Lannister,
            Targaryen
        }

        public Player() : base()
        {
            _locationVisited = new List<Location>();
            _npcsEngaged = new List<Npc>();
            _weapons = new ObservableCollection<GameItemQuantity>();
            _treasures = new ObservableCollection<GameItemQuantity>();
            _potions = new ObservableCollection<GameItemQuantity>();
            _inventory = new ObservableCollection<GameItemQuantity>();
            _allies = new ObservableCollection<GameItemQuantity>();
            _missions = new ObservableCollection<Mission>();
        }
        public Player(int id, string name, HouseName house) : base(id, name, house)
        {
            Id = id;
            Name = name;
            House = house;
        }
        //public override void functionAbstract()
        //{

        //}
        //public override void functionVirtual()
        //{

        //}
        public Weapon CurrentWeapon
        {
            get { return _currentWeapon; }
            set { _currentWeapon = value; }
        }


        public List<Location> LocationsVisited
        {
            get { return _locationVisited; }
            set { _locationVisited = value; }
        }

        public List<Npc> NpcsEngaged
        {
            get { return _npcsEngaged; }
            set { _npcsEngaged = value; }
        }

        public int Lives
        {
            get { return _lives; }
            set { _lives = value;
                OnPropertyChanged(nameof(Lives));
                OnPropertyChanged(nameof(_lives)); }
        }

        public int SkillLevel { get; set; }
        public BattleModeName BattleMode { get; set; }

        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;

                if (_health > 100)
                {
                    _health = 100;
                }
                else if (_health <= 0)
                {
                    _health = 100;
                    _lives--;
                }
                OnPropertyChanged(nameof(Health));
                OnPropertyChanged(nameof(_health)); }
        }

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; OnPropertyChanged(nameof(ExperiencePoints));
                OnPropertyChanged(nameof(_experiencePoints)); }
        }

        public ArmyName Army
        {
            get { return _armyname; }
            set { _armyname = value; OnPropertyChanged(nameof(Army));
                OnPropertyChanged(nameof(_armyname)); }
        }

        public int Wealth
        {
            get { return _wealth; }
            set { _wealth = value; OnPropertyChanged(nameof(Wealth));
                OnPropertyChanged(nameof(_wealth)); }
        }

        public void UpdateInventoryCategories()
        {
            Potions.Clear();
            Treasures.Clear();
            Weapons.Clear();
            Allies.Clear();
            foreach (var GameItem in _inventory)
            {
                if (GameItem.GameItem is Potion) Potions.Add(GameItem);
                if (GameItem.GameItem is Treasure) Treasures.Add(GameItem);
                if (GameItem.GameItem is Weapon) Weapons.Add(GameItem);
                if (GameItem.GameItem is Allies) Allies.Add(GameItem);

            }
        }


        public void calculatewealth()
        {
            Wealth = _inventory.Sum(i => i.GameItem.Value * i.Quantity);
        }

        public void AddGameItemQuantityToInventory(GameItemQuantity selectedGameItemQuantity)
        {
            //
            // locate selected item in inventory
            //
            GameItemQuantity gameItemQuantity = _inventory.FirstOrDefault(i => i.GameItem.id == selectedGameItemQuantity.GameItem.id);

            if (gameItemQuantity == null)
            {
                GameItemQuantity newGameItemQuantity = new GameItemQuantity();
                newGameItemQuantity.GameItem = selectedGameItemQuantity.GameItem;
                newGameItemQuantity.Quantity = 1;

                _inventory.Add(newGameItemQuantity);
            }
            else
            {
                gameItemQuantity.Quantity++;
            }

            UpdateInventoryCategories();
        }

        public void RemoveGameItemQuantityFromInventory(GameItemQuantity selectedGameItemQuantity)
        {
            //
            // locate selected item in inventory
            //
            GameItemQuantity gameItemQuantity = _inventory.FirstOrDefault(i => i.GameItem.id == selectedGameItemQuantity.GameItem.id);

            if (gameItemQuantity != null)
            {
                if (selectedGameItemQuantity.Quantity == 1)
                {
                    _inventory.Remove(gameItemQuantity);
                }
                else
                {
                    gameItemQuantity.Quantity--;
                }
            }

            UpdateInventoryCategories();
        }
        public bool HasVisited(Location location)
        {
            return _locationVisited.Contains(location);
        }

        public int Attack()
        {
            int hitPoints = random.Next(CurrentWeapon.MinimumDamage, CurrentWeapon.MaximumDamage) * SkillLevel;

            if (hitPoints <= 100)
            {
                return hitPoints;
            }
            else
            {
                return 100;
            }
        }

        /// <summary>
        /// return hit points [0 - 100] based on the NPCs weapon and skill level
        /// adjusted to deliver more damage when first attacked
        /// </summary>
        /// <returns>hit points 0-100</returns>
        public int Defend()
        {
            int hitPoints = (random.Next(CurrentWeapon.MinimumDamage, CurrentWeapon.MaximumDamage) * SkillLevel) - DEFENDER_DAMAGE_ADJUSTMENT;

            if (hitPoints >= 0 && hitPoints <= 100)
            {
                return hitPoints;
            }
            else if (hitPoints > 100)
            {
                return 100;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// return hit points [0 - 100] based on the NPCs skill level
        /// </summary>
        /// <returns>hit points 0-100</returns>
        public int Retreat()
        {
            int hitPoints = SkillLevel * MAXIMUM_RETREAT_DAMAGE;

            if (hitPoints <= 100)
            {
                return hitPoints;
            }
            else
            {
                return 100;
            }
        }


        public void UpdateMissionStatus()
        {
            // // Note: only loop through assigned missions and cast mission to proper child class 7/ 
            foreach (Mission mission in _missions.Where(m => m.status == Mission.MissionStatus.Incomplete))
            {
                if (mission is MissionTravel)
                {
                    if (((MissionTravel)mission).LocationsNotCompleted(_locationVisited).Count == 0)
                    {
                        mission.status = Mission.MissionStatus.Complete;
                        ExperiencePoints += mission.experiencePoints;
                    }
                }
                else if (mission is MissionGather)
                {
                    if (((MissionGather)mission).GameItemQuantitiesNotCompleted(_inventory.ToList()).Count == 0)
                    {

                        mission.status = Mission.MissionStatus.Complete;
                        ExperiencePoints += mission.experiencePoints;
                    }
                }
                else if (mission is MissionEngage)
                {
                    if (((MissionEngage)mission).NpcsNotComp1eted(_npcsEngaged).Count == 0)
                    {
                        mission.status = Mission.MissionStatus.Complete;
                        ExperiencePoints += mission.experiencePoints;
                    }
                }
                else
                {
                    throw new Exception("Unknown Mission child class.");
                }
            }
        }
    }
}
