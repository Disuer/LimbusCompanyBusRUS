using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using Il2CppSystem.Threading;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using UnityEngine;
using UnityEngine.Networking;

namespace LimbusMods
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class LCB_ConfMod : BasePlugin
    {
        public static string ModPath;
        public static string GamePath;
        public const string GUID = "Com.Disaer.NicknamesNoBanners";
        public const string NAME = "LMods.NicknamesNoBanners";
        public const string VERSION = "0.0.1";
        public const string AUTHOR = "Base: Bright\n\t\t\t\t   Edit: Disaer";
        public static Action<string, Action> LogFatalError { get; set; }
        public static Action<string> LogInfo { get; set; }
        public static Action<string> LogError { get; set; }
        public static Action<string> LogWarning { get; set; }
        public static string my_uri = "https://raw.githubusercontent.com/Disuer/LimbusCompanyBusRUS/master_ilcpp/src/userid.json";
        public static void OpenGamePath() => Application.OpenURL(GamePath);
        public override void Load()
        {
            LogInfo = (string log) => { Log.LogInfo(log); Debug.Log(log); };
            LogError = (string log) => { Log.LogError(log); Debug.LogError(log); };
            LogWarning = (string log) => { Log.LogWarning(log); Debug.LogWarning(log); };
            ModPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            GamePath = new DirectoryInfo(Application.dataPath).Parent.FullName;
            string filename = ModPath + "/userid.json";
            LogError(AUTHOR);
            UnityWebRequest www = UnityWebRequest.Get(my_uri);
            www.timeout = 4;
            www.SendWebRequest();
            while (!www.isDone)
                Thread.Sleep(100);
            if (!File.Exists(filename))
            {
                DownloadFileAsync(my_uri, filename);
            }
            LCB_Text.checkmyjson();
            try
            {
                HarmonyLib.Harmony harmony = new(NAME);
                harmony.PatchAll(typeof(LCB_Text));
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
        public static void DownloadFileAsync(string uri, string filePath)
        {
            try
            {
                using HttpClient client = new();
                using HttpResponseMessage response = client.GetAsync(uri).GetAwaiter().GetResult();
                using HttpContent content = response.Content;
                using FileStream fileStream = new(filePath, FileMode.Create);
                content.CopyToAsync(fileStream).GetAwaiter().GetResult();
                LogWarning("!!!IDS DOWNLOADED!!!");
            }
            catch (System.Exception ex)
            {
                if (ex is HttpRequestException httpException && httpException.StatusCode == HttpStatusCode.NotFound)
                    LogWarning($"{uri} 404 NotFound");
                else
                    LogWarning($"{uri} Error!!!" + ex.ToString());
            }
        }
    }
}
