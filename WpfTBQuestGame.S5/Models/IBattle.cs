using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTheAionProject.Models;

namespace WpfTheAionProject.Models
{
    public interface IBattle
    {
        int SkillLevel { get; set; }
        BattleModeName BattleMode { get; set; }
        Weapon CurrentWeapon { get; set; }


        //
        // methods to return hit point values (0 - 100) for each battle mode
        //
        int Attack();
        int Defend();
        int Retreat();
    }
}
