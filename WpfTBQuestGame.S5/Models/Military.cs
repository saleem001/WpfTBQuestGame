﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTheAionProject.Models
{
    public class Military : Npc, ISpeak, IBattle
    {
        Random r = new Random();

        private const int DEFENDER_DAMAGE_ADJUSTMENT = 10;
        private const int MAXIMUM_RETREAT_DAMAGE = 10;

        public List<string> Messages { get; set; }
        public int SkillLevel { get; set; }
        public BattleModeName BattleMode { get; set; }
        public Weapon CurrentWeapon { get; set; }
        //public Potion CurrentPotion { get; set; }
        //public Treasure CurrentTreasure { get; set; }


        protected override string InformationText()
        {
            return $"{Name} - {Description}";
        }

        public Military()
        {

        }

        public Military(
            int id,
            string name,
            int locationid,
            HouseName house,
            string description,
            List<string> messages,
            int skillLevel,
            Weapon currentWeapon)
            : base(id, name, house, description)
        {
            Messages = messages;
            SkillLevel = skillLevel;
            CurrentWeapon = currentWeapon;
        }

        /// <summary>
        /// generate a message or use default
        /// </summary>
        /// <returns>message text</returns>
        public string Speak()
        {
            if (Messages != null)
            {
                return GetMessage();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// randomly select a message from the list of messages
        /// </summary>
        /// <returns>message text</returns>
        private string GetMessage()
        {
            int messageIndex = r.Next(0, Messages.Count());
            return Messages[messageIndex];
        }

        #region BATTLE METHODS

        /// <summary>
        /// return hit points [0 - 100] based on the NPCs weapon and skill level
        /// </summary>
        /// <returns>hit points 0-100</returns>
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

        #endregion

    }
}
