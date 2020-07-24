using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTheAionProject.Models;
using System.Windows;
using System.Collections.ObjectModel;

namespace WpfTheAionProject.PresentationLayer
{
    public class GameSessionViewModel : ObservableObject
    {

        #region CONSTANTS

        const string TAB = "\t";
        const string NEW_LINE = "\t";

        #endregion

        #region FIELDS

        private Player _player;
        private Map _gameMap;
        private Location _currentlocation;
        private Location _northLocation, _eastLocation, _southLocation, _westLocation;
        private string _currentLocationInformation;
        private string _gameMessage;

        //  private List<string> AccessibleLocationsNames;
        private GameItemQuantity _currentGameItem;

        private Random random = new Random();

        private Npc _currentNpc;

        #endregion

        #region PROPERTIES

        public GameItemQuantity CurrentGameItem
        {
            get { return _currentGameItem; }
            set
            {
                _currentGameItem = value;
                OnPropertyChanged(nameof(CurrentGameItem));
                if (_currentGameItem != null && _currentGameItem.GameItem is Weapon)
                {
                    _player.CurrentWeapon = _currentGameItem.GameItem as Weapon;
                }
            }
        }

        public string GameMessage
        {
            get { return _gameMessage; }
            set { _gameMessage = value; }
        }
        public string MessageDisplay
        {
            get { return _currentlocation.Message; }
        }

        public Map GameMap { get { return _gameMap; } set { _gameMap = value; } }

