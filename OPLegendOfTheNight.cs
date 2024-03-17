using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using OPLegendOfTheNight;


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

        public override void OnApplicationStart()
        {
            MelonLogger.Msg(System.ConsoleColor.DarkMagenta, "OP Legend Of The Night Loaded.");
        }
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
