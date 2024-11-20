using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace LimbusLocalize
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class LCB_LLCMod : BasePlugin
    {
        public static string ModPath;
        public static string GamePath;
        public const string GUID = "Com.Disaer.NOTLocalize";
        public const string NAME = "NOTLocalize";
        public const string VERSION = "0.0.1";
        public const string AUTHOR = "Bright\n\t\t\tEdit: Disaer";
        public static Action<string, Action> LogFatalError { get; set; }
        public static Action<string> LogError { get; set; }
        public static Action<string> LogWarning { get; set; }
        public static void OpenGamePath() => Application.OpenURL(GamePath);
        public override void Load()
        {
            LogError = (string log) => { Log.LogError(log); Debug.LogError(log); };
            LogWarning = (string log) => { Log.LogWarning(log); Debug.LogWarning(log); };
            ModPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            GamePath = new DirectoryInfo(Application.dataPath).Parent.FullName;
            try
            {
                Harmony harmony = new(NAME);
                LLC_Manager.InitLocalizes(new DirectoryInfo(ModPath + "/EN"));
                harmony.PatchAll(typeof(LCB_Chinese_Font));
                harmony.PatchAll(typeof(LLC_Manager));
            }
            catch (Exception e)
            {
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
