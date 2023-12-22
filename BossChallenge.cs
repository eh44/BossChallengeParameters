using HarmonyLib;
using Il2CppAssets.Scripts.Models.Difficulty;
using Il2CppAssets.Scripts.Models.ServerEvents;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;



namespace BossChallengeParameters
{
    [HarmonyPatch(typeof(InGameData), nameof(InGameData.SetupBossChallenge))]
    internal static class SetupBossChallengePatch
    {
        [HarmonyPrefix]
        private static void Prefix(ref DailyChallengeModel dcm)
        {
            
            if (dcm != null)
            {
                dcm.chalType = ChallengeType.CustomMapPlay;
                dcm.mode =  BossChallengeParametersMod.Mode;
                dcm.bloonModifiers.speedMultiplier = BossChallengeParametersMod.BloonSpeed;
                dcm.bloonModifiers.moabSpeedMultiplier =  BossChallengeParametersMod.MoabSpeed;
                dcm.bloonModifiers.healthMultipliers.moabs =  BossChallengeParametersMod.MoabHealth;
                dcm.bloonModifiers.healthMultipliers.boss =  BossChallengeParametersMod.BossHealth;
                dcm.bloonModifiers.bossSpeedMultiplier = BossChallengeParametersMod.BossSpeed;
                dcm.difficulty =  BossChallengeParametersMod.Difficulty;
                dcm.startRules.lives = BossChallengeParametersMod.Lives;
                dcm.startRules.cash = BossChallengeParametersMod.StartingCash;
                dcm.abilityCooldownReductionMultiplier = BossChallengeParametersMod.AbilityCooldown;
            }              
        }
    }
}