        public Location CurretLocation
        {
            get { return _currentlocation; }
            set
            {
                _currentlocation = value;
                _currentLocationInformation = _currentlocation.description;
                OnPropertyChanged(nameof(CurretLocation));
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }

        public Location NorthLocation
        {
            get { return _northLocation; }
            set
            {
                _northLocation = value;
                OnPropertyChanged(nameof(NorthLocation));
                OnPropertyChanged(nameof(HasNorthLocation));
            }
        }

        public Location EastLocation
        {
            get { return _eastLocation; }
            set
            {
                _eastLocation = value;
                OnPropertyChanged(nameof(EastLocation));
                OnPropertyChanged(nameof(HasEastLocation));
            }
        }

        public Location SouthLocation
        {
            get { return _southLocation; }
            set
            {
                _southLocation = value;
                OnPropertyChanged(nameof(SouthLocation));
                OnPropertyChanged(nameof(HasSouthLocation));
            }
        }

        public Location WestLocation
        {
            get { return _westLocation; }
            set
            {
                _westLocation = value;
                OnPropertyChanged(nameof(WestLocation));
                OnPropertyChanged(nameof(HasWestLocation));
            }
        }

        public bool HasNorthLocation
        {
            get
            {
                if (NorthLocation != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool HasEastLocation { get { return EastLocation != null; } }
        public bool HasSouthLocation { get { return SouthLocation != null; } }
        public bool HasWestLocation { get { return WestLocation != null; } }


        public string CurrentLocationInformation
        {
            get { return _currentLocationInformation; }
            set
            {
                _currentLocationInformation = value;
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }

        public string CurrentLocationName
        {
            get { return _currentlocation.name; }
            set { _currentlocation.name = value; }
        }

        public ObservableCollection<Location> AccessibleLocations
        { get { return _gameMap.AccessibleLocations; } }

        public List<string> AccessibleLocationsnames
        { get { return _gameMap.AccessibleLocationsNames; } }

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public Npc CurrentNpc
        {
            get { return _currentNpc; }
            set
            {
                _currentNpc = value;
                OnPropertyChanged(nameof(CurrentNpc));
                OnPropertyChanged(nameof(_currentNpc));

            }
        }

        #endregion

        #region CONSTRUCTORS

        public GameSessionViewModel()
        {

        }

        public GameSessionViewModel(Player player,
                string initialMessages,
                Map gameMap,
                GameMapCoordinates currentLocationCoordinates
                )
        {
            _player = player;
            _gameMap = gameMap;
            _gameMap.CurrentLocationCoordinates = currentLocationCoordinates;
            _currentlocation = _gameMap.CurrentLocation;
            GameMessage = initialMessages;
            InitializeView();




        }
        #endregion

        #region METHODS


        private void InitializeView()
        {
            UpdateAvailableTravelPoints();
            _currentLocationInformation = CurretLocation.description;
            _player.UpdateInventoryCategories();
            _player.calculatewealth();
        }


        public void AddItemToInventory()
        {
            //
            // confirm a game item selected and is in current location
            // subtract from location and add to inventory
            //
            if (_currentGameItem != null && _currentlocation.GameItems.Contains(_currentGameItem))
            {
                //
                // cast selected game item 
                //
                GameItemQuantity selectedGameItemQuantity = _currentGameItem as GameItemQuantity;

                _currentlocation.RemoveGameItemQuantityFromLocation(selectedGameItemQuantity);
                _player.AddGameItemQuantityToInventory(selectedGameItemQuantity);

                OnPlayerPickUp(selectedGameItemQuantity);
            }
        }
        public void RemoveItemFromInventory()
        {
            //
            // confirm a game item selected and is in inventory
            // subtract from inventory and add to location
            //
            if (_currentGameItem != null)
            {
                //
                // cast selected game item 
                //
                GameItemQuantity selectedGameItemQuantity = _currentGameItem as GameItemQuantity;

                _currentlocation.AddGameItemQuantityToLocation(selectedGameItemQuantity);
                _player.RemoveGameItemQuantityFromInventory(selectedGameItemQuantity);

                OnPlayerPutDown(selectedGameItemQuantity);
            }
        }

        private void OnPlayerPickUp(GameItemQuantity gameItemQuantity)
        {
            _player.ExperiencePoints += gameItemQuantity.GameItem.ExperiencePoints;
            _player.Wealth += gameItemQuantity.GameItem.Value;
            _player.UpdateMissionStatus();
        }

        private void OnPlayerPutDown(GameItemQuantity gameItemQuantity)
        {
            _player.Wealth -= gameItemQuantity.GameItem.Value;
            _player.UpdateMissionStatus();
        }

        public void OnUseGameItem()
        {


            if (_currentGameItem is Potion)
            {
                // ProcessPotionUse(potion);
            }
            else if (_currentGameItem is Allies)
            {
                // ProcessRelicUse(relic);
            }
        }

        private void processrelicuse(Allies allies)
        {
            //string message;
            //switch (allies.UseAction)
            //{
            //    case allies.use.openlocation:
            //        message = _gamemap.openlocationbyrelic(relic.id);
            //        currentlocationname = relic.usemessage;
            //        break;
            //    case allies.useactiontype.killplayer:
            //        playerdies(relic.usemessage);
            //        break;
            //    default:
            //        break;
            //}
        }

        private void OnPlayerDies(string message)
        {
            string messagetext = message + "\n\n Would you like to play again ";
            string titleText = "Death";

            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(message, titleText, button);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    ResetPlayer();
                    break;
                case MessageBoxResult.No:
                    QuiteApplication();
                    break;
            }
        }

        public void QuiteApplication()
        {
            Application.Current.Shutdown();
        }

        public void ResetPlayer()
        {
            Environment.Exit(0);


        }


        private void ProcessPotionUse(Potion potion)
        {
            _player.Health += potion.HealthChange;
            _player.Lives += potion.LivesChange;
            _player.RemoveGameItemQuantityFromInventory(_currentGameItem);
        }


        private void UpdateAvailableTravelPoints()
        {
            //
            // reset travel location information
            //
            NorthLocation = null;
            EastLocation = null;
            SouthLocation = null;
            WestLocation = null;

            //
            // north location exists
            //
            if (_gameMap.NorthLocation() != null)
            {
                Location nextNorthLocation = _gameMap.NorthLocation();

                //
                // location generally accessible or player has required conditions
                //
                if (nextNorthLocation.accessible == true || PlayerCanAccessLocation(nextNorthLocation))
                {
                    NorthLocation = nextNorthLocation;
                }
            }

            //
            // east location exists
            //
            if (_gameMap.EastLocation() != null)
            {
                Location nextEastLocation = _gameMap.EastLocation();

                //
                // location generally accessible or player has required conditions
                //
                if (nextEastLocation.accessible == true || PlayerCanAccessLocation(nextEastLocation))
                {
                    EastLocation = nextEastLocation;
                }
            }

            //
            // south location exists
            //
            if (_gameMap.SouthLocation() != null)
            {
                Location nextSouthLocation = _gameMap.SouthLocation();

                //
                // location generally accessible or player has required conditions
                //
                if (nextSouthLocation.accessible == true || PlayerCanAccessLocation(nextSouthLocation))
                {
                    SouthLocation = nextSouthLocation;
                }
            }

            //
            // west location exists
            //
            if (_gameMap.WestLocation() != null)
            {
                Location nextWestLocation = _gameMap.WestLocation();

                //
                // location generally accessible or player has required conditions
                //
                if (nextWestLocation.accessible == true || PlayerCanAccessLocation(nextWestLocation))
                {
                    WestLocation = nextWestLocation;
                }
            }
        }

        private bool PlayerCanAccessLocation(Location nextLocation)
        {
            //
            // check access by experience points
            //
            if (nextLocation.IsAccessibleByExperiencePoints(_player.ExperiencePoints))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void OnPlayerMove()
        {
            //
            // update player stats when in new location
            //
            if (!_player.HasVisited(_currentlocation))
            {
                //
                // add location to list of visited locations
                //
                _player.LocationsVisited.Add(_currentlocation);

                // 
                // update experience points
                //
                _player.ExperiencePoints += _currentlocation.modifyExperientsPoints;

                //
                // update health
                //
                _player.Health += _currentlocation.ModifyHealth;

                //
                // update lives
                //
                _player.Lives += _currentlocation.modifyLives;

                //
                // display a new message if available
                //
                OnPropertyChanged(nameof(MessageDisplay));
            }
        }

        public void MoveNorth()
        {
            if (HasNorthLocation)
            {
                _gameMap.MoveNorth();
                CurretLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
                _player.UpdateMissionStatus();
            }
        }

        /// <summary>
        /// travel east
        /// </summary>
        public void MoveEast()
        {
            if (HasEastLocation)
            {
                _gameMap.MoveEast();
                CurretLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
                _player.UpdateMissionStatus();
            }
        }

        /// <summary>
        /// travel south
        /// </summary>
        public void MoveSouth()
        {
            if (HasSouthLocation)
            {
                _gameMap.MoveSouth();
                CurretLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
                _player.UpdateMissionStatus();
            }
        }

        /// <summary>
        /// travel west
        /// </summary>
        public void MoveWest()
        {
            if (HasWestLocation)
            {
                _gameMap.MoveWest();
                CurretLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
                _player.UpdateMissionStatus();
            }
        }

        public Location CurrentLocation
        {
            get { return _currentlocation; }
            set
            {
                _currentlocation = value;
                _currentLocationInformation = _currentlocation.description;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }

        public void OnPlayerTalkTo()
        {
            if (CurrentNpc != null && CurrentNpc is ISpeak)
            {
                ISpeak speakingNpc = CurrentNpc as ISpeak;
                CurrentLocationInformation = speakingNpc.Speak();
                _player.NpcsEngaged.Add(_currentNpc);
                _player.UpdateMissionStatus();
            }
        }

        private BattleModeName NpcBattleResponse()
        {
            BattleModeName npcBattleResponse = BattleModeName.RETREAT;

            switch (DieRoll(3))
            {
                case 1:
                    npcBattleResponse = BattleModeName.ATTACK;
                    break;
                case 2:
                    npcBattleResponse = BattleModeName.DEFEND;
                    break;
                case 3:
                    npcBattleResponse = BattleModeName.RETREAT;
                    break;
            }
            return npcBattleResponse;
        }

        private int CalculatePlayerHitPoints()
        {
            int playerHitPoints = 0;

            switch (_player.BattleMode)
            {
                case BattleModeName.ATTACK:
                    playerHitPoints = _player.Attack();
                    break;
                case BattleModeName.DEFEND:
                    playerHitPoints = _player.Defend();
                    break;
                case BattleModeName.RETREAT:
                    playerHitPoints = _player.Retreat();
                    break;
            }

            return playerHitPoints;
        }

        private int CalculateNpcHitPoints(IBattle battleNpc)
        {
            int battleNpcHitPoints = 0;

            switch (NpcBattleResponse())
            {
                case BattleModeName.ATTACK:
                    battleNpcHitPoints = battleNpc.Attack();
                    break;
                case BattleModeName.DEFEND:
                    battleNpcHitPoints = battleNpc.Defend();
                    break;
                case BattleModeName.RETREAT:
                    battleNpcHitPoints = battleNpc.Retreat();
                    break;
            }

            return battleNpcHitPoints;
        }


        private void Battle()
        {
            //
            // check to see if an NPC can battle
            //
            if (_currentNpc is IBattle)
            {
                IBattle battleNpc = _currentNpc as IBattle;
                int playerHitPoints = 0;
                int battleNpcHitPoints = 0;
                string battleInformation = "";

                //
                // calculate hit points if the player and NPC have weapons
                //
                if (_player.CurrentWeapon != null)
                {
                    playerHitPoints = CalculatePlayerHitPoints();
                }
                else
                {
                    battleInformation = "It appears you are entering into battle without a weapon." + Environment.NewLine;
                }

                if (battleNpc.CurrentWeapon != null)
                {
                    battleNpcHitPoints = CalculateNpcHitPoints(battleNpc);
                }
                else
                {
                    battleInformation = $"It appears you are entering into battle with {_currentNpc.Name} who has no weapon." + Environment.NewLine;
                }

                //
                // build out the text for the current location information
                //
                battleInformation +=
                    $"Player: {_player.BattleMode}     Hit Points: {playerHitPoints}" + Environment.NewLine +
                    $"NPC: {battleNpc.BattleMode}     Hit Points: {battleNpcHitPoints}" + Environment.NewLine;

                //
                // determine results of battle
                //
                if (playerHitPoints >= battleNpcHitPoints)
                {
                    battleInformation += $"You have slain {_currentNpc.Name}.";
                    _currentlocation.Npcs.Remove(_currentNpc);
                }
                else
                {
                    battleInformation += $"You have been slain by {_currentNpc.Name}.";
                    _player.Lives--;
                }

                CurrentLocationInformation = battleInformation;
                if (_player.Lives <= 0) OnPlayerDies("You have been slain and have no lives left.");
            }
            else
            {
                CurrentLocationInformation = "The current NPC will is not battle ready. Seems you are a bit jumpy and your experience suffers.";
                _player.ExperiencePoints -= 10;
            }

        }
        private int DieRoll(int sides)
        {
            return random.Next(1, sides + 1);
        }

        public void OnPlayerAttack()
        {
            _player.BattleMode = BattleModeName.ATTACK;
            Battle();
            _player.NpcsEngaged.Add(_currentNpc);
            _player.UpdateMissionStatus();
        }

        /// <summary>
        /// handle the defend event in the view.
        /// </summary>
        public void OnPlayerDefend()
        {
            _player.BattleMode = BattleModeName.DEFEND;
            Battle();
            _player.NpcsEngaged.Add(_currentNpc);
            _player.UpdateMissionStatus();
        }

        /// <summary>
        /// handle the retreat event in the view.
        /// </summary>
        public void OnPlayerRetreat()
        {
            _player.BattleMode = BattleModeName.RETREAT;
            Battle();
            _player.NpcsEngaged.Add(_currentNpc);
            _player.UpdateMissionStatus();
        }

        public void AddNPCs()
        {
            if (_currentNpc != null)
            {
                if (_currentNpc.Name == "Alliser Thorne")
                {
                    _player.AddGameItemQuantityToInventory(new GameItemQuantity(GameItemById(1010), 3));
                    CurrentLocationInformation = "Heyy! \nYou got some weapons check them out";

                }
                else if (_currentNpc.Name == "Maester Aemon")
                {
                    _player.AddGameItemQuantityToInventory(new GameItemQuantity(GameItemById(3001), 4));
                    CurrentLocationInformation = "You got some Potions! \nhow do they look?";

                }
                else if (_currentNpc.Name == "Tormund Giantsbane")
                {
                    _player.AddGameItemQuantityToInventory(new GameItemQuantity(GameItemById(4001), 200));
                    //_currentlocation.XP += 20;
                    _player.ExperiencePoints += 20;
                    _player.Allies.Add(new GameItemQuantity(GameItemById(4001), 200));
                    CurrentLocationInformation = "HAHAHAHA! \nI am your ally now.";
                }
                else if (_currentNpc.Name == "Ramsay Bolton")
                {
                    _player.RemoveGameItemQuantityFromInventory(new GameItemQuantity(GameItemById(2003), 1));
                    CurrentLocationInformation = "HAHAHAHA! \nI am not going to join you.You dumb. HAHAHAHA...";
                }
                else if (_currentNpc.Name == "Roose Bolton")
                {
                    _player.RemoveGameItemQuantityFromInventory(new GameItemQuantity(GameItemById(2001), 20));
                    CurrentLocationInformation = "HAHAHAHA! \nI am going to join House Bolton.";
                }
                else if (_currentNpc.Name == "Walder Frey")
                {
                    _player.RemoveGameItemQuantityFromInventory(new GameItemQuantity(GameItemById(2003), 2));
                    CurrentLocationInformation = "I got your 2 Bronz, now you can use the bridge for the rest of the game.";
                }

                else if (_currentNpc.Name == "Jaime Lannister")
                {
                    _player.AddGameItemQuantityToInventory(new GameItemQuantity(GameItemById(4003), 500));
                    //                    _currentlocation.XP += 20;
                    _player.ExperiencePoints += 20;
                    _player.Allies.Add(new GameItemQuantity(GameItemById(4003), 500));
                    CurrentLocationInformation = "Yayy! \nI am your ally now.";
                }
                else if (_currentNpc.Name == "Cersei Lannister")
                {
                    _player.AddGameItemQuantityToInventory(new GameItemQuantity(GameItemById(1010), 10));
                    CurrentLocationInformation = "Here are your weapons.";
                    _player.RemoveGameItemQuantityFromInventory(new GameItemQuantity(GameItemById(2001), 3));
                    CurrentLocationInformation = "Heyy! \nYou got some weapons check them out";
                }
                else if (_currentNpc.Name == "Tyrion Lannister")
                {
                    _player.AddGameItemQuantityToInventory(new GameItemQuantity(GameItemById(3001), 100));
                    CurrentLocationInformation = "Here you go, have potions.";
                    _player.Potions.Add(new GameItemQuantity(GameItemById(3001), 100));
                }
                else if (_currentNpc.Name == "Robert Baratheon")
                {
                    _player.AddGameItemQuantityToInventory(new GameItemQuantity(GameItemById(1010), 5));
                    CurrentLocationInformation = "Here are your weapons.";
                    _player.AddGameItemQuantityToInventory(new GameItemQuantity(GameItemById(1010), 2));
                }
                else if (_currentNpc.Name == "Stannis Baratheon")
                {
                    _player.AddGameItemQuantityToInventory(new GameItemQuantity(GameItemById(4004), 200));
                    _currentlocation.XP += 20;
                    CurrentLocationInformation = "Yayy! \nWe are allies now.";
                }
                else if (_currentNpc.Name == "Arya Stark")
                {
                    _player.AddGameItemQuantityToInventory(new GameItemQuantity(GameItemById(1005), 200));
                    CurrentLocationInformation = "Here are your Needle weapon.";
                }
                else if (_currentNpc.Name == "Jon Snow")
                {
                    _player.AddGameItemQuantityToInventory(new GameItemQuantity(GameItemById(4005), 200));
                    _currentlocation.XP += 20;
                    _player.Allies.Add(new GameItemQuantity(GameItemById(4005), 200));
                    CurrentLocationInformation = "You are my ally now.";
                }
                else if (_currentNpc.Name == "Sansa Stark")
                {
                    _player.AddGameItemQuantityToInventory(new GameItemQuantity(GameItemById(1001), 200));
                    CurrentLocationInformation = "Yayy!\nYou got food.";
                }
                else if (_currentlocation.name == "Empty Space")
                {
                    if (_currentNpc.Name == "Bear")
                    {
                        int roll = DieRoll(6);
                        if (roll > 2)
                        {
                            _currentlocation.XP += 2;
                            CurrentLocationInformation = "Yayy!\nYou Killed Bear\nYou got 2xp";
                        }
                        else
                        {
                            _player.Health = _player.Health - 10;
                            CurrentLocationInformation = "Bear Killed you\nYou lost 10 life points";
                        }
                    }
                    else if (_currentNpc.Name == "Wolf")
                    {
                        int roll = DieRoll(6);
                        int roll2 = DieRoll(6);
                        roll = roll + roll2;
                        if (roll > 6)
                        {
                            _currentlocation.XP += 2;
                            CurrentLocationInformation = "Yayy!\nYou Killed Wolf\nYou got 2xp";
                        }
                        else
                        {
                            _player.Health = _player.Health - 10;
                            CurrentLocationInformation = "Wolf Killed you\nYou lost 10 life points";

                        }
                    }
                }
            }
        }
        private static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Weapon(1001, "Longbow", 5, 100, 10, "The valyrian steel sword from House Stark. Without this, you do not stand a chance of defeating the night king.", 10),
                new Weapon(1002, "Stick", 0, 1, 10, "You can find sticks anywhere and use then to fight off weak enemies, but they will break after one fight.", 1),
                new Weapon(1005, "Needle", 4, 1, 9, "Arya's sword. It is light and versatile, but not made out of valyarian steel. You can use this against people and animals.", 1),
                new Weapon(1010, "Common sword", 10, 10, 10, "A common sword you can use in battle.", 1),
                new Treasure(2001, "Gold Coin", 10, Treasure.TreasureType.Gold, "A gold coin", 5),
                new Treasure(2002, "Silver Coin", 5, Treasure.TreasureType.Gold, "A silver coin", 2),
                new Treasure(2003, "Bronze Coin", 1, Treasure.TreasureType.Gold, "A bronze coin", 1),
                new Potion(3001, "Health potion", 5, 40, 1, "Melissandre made you a potion to help you on your way again. Adds 20 points of health.", 5),
                new Allies(4001,"Alliser Thorne Allies",200,"Allies came from Alliser Thorne",2,"You got Allies from Alliser",Allies.UseActionType.AddXP),
                new Allies(4002,"Ramsay Bolton Allies",100,"Allies came from Ramsay Bolton",3,"You got Allies from Ramsay",Allies.UseActionType.AddXP),
                new Allies(4003,"Jaime Lannister Allies",500,"Allies came from Jaime Lannister",5,"You got Allies from Jaime",Allies.UseActionType.AddXP),
                new Allies(4004,"Stannis Baratheon Allies",200,"Allies came from Stannis Baratheon",5,"You got Allies from Stannis",Allies.UseActionType.AddXP),
                                 new Allies(4005,"Jon Snow Allies",200,"Jon came from Stannis Baratheon",5,"You got Allies from Jon",Allies.UseActionType.AddXP)

            };

        }
        private static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.id == id);
        }


        private string GenerateMissionTravelDetail(MissionTravel mission)
        {
            StringBuilder sb = new StringBuilder();
            sb.Clear();

            sb.AppendLine("All Required Locations");
            foreach (var location in mission.RequiredLocations)
            {
                sb.AppendLine(TAB + location.name);
            }
            if (mission.status == Mission.MissionStatus.Incomplete)
            {
                sb.AppendLine("Locations Yet to Visit");
                foreach (var location in mission.LocationsNotCompleted(_player.LocationsVisited))
                {
                    sb.AppendLine(TAB + location.name);
                }
            }

            sb.Remove(sb.Length - 2, 2);

            return sb.ToString();
        }
        private string GenerateMissionEngageDetail(MissionEngage mission)
        {
            StringBuilder sb = new StringBuilder();
            sb.Clear();

            sb.AppendLine("All Required NPCs");
            foreach (var location in mission.requiredNpcs)
            {
                sb.AppendLine(TAB + location.Name);
            }
            if (mission.status == Mission.MissionStatus.Incomplete)
            {
                sb.AppendLine("NPCs Yet to Engage");
                foreach (var location in mission.NpcsNotComp1eted(_player.NpcsEngaged))
                {
                    sb.AppendLine(TAB + location.Name);
                }
            }

            sb.Remove(sb.Length - 2, 2);

            return sb.ToString();
        }

        private string GenerateMissionGatherDetail(MissionGather mission)
        {
            StringBuilder sb = new StringBuilder();
            sb.Clear();

            sb.AppendLine("All Required Game Items (Quantity)");
            foreach (var gameItemQuatity in mission.RequiredGameItemQuantities)
            {
                sb.Append(TAB + gameItemQuatity.GameItem.Name);
                sb.AppendLine($" ( {gameItemQuatity.Quantity})");
            }
            if (mission.status == Mission.MissionStatus.Incomplete)
            {
                sb.AppendLine("Game Items Yet to Gather (Quantity)");
                foreach (var gameItemQuantity in mission.GameItemQuantitiesNotCompleted(_player.Inventory.ToList()))
                {
                    int quantityInInventory = 0;
                    GameItemQuantity gameItemQyantityGathered = _player.Inventory.FirstOrDefault(gi => gi.GameItem.id == gameItemQuantity.GameItem.id);
                    if (gameItemQyantityGathered != null)
                    {
                        quantityInInventory = gameItemQyantityGathered.Quantity;
                    }
                    sb.Append(TAB + gameItemQuantity.GameItem.Name);
                    sb.AppendLine($"({gameItemQuantity.Quantity - quantityInInventory})");
                }
            }

            sb.Remove(sb.Length - 2, 2);

            return sb.ToString();
        }

        private string GenerateMissionStatusInformation()
        {
            string missionStatusInformation;

            double totalMissions = _player.Missions.Count();
            double missionCompleted = _player.Missions.Where(m => m.status == Mission.MissionStatus.Complete).Count();

            int percentMissionsCompleted = (int)((missionCompleted / totalMissions) * 100);
            missionStatusInformation = $"Mission Complete: {percentMissionsCompleted }%" + NEW_LINE;

            if(percentMissionsCompleted==0)
            {
                missionStatusInformation += "Looks Like you are just starting out. No mission complete at the point and you better get on it";
            }
            else if(percentMissionsCompleted<=33)
            {
                missionStatusInformation += "Well, you have some of your missions complete, but this is just a start. You have your work cut out for you for sure.";
            }
            else if (percentMissionsCompleted <= 66)
            {
                missionStatusInformation += "You are making great progress with your missions. Keep at it.";
            }
            else if (percentMissionsCompleted == 100)
            {
                missionStatusInformation += "Congratulations, you have completed all your missions assigmed to you.";
            }

            return missionStatusInformation;
        }

        private MissionStatusViewModel InitializeMissionStatusViewModel()
        {
            MissionStatusViewModel missionStatusViewModel = new MissionStatusViewModel();
            missionStatusViewModel.MissionInformation = GenerateMissionStatusInformation();

            missionStatusViewModel.Missions = new List<Mission>(_player.Missions);

            foreach (var mission in missionStatusViewModel.Missions)
            {
                if (mission is MissionTravel)
                {
                    mission.statusDetails = GenerateMissionTravelDetail((MissionTravel)mission);
                }
                if (mission is MissionEngage)
                {
                    mission.statusDetails = GenerateMissionEngageDetail((MissionEngage)mission);
                }
                if (mission is MissionGather)
                {
                    mission.statusDetails = GenerateMissionGatherDetail((MissionGather)mission);
                }
            }
            return missionStatusViewModel;
        }
        public void OpenMissionStatusView()
        {
            MissionStatusView missionStatusView = new MissionStatusView(InitializeMissionStatusViewModel());

            missionStatusView.Show();
        }
        #endregion
    }
}
