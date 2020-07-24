using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTheAionProject.Models;
using System.Collections.ObjectModel;

namespace WpfTheAionProject.DataLayer
{
    public class GameData
    {
              public static Player PlayerData()
        {
            return new Player()
            {
                Id = 1,
                Name = "Dany",
                Army = Player.ArmyName.Targaryen,
                House = Character.HouseName.Targaryan,
                Health = 100,
                Lives = 3,
                ExperiencePoints = 0,
                Locationid = 0,
                SkillLevel = 5,
                Inventory = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1002), 1),
                    new GameItemQuantity(GameItemById(2001), 5),
                    new GameItemQuantity(GameItemById(2003), 2)
                },
                Missions=new ObservableCollection<Mission>()
                {
                    MissionById(1),
                    MissionById(2),
                    MissionById(3)
                },
            };
        }
        public static string InitialMessages()
        {
            return  "Winter is coming! The Night King is making his way to the wall!"+
                "Make your way through Westeros to gather supplies and allies!"+
                "And remember: Valar Morghulis!";
        }

        public static GameMapCoordinates InitialGameMapLocation()
        {
            return new GameMapCoordinates() { Row = 7, Column = 0 };
        }

        private static Npc NpcById(int id)
        {
            return Npcs().FirstOrDefault(i => i.Id == id);
        }

        public static Map GameMap()
        {

            int rows = 8;
            int columns = 3;

            Map gameMap = new Map(rows, columns);

            gameMap.MapLocation[0,0] = new Location()
            {
                id = 00,
                name = "The Wall",
                description = "Nights' Watch",
                accessible = true,
                modifyExperientsPoints = 10,
                Message = "If you go north here, you will have to face the Night King which can kill you if you do not have enough allies or weapons",
                XCORD =0,
                YCORD=0,
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1001),1),
                                        new GameItemQuantity(GameItemById(3001),1),
                                        new GameItemQuantity(GameItemById(4001),200)
                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(2001),
                    NpcById(2002),
                    NpcById(2003)
                }
                
            };
            gameMap.MapLocation[0, 1] = new Location()
            {
                id = 01,
                name = "The Wall",
                description = "Nights' Watch",
                accessible = true,
                modifyExperientsPoints = 10,
                Message = "If you go north here, you will have to face the Night King which can kill you if you do not have enough allies or weapons",
                XCORD = 0,
                YCORD = 1,
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1001),1),
                                        new GameItemQuantity(GameItemById(3001),1),
                                                                                new GameItemQuantity(GameItemById(4001),200)

                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(2001),
                    NpcById(2002),
                    NpcById(2003)
                }
            };
            gameMap.MapLocation[0, 2] = new Location()
            {
                id = 02,
                name = "The Wall",
                description = "Nights' Watch",
                accessible = true,
                modifyExperientsPoints = 10,
                Message = "If you go north here, you will have to face the Night King which can kill you if you do not have enough allies or weapons",
                XCORD = 0,
                YCORD = 2,
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1001),1),
                                        new GameItemQuantity(GameItemById(3001),1),
                                                                                new GameItemQuantity(GameItemById(4001),200)

                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(2001),
                    NpcById(2002),
                    NpcById(2003)
                }
            };

            gameMap.MapLocation[1, 0] = new Location()
            {
                id = 10,
                name = "Not Accessible Location",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = false,
                modifyExperientsPoints = 10,
                Message = "This location is not accessible",
                XCORD = 1,
                YCORD = 0,
              

            };
            gameMap.MapLocation[1, 1] = new Location()
            {
                id = 11,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                Message = "Be aware of wolfs and bears",
                modifyExperientsPoints = 10,
                XCORD = 1,
                YCORD = 1,
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1002),5),
                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(3001),
                     NpcById(3002),

                }

            };

            gameMap.MapLocation[1, 2] = new Location()
            {
                id = 12,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
                Message = "Be aware of wolfs and bears",
                XCORD = 1,
                YCORD = 2,
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1002),5),
                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(3001),
                     NpcById(3003),

                }

            };
            gameMap.MapLocation[2, 0] = new Location()
            {
                id = 20,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 50,
                modifyLives = -1,
                requiredExperientsPoints = 40,
                Message = "Be aware of wolfs and bears",
                XCORD = 2,
                YCORD = 0,
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1002),5),
                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(3005),
                     NpcById(3004),
                }
            };

            gameMap.MapLocation[2, 1] = new Location()
            {
                id = 21,
                name = "Dreadfort",
                description = "House Bolton, chance to gather supplies or allies",
                accessible = true,
                modifyExperientsPoints = 20,
                ModifyHealth = 50,
                Message = "Traveler, our telemetry places you at the Xantoria Market. We have reports of local health potions.",
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(2001),20),
                                                            new GameItemQuantity(GameItemById(4001),100)

                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(2004),
                    NpcById(2005),
                }
            };
            gameMap.MapLocation[2, 2] = new Location()
            {
                id = 22,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
                Message = "Be aware of wolfs and bears",
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1002),5),
                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(3003),
                     NpcById(3005),
                }
            };

            gameMap.MapLocation[3, 0] = new Location()
            {
                id = 30,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
                Message = "Be aware of wolfs and bears",
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1002),5),
                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(3001),
                     NpcById(3002),
                     NpcById(3005),
                }

            };

            gameMap.MapLocation[3, 1] = new Location()
            {
                id = 31,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
                Message = "Be aware of wolfs and bears",
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1002),5),
                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(3003),
                     NpcById(3004),
                }
            };

            gameMap.MapLocation[3, 2] = new Location()
            {
                id = 32,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
                Message = "Be aware of wolfs and bears",
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1002),5),
                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(3001),
                     NpcById(3002),
                       NpcById(3005),
                }
            };

            gameMap.MapLocation[4, 0] = new Location()
            {
                id = 40,
                name = "Winterfell",
                description = "This is House Stark",
                accessible = true,
                modifyExperientsPoints = 10,
                Message= "Winterfell is the capital of the Kingdom of the North and the seat and the ancestral home of the royal House Stark.",
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(4002), 1),
                    new GameItemQuantity(GameItemById(01), 10),
                    new GameItemQuantity(GameItemById(23), 10)
                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(2006),
                    NpcById(2007),
                     NpcById(2008)
                }
            };

            gameMap.MapLocation[4, 1] = new Location()
            {
                id = 41,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
                Message = "Be aware of wolfs and bears",
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1002),5),
                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(3001),
                     NpcById(3002),
                       NpcById(3003)
                },
            };

            gameMap.MapLocation[4, 2] = new Location()
            {
                id = 42,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
                Message = "Be aware of wolfs and bears",
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1002),5),
                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(3001),
                     NpcById(3002),
                       NpcById(3005)
                },

            };

            gameMap.MapLocation[5, 0] = new Location()
            {
                id = 50,
                name = "Location Not Accessible",
                description = "This location is not accessible",
                accessible = false,
            };


            gameMap.MapLocation[5, 1] = new Location()
            {
                id = 51,
                name = "The Twins",
                description = "House Frey, you have to pay to pass",
                accessible = true,
                modifyExperientsPoints = 10,
                Message= "The Twins, known as the Crossing, is the seat of House Frey in the northern riverlands, \none of the most formidable strongholds of the Seven Kingdoms.",
                 GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(2003), 2)
                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(1001)
                },
            };

            gameMap.MapLocation[5, 2] = new Location()
            {
                id = 52,
                name = "Location Not Accessible",
                description = "This location is not accessible",
                accessible = false,
            };

            gameMap.MapLocation[6, 0] = new Location()
            {
                id = 60,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
                Message = "Be aware of wolfs and bears",
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1002),5)
                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(3003),
                     NpcById(3002),
                       NpcById(3004)
                },

            };

            gameMap.MapLocation[6, 1] = new Location()
            {
                id = 61,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
                Message = "Be aware of wolfs and bears",
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1002),5)
                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(3001),
                       NpcById(3005)
                },
            };

            gameMap.MapLocation[6, 2] = new Location()
            {
                id = 62,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
                Message = "Be aware of wolfs and bears",
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1002),5)
                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(3004),
                     NpcById(3002),
                       NpcById(3005)
                },

            };

            gameMap.MapLocation[7, 0] = new Location()
            {
                id = 70,
                name = "Casterly Rock",
                description = "Ancestral stronghold of House Lannister, Gather supplies or allies",
                accessible = true,
                modifyExperientsPoints = 10,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(2001), 1),
                    new GameItemQuantity(GameItemById(3001), 1),
                    new GameItemQuantity(GameItemById(4003), 500)
                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(2010),
                    NpcById(2011),
                    NpcById(2012)
                },
            };

            gameMap.MapLocation[7, 1] = new Location()
            {
                id = 71,
                name = "Empty Space",
                description = "Empty Space Where Player might run into wolf or other danger",
                accessible = true,
                modifyExperientsPoints = 10,
                Message = "Be aware of wolfs and bears",
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1002),5)
                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(3001),
                     NpcById(3004),
                       NpcById(3003)
                },
            };

            gameMap.MapLocation[7, 2] = new Location()
            {
                id = 72,
                name = "Storm's end",
                description = "House Barethon, gather supplies or allies",
                accessible = true,
                modifyExperientsPoints = 10,
                Message= "The ancestral seat of House Baratheon, it lies just inland of Shipbreaker Bay and is one of the most impenetrable castles in the series.",
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1001), 10),
                    new GameItemQuantity(GameItemById(1002), 10),
                     new GameItemQuantity(GameItemById(1010), 10),
                     new GameItemQuantity(GameItemById(4004),200)

                },
                 Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(2013),
                    NpcById(2014)
                },
            };

            return gameMap;
        }

        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Weapon(1001, "Longbow", 1000, 100, 10, "The valyrian steel sword from House Stark. Without this, you do not stand a chance of defeating the night king.", 10),
                new Weapon(1002, "Stick", 0, 1, 10, "You can find sticks anywhere and use then to fight off weak enemies, but they will break after one fight.", 1),
                new Weapon(1005, "Needle", 250, 1, 9, "Arya's sword. It is light and versatile, but not made out of valyarian steel. You can use this against people and animals.", 1),
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
        public static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.id == id);
        }
        public static List<Npc> Npcs()
        {
            return new List<Npc>()
            {
                new Military()
                {
                    Id = 2001,
                    Name = "Alliser Thorne",
                    House = Character.HouseName.Thorne,
                    Description = "Alliser Thorne is the Master-at-Arms at Castle Black and is responsible for training new recruits to the Night's Watch",
                    Messages = new List<string>()
                    {
                        "We can trade common swords"
                    },
                   SkillLevel = 4,
                   CurrentWeapon = GameItemById(1010) as Weapon
                },

                 new Military()
                {
                    Id = 2002,
                    Name = "Maester Aemon",
                    House = Character.HouseName.Targaryan,
                    Description = "Maester Aemon is the maester at Castle Black and one of Lord Commander Jeor Mormont's closest advisers in the Night's Watch.",
                    Messages = new List<string>()
                    {
                            "I can give you potions for free."
                    },
                   SkillLevel = 2,
                   CurrentWeapon = GameItemById(1002) as Weapon
                },

                   new Military()
                {
                    Id = 2003,
                    Name = "Tormund Giantsbane",
                    House = Character.HouseName.Targaryan,
                    Description = "Tormund Giantsbane, is a renowned warrior and raider among ... agree to join Jon and Sansa's campaign to recapture Winterfell for House Stark",
                    Messages = new List<string>()
                    {
                            "I can join your quest and can add more ally wildlings."
                    },
                   SkillLevel = 2,
                   CurrentWeapon = GameItemById(1003) as Weapon
                },
                 new Military()
                {
                    Id = 2004,
                    Name = "Ramsay Bolton",
                    House = Character.HouseName.Bolton,
                    Description = "Lord of the Dreadfort and the head of House Bolton, the former ruling Great House of the North after usurping the position from House Stark",
                    Messages = new List<string>()
                    {
                            "I will join you only if you give me your treasure."
                    },
                   SkillLevel = 4,
                },
                   new Military()
                {
                    Id = 2005,
                    Name = "Roose Bolton",
                    House = Character.HouseName.Bolton,
                    Description = "Head of House Bolton, the former ruling Great House of the North after usurping the position from House Stark.",
                    Messages = new List<string>()
                    {
                         "I will join you only if you give me 20 gold coins."
                    },
                   SkillLevel = 4,
                },
                 new Military()
                {
                    Id = 2006,
                    Name = "Arya Stark",
                    House = Character.HouseName.Stark,
                    Description = "",
                    Messages = new List<string>()
                    {
                         "I will give my sword, Needle. Remember to stick them with the pointy end."
                    },
                   SkillLevel = 4,
                   CurrentWeapon = GameItemById(1005) as Weapon
                },
                   new Military()
                {
                    Id = 2007,
                    Name = "Jon Snow",
                    House = Character.HouseName.Stark,
                    Description = "",
                    Messages = new List<string>()
                    {
                         "I will join you as an ally, adding 200 people as allies for House Stark and 20xp."
                    },
                   SkillLevel = 4,
                   CurrentWeapon = GameItemById(1005) as Weapon
                },
                     new Military()
                {
                    Id = 2008,
                    Name = "Sansa Stark",
                    House = Character.HouseName.Stark,
                    Description = "",
                    Messages = new List<string>()
                    {
                         "I will give you food and you do not have to pay for it."
                    },
                   SkillLevel = 4,
                },
                new Military()
                {
                    Id = 2010,
                    Name = "Jaime Lannister",
                    House = Character.HouseName.Lannister,
                    Description = "Eldest son of Tywin Lannister. With Cersei's ascension to the Iron Throne, Jaime was appointed as the new commander of the Lannister armies but left the position",
                    Messages = new List<string>()
                    {
                         "I will join your quest with the Lannister army, adding 20xp and 500 people"
                    },
                   SkillLevel = 4,
                },
                    new Military()
                {
                    Id = 2011,
                    Name = "Cersei Lannister",
                    House = Character.HouseName.Lannister,
                    Description = " Widow of King Robert Baratheon and Queen of the Seven Kingdoms. She is the daughter of Lord Tywin Lannister, twin sister of Jaime Lannister and elder sister of Tyrion Lannister.",
                    Messages = new List<string>()
                    {
                         "I will trade you allies, food or weapons in return for gold, if you are ready."
                    },
                   SkillLevel = 4,
                },
                      new Military()
                {
                    Id = 2012,
                    Name = "Tyrion Lannister ",
                    House = Character.HouseName.Lannister,
                    Description = "Tyrion Lannister is the youngest child of Lord Tywin Lannister and younger brother of Cersei and Jaime Lannister",
                    Messages = new List<string>()
                    {
                         "I am not a fighter, but I will share my knowledge which will add to your knowledge. I have potions for you as well."
                    },
                   SkillLevel = 4,
                  
                },
                  new Military()
                {
                    Id = 2013,
                    Name = "Robert Baratheon",
                    House = Character.HouseName.Baratheon,
                    Description = "Robert I Baratheon was the ruler of the Seven Kingdoms. He took the throne through conquest in the war known as Robert's Rebellion",
                    Messages = new List<string>()
                    {
                         "I will give you food and weapons"
                    },
                   SkillLevel = 4,

                },
                   new Military()
                {
                    Id = 2014,
                    Name = "Stannis Baratheon",
                    House = Character.HouseName.Baratheon,
                    Description = "King Stannis I Baratheon was the Lord of Dragonstone, the younger brother of King Robert Baratheon and older brother of Renly Baratheon.",
                    Messages = new List<string>()
                    {
                         "I will join your quest with the Baratheon army adding 200 people and 20xp"
                    },
                   SkillLevel = 4,

                },
                   new Citizen()
                {
                    Id = 1001,
                    Name = "Walder Frey",
                    House = Character.HouseName.Targaryan,
                    Description = "The Lord of the Crossing and head of House Frey",
                    Messages = new List<string>()
                    {
                         "You can use this bridge only if you pay me 2 bronze coins."
                    },
                },
                  new Animals()
                {
                    Id = 3001,
                    Name = "Bear",
                    House = Character.HouseName.None,
                    Description = "You come across a bear! You can try to sneak away or attack it.",
                    Messages = new List<string>()
                    {
                         "You will need one die and have to roll more than 2"
                    },
                    Type="Wild"
                },
                   new Animals()
                {
                    Id = 3002,
                    Name = "Wolf",
                    House = Character.HouseName.None,
                    Description = "Oh no, a wolf! Do you attack or try to run?",
                    Messages = new List<string>()
                    {
                         "You will need more than 6 on 2 dice"
                    },
                    Type="Wild"
                },
                      new Animals()
                {
                    Id = 3003,
                    Name = "Bear",
                    House = Character.HouseName.None,
                    Description = "You come across a bear! You can try to sneak away or attack it.",
                    Messages = new List<string>()
                    {
                         "You will need one die and have to roll more than 2"
                    },
                    Type="Wild"
                },
                   new Animals()
                {
                    Id = 3004,
                    Name = "Wolf",
                    House = Character.HouseName.None,
                    Description = "Oh no, a wolf! Do you attack or try to run?",
                    Messages = new List<string>()
                    {
                         "You will need more than 6 on 2 dice"
                    },
                    Type="Wild"
                },
                     new Animals()
                {
                    Id = 3005,
                    Name = "Bear",
                    House = Character.HouseName.None,
                    Description = "You come across a bear! You can try to sneak away or attack it.",
                    Messages = new List<string>()
                    {
                         "You will need one die and have to roll more than 2"
                    },
                    Type="Wild"
                }, 
            };
        }

        public static List<Mission> Missions()
        {
            return new List<Mission>()
            {
                new MissionTravel()
                {
                    id=1,
                    name="Scouting",
                    description="Explore all locations and gather all information possible",
                    status=Mission.MissionStatus.Incomplete,
                    RequiredLocations=new List<Location>()
                    {
                        LocationById(72),
                        LocationById(51)
                    },
                    experiencePoints=100
                },
                 new MissionGather()
                {
                    id=2,
                    name="Collecting",
                    description="Locate and collect all required objects",
                    status=Mission.MissionStatus.Incomplete,
                    RequiredGameItemQuantities=new List<GameItemQuantity>()
                    {
                        new GameItemQuantity(GameItemById(1001),2),
                    },
                    experiencePoints=50
                },
                  new MissionEngage()
                {
                    id=3,
                    name="Enage Mission need to have certain npcs",
                    description="Engage your mission now",
                    status=Mission.MissionStatus.Incomplete,
                    requiredNpcs=new List<Npc>()
                    {
                        NpcById(2001),
                        NpcById(2004),
                        NpcById(2007),
                        NpcById(2010),
                        NpcById(2014),
                    },
                    experiencePoints=50
                },
            };
        }
        private static Location LocationById(int id)
        {
            List<Location> locations = new List<Location>();
            foreach(Location location in GameMap().MapLocation)
            {
                if(location!=null)
                {
                    locations.Add(location);
                }
            }
            return locations.FirstOrDefault(i => i.id == id);
        }
        private static Mission MissionById(int id)
        {
            return Missions().FirstOrDefault(m => m.id == id);
        }
    }
}