using System;
using BossChallengeParameters;

using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(BossChallengeParametersMod), "Parameters", "1.0", "eh44")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace BossChallengeParameters;

public class BossChallengeParametersMod : BloonsTD6Mod
{
    private static readonly String[] DifficultyArray = {
        "Easy", "Medium", "Hard"
    };

    private static readonly String[] Modes =
    {
        "Standard", "HalfCash", "Clicks", "Impoppable", "Deflation", "Apopalypse", "Sandbox"
    };

    public static String Mode { get; private set; } = "Standard";
    public static float BossHealth { get; private set; } = 1;
    public static float BossSpeed { get; private set; } = 1;
    public static int StartingCash { get; private set; } = 650;
    public static String Difficulty { get; private set; } = "Medium";
    public static int Lives { get; private set; } = 200;
    public static float BloonSpeed { get; private set; } = 1;
    public static float MoabHealth { get; private set; } = 1;
    public static float MoabSpeed { get; private set; } = 1;
    public static float AbilityCooldown { get; private set; } = 1;
  
    private static readonly ModSettingHotkey CashCustom = new(KeyCode.F8)
    {
        displayName = "Custom Starting Cash HotKey"
    };
    private static readonly ModSettingHotkey ModeCustom = new(KeyCode.Backspace)
    {
        displayName = "Custom Mode Hotkey"
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
                }), (int) (BossHealth*100));
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
                }), (int) (BossSpeed*100));
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
        
        if (ModeCustom.JustPressed())
        {
            PopupScreen.instance.ShowSetValuePopup("Custom Mode",
                "Sets the difficulty with numbers: 0 for standard, 1 for half cash, 2 for chimps, 3 for impoppable, 4 for deflation, 5 for apopalypse, and 6 for sandbox",
                new Action<int>(i =>
                {
                    if (i < 0)
                    {
                        i = 0;
                    }

                    if (i > 6)
                    {
                        i = 6;
                    }   

                    Mode = Modes[i];
                }), 0);
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
                }), (int) (BloonSpeed*100));
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
                }), (int) (MoabSpeed*100));
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
                }), (int) (MoabHealth*100));
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
