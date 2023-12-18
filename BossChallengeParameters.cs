using System;
using BossChallengeParameters;

using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.UI.Modded;
using Il2Cpp;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.ServerEvents;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.Main.DifficultySelect;
using Il2CppAssets.Scripts.Unity.UI_New.Main.ModeSelect;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using Il2CppSystem.Threading.Tasks;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(BossChallengeParametersMod), "yes", "1.0", "eh44")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace BossChallengeParameters;

public class BossChallengeParametersMod : BloonsTD6Mod
{
    public static float BossHealth = 1;
    public static float BossSpeed = 1;
    public static int StartingCash = 650;
    public static String[] DifficultyArray = {
        "Easy", "Medium", "Hard"
    };

    public static String Difficulty = "Medium";
    public static int Lives = 200;
    public static float BloonSpeed = 1;
    public static float MoabHealth = 1;
    public static float MoabSpeed = 1;
    public static float AbilityCooldown = 1;
    
   

    // Not really much point in making these settings lol, people would just abuse it even more. make it 300 at some point lol
  
    private static readonly ModSettingHotkey CashCustom = new(KeyCode.F8)
    {
        displayName = "Custom Starting Cash HotKey"
    };
    private static readonly ModSettingHotkey DifficultyCustom = new(KeyCode.F9)
    {
        displayName = "Custom Difficulty HotKey"
    };
    private static readonly ModSettingHotkey BossHealthCustom = new(KeyCode.F6)
    {
        displayName = "Custom Boss Health HotKey"
    };
    private static readonly ModSettingHotkey BossSpeedCustom = new(KeyCode.F7)
    {
        displayName = "Custom Boss Speed HotKey"
    };
    private static readonly ModSettingHotkey LivesCustom = new(KeyCode.F10)
    {
        displayName = "Custom Lives HotKey"
    };
    private static readonly ModSettingHotkey BloonSpeedCustom = new(KeyCode.F11)
    {
        displayName = "Custom Bloon Speed HotKey"
    };
    private static readonly ModSettingHotkey MoabHealthCustom = new(KeyCode.F12)
    {
        displayName = "Custom Moab Health HotKey"
    };
    private static readonly ModSettingHotkey MoabSpeedCustom = new(KeyCode.Insert)
    {
        displayName = "Custom Moab Speed HotKey"
    };
    private static readonly ModSettingHotkey AbilityCooldownCustom = new(KeyCode.Delete)
    {
        displayName = "Custom Ability Cooldown HotKey"
    };
    
    public override void OnUpdate()
    {
        if (BossHealthCustom.JustPressed())
        {
            PopupScreen.instance.ShowSetValuePopup("Custom Boss Health",
                "Sets the Boss Health to the specified percentage of health",
                new Action<int>(i =>
                {   Console.WriteLine();
                    if (i <= 1)
                    {
                        i = 1;
                    }
                    BossHealth = (float)i/100;
                }), (int) BossHealth*100);
        }
        if (BossSpeedCustom.JustPressed())
        {
            PopupScreen.instance.ShowSetValuePopup("Custom Boss Speed",
                "Sets the Boss speed to the specified percentage of speed",
                new Action<int>(i =>
                {
                    if (i <= 1)
                    {
                        i = 1;
                    }

                    BossSpeed = (float)i/100;
                }), (int) BossSpeed*100);
        }
        if (DifficultyCustom.JustPressed())
        {
            PopupScreen.instance.ShowSetValuePopup("Custom Difficulty",
                "Sets the difficulty with numbers: 0 for easy, 1 for medium, and 2 for hard",
                new Action<int>(i =>
                {
                    if (i < 0)
                    {
                        i = 0;
                    }

                    if (i > 2)
                    {
                        i = 2;
                    }   

                    Difficulty = DifficultyArray[i];
                }), 1);
        }
        if (CashCustom.JustPressed())
        {
            PopupScreen.instance.ShowSetValuePopup("Custom Starting Cash",
                "Sets the Starting Cash",
                new Action<int>(i =>
                {
                    if (i <= 1)
                    {
                        i = 1;
                    }

                    StartingCash = i;
                }), StartingCash);
        }
        if (BloonSpeedCustom.JustPressed())
        {
            PopupScreen.instance.ShowSetValuePopup("Custom Bloon Speed",
                "Sets the bloon speed to the specified percentage of speed",
                new Action<int>(i =>
                {
                    if (i <= 1)
                    {
                        i = 1;
                    }

                    BloonSpeed = (float)i/100;
                }), (int) BloonSpeed*100);
        }
        if (MoabSpeedCustom.JustPressed())
        {
            PopupScreen.instance.ShowSetValuePopup("Custom Moab Speed",
                "Sets the Moab speed to the specified percentage of speed",
                new Action<int>(i =>
                {
                    if (i <= 1)
                    {
                        i = 1;
                    }

                    MoabSpeed = (float)i/100;
                }), (int) MoabSpeed*100);
        }
        if (MoabHealthCustom.JustPressed())
        {
            PopupScreen.instance.ShowSetValuePopup("Custom Moab Health",
                "Sets the Moab health to the specified percentage of health",
                new Action<int>(i =>
                {
                    if (i <= 1)
                    {
                        i = 1;
                    }

                    MoabHealth = (float)i/100;
                }), (int) MoabHealth*100);
        }
        if (LivesCustom.JustPressed())
        {
            PopupScreen.instance.ShowSetValuePopup("Custom Lives",
                "Sets the starting lives",
                new Action<int>(i =>
                {
                    if (i <= 1)
                    {
                        i = 1;
                    }

                    Lives = i;
                }), Lives);
        }
        if (AbilityCooldownCustom.JustPressed())
        {
            PopupScreen.instance.ShowSetValuePopup("Custom Ability Cooldown",
                "Sets ability cooldowns to the specified percentage",
                new Action<int>(i =>
                {
                    if (i <= 1)
                    {
                        i = 1;
                    }

                    AbilityCooldown = (float)i/100;
                }), (int) AbilityCooldown*100);
        }
        if (MenuManager.instance == null) return;

      

       
    }
}