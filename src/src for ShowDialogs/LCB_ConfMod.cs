using BepInEx;
using BepInEx.Unity.IL2CPP;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace LimbusModss
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class LCB_ConfMod : BasePlugin
    {
        public static string ModPath;
        public static string GamePath;
        public const string GUID = "Com.Disaer.ShowDialogs";
        public const string NAME = "LMods.ShowDialogs";
        public const string VERSION = "0.0.1";
        public const string AUTHOR = $"Base: Bright\n\t\t\t    Edit: Disaer";
        public static Action<string, Action> LogFatalError { get; set; }
        public static Action<string> LogInfo { get; set; }
        public static Action<string> LogError { get; set; }
        public static Action<string> LogWarning { get; set; }
        public static void OpenGamePath() => Application.OpenURL(GamePath);
        public override void Load()
        {
            LogInfo = (string log) => { Log.LogInfo(log); Debug.Log(log); };
            LogError = (string log) => { Log.LogError(log); Debug.LogError(log); };
            ModPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            GamePath = new DirectoryInfo(Application.dataPath).Parent.FullName;
            LogError(AUTHOR);
            try
            {
                HarmonyLib.Harmony harmony = new(NAME);
                harmony.PatchAll(typeof(LCB_Voice));
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
