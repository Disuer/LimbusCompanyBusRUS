using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using StorySystem;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using System.Diagnostics.Tracing;
using BepInEx.Logging;
using System.Threading.Tasks;

namespace LimbusMods
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class LCB_ConfMod : BasePlugin
    {
        public static ConfigFile LCB_Settings;
        public static string ModPath;
        public static string GamePath;
        public const string GUID = "Com.Bright.LocalizeLimbusCompany";
        public const string NAME = "LMods.Nicknames&NoBanners";
        public const string VERSION = "0.0.1";
        public const string AUTHOR = "Base: Bright\n\t\t\t\t    Modded: Disaer";
        public static Action<string, Action> LogFatalError { get; set; }
        public static Action<string> LogInfo { get; set; }
        public static Action<string> LogError { get; set; }
        public static Action<string> LogWarning { get; set; }
        public static void OpenGamePath() => Application.OpenURL(GamePath);
        public override void Load()
        {
            LCB_Settings = Config;
            LogInfo = (string log) => { Log.LogInfo(log); Debug.Log(log); };
            LogError = (string log) => { Log.LogError(log); Debug.LogError(log); };
            LogWarning = (string log) => { Log.LogWarning(log); Debug.LogWarning(log); };
            ModPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            GamePath = new DirectoryInfo(Application.dataPath).Parent.FullName;
            LogInfo(AUTHOR);
            LCB_Text.downloadAsync();
            LCB_Text.checkmyjson();
            try
            {
                HarmonyLib.Harmony harmony = new(NAME);
                    harmony.PatchAll(typeof(LCB_Text));
            }
            catch (Exception e)
            {
                LogFatalError("ERROR.CENSORED.ERROR.CENSORED.ERROR.CENSORED.ERROR.CENSORED.ERROR.CENSORED.ERROR.CENSORED.", () => { CopyLog(); OpenGamePath(); });
                LogFatalError("==============================CONTACT: DISAER (DISCORD)===================================", () => { CopyLog(); OpenGamePath(); });
                LogFatalError("ERROR.CENSORED.ERROR.CENSORED.ERROR.CENSORED.ERROR.CENSORED.ERROR.CENSORED.ERROR.CENSORED.", () => { CopyLog(); OpenGamePath(); });
                LogError(e.ToString());
            }
        }
        public static void CopyLog()
        {
            File.Copy(GamePath + "/BepInEx/LogOutput.log", GamePath + "/Latest.log", true);
            File.Copy(Application.consoleLogPath, GamePath + "/Player.log", true);
        }
    }
}
