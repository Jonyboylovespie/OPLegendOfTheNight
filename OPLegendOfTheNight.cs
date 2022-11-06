using Assets.Scripts.Models;
using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Mods;
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.TowerFilters;
using Assets.Scripts.Models.Towers.Weapons;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Display;
using Assets.Scripts.Utils;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Harmony;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using OPLegendOfTheNight;
using UnhollowerBaseLib;
using Il2CppSystem.Collections.Generic;


[assembly: MelonInfo(typeof(OPLegendOfTheNightMod), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace OPLegendOfTheNight
{
    public class OPLegendOfTheNightMod : BloonsTD6Mod
    {

        private static readonly ModSettingInt LegendOfTheNight = new(200000)
        {
            displayName = "Legend Of The Night Cost",
            min = 0
        };

        public override void OnNewGameModel(GameModel gameModel, Il2CppSystem.Collections.Generic.List<ModModel> mods)
        {
            gameModel.GetUpgrade(UpgradeType.LegendOfTheNight).cost = CostHelper.CostForDifficulty(LegendOfTheNight, mods);

            foreach (var towerModel in gameModel.towers)
            {
                if (towerModel.appliedUpgrades.Contains(UpgradeType.LegendOfTheNight))
                {
                    towerModel.GetBehavior<AbilityModel>().cooldown = 0.00000000001f;
                }
            }
        }
    }
}
