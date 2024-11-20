using HarmonyLib;
using Il2CppInterop.Runtime.Injection;
using MainUI;
using MainUI.Gacha;
using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using ILObject = Il2CppSystem.Object;
using UObject = UnityEngine.Object;

namespace LimbusLocalize
{
    public class LLC_Manager : MonoBehaviour
    {
        static LLC_Manager()
        {
            ClassInjector.RegisterTypeInIl2Cpp<LLC_Manager>();
            GameObject obj = new(nameof(LLC_Manager));
            DontDestroyOnLoad(obj);
            obj.hideFlags |= HideFlags.HideAndDontSave;
            Instance = obj.AddComponent<LLC_Manager>();
        }
        public static LLC_Manager Instance;

        void OnApplicationQuit() => LCB_LLCMod.CopyLog();
        
        public static void InitLocalizes(DirectoryInfo directory)
        {
            foreach (FileInfo fileInfo in directory.GetFiles())
            {
                var value = File.ReadAllText(fileInfo.FullName);
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileInfo.FullName);
                Localizes[fileNameWithoutExtension] = value;
            }
            foreach (DirectoryInfo directoryInfo in directory.GetDirectories())
            {
                InitLocalizes(directoryInfo);
            }

        }
        public static Dictionary<string, string> Localizes = new();
        public static Action FatalErrorAction;
        public static string FatalErrorlog;
        #region 屏蔽没有意义的Warning
        [HarmonyPatch(typeof(Logger), nameof(Logger.Log), new Type[]
        {
            typeof(LogType),
            typeof(ILObject)
        })]
        [HarmonyPrefix]
        private static bool Log(Logger __instance, LogType logType, ILObject message)
        {
            if (logType == LogType.Warning)
            {
                string LogString = Logger.GetString(message);
                if (!LogString.StartsWith("<color=#0099bc><b>DOTWEEN"))
                    __instance.logHandler.LogFormat(logType, null, "{0}", LogString);
                return false;
            }
            return true;
        }
        [HarmonyPatch(typeof(Logger), nameof(Logger.Log), new Type[]
        {
            typeof(LogType),
            typeof(ILObject),
            typeof(UObject)
        })]
        [HarmonyPrefix]
        private static bool Log(Logger __instance, LogType logType, ILObject message, UObject context)
        {
            if (logType == LogType.Warning)
            {
                string LogString = Logger.GetString(message);
                if (!LogString.StartsWith("Material"))
                    __instance.logHandler.LogFormat(logType, context, "{0}", LogString);
                return false;
            }
            return true;
        }
        #endregion
        #region 修复一些弱智东西
        [HarmonyPatch(typeof(GachaEffectEventSystem), nameof(GachaEffectEventSystem.LinkToCrackPosition))]
        [HarmonyPrefix]
        private static bool LinkToCrackPosition(GachaEffectEventSystem __instance)
            => __instance._parent.EffectChainCamera;
        #endregion
    }
}
