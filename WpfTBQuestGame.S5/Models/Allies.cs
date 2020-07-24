﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTheAionProject.Models
{
    public class Allies:GameItem
    {
        private UseActionType _useAction;
        public UseActionType UseAction { get { return _useAction; } set { _useAction = value; } }
        public enum UseActionType
        {
            AddXP,
        }

        public Allies(int id, string name, int value, string description, int experiencePoints, string useMessage, UseActionType useAction)
             : base(id, name, value, description, experiencePoints, useMessage)
        {
            UseAction = useAction;
        }
        public override string InformationString()
        {
            return $"{Name}: {Description}\nValue: {Value}";
        }
    }
}
