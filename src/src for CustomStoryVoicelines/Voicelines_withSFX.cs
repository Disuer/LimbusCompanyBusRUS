using FMOD;
using FMOD.Studio;
using FMODUnity;
using HarmonyLib;
using MainUI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace LimbusCompanyModding
{
    public class Voicelines : MonoBehaviour
    {
        //1D101A-02 : 1D101A
        //LCB_CresCorpMod.LogInfo($"{name} : {storyID}");
        public static List<string> localizedStory = new();
        public static float overallVolume;
        public static ChannelGroup storyGroup;
        public static ChannelGroup skillGroup;
        public static ChannelGroup announcerGroup;
        public static ChannelGroup sfxGroup;
        //[HarmonyPatch(typeof(VoiceGenerator), nameof(VoiceGenerator.CreateVoiceInstance))]
        //[HarmonyPrefix]
        //private static bool CreateVoiceInstance(string path, bool isSpecial)
        //{
        //    LCB_ConfMod.LogInfo(path);
        //    string pathus = $"{LCB_ConfMod.ModPath}\\Voicelines\\{path.Substring(7)}.wav";
        //    FMOD.RESULT result = RuntimeManager.CoreSystem.createSound(pathus, FMOD.MODE.CREATESTREAM, out FMOD.Sound sound);
        //    stopAllGroups();
        //    if (result == FMOD.RESULT.OK)
        //    {
        //        switch (path)
        //        {
        //            case string when path.StartsWith("event:/Voice/"):
        //                generalTuning(skillGroup, sound);
        //                break;
        //            case string when path.StartsWith("event:/Voice_Story/"):
        //                generalTuning(storyGroup, sound);
        //                break;
        //            case string when path.StartsWith("event:/BattleAnnouncer/"):
        //                generalTuning(announcerGroup, sound);
        //                break;
        //        }
        //        return false;
        //    }
        //    return true;
        //}
        [HarmonyPatch(typeof(RuntimeManager), nameof(RuntimeManager.CreateInstance), new Type[] { typeof(GUID) })]
        [HarmonyPrefix]
        private static bool RuntimeManager2_Instance(RuntimeManager __instance, ref GUID guid)
        {
            RuntimeManager.StudioSystem.lookupPath(guid, out string path);
            LCB_ConfMod.LogInfo(path);
            string pathus = $"{LCB_ConfMod.ModPath}\\Voicelines\\{path.Substring(7)}.wav";
            FMOD.RESULT result = RuntimeManager.CoreSystem.createSound(pathus, FMOD.MODE.CREATESTREAM, out FMOD.Sound sound);
            switch (path)
            {
                case string when path.StartsWith("event:/Voice/"):
                    skillGroup.stop();
                    break;
                case string when path.StartsWith("event:/Voice_Story/"):
                    storyGroup.stop();
                    break;
                case string when path.StartsWith("event:/BattleAnnouncer/"):
                    announcerGroup.stop();
                    break;
            }
            if (result == FMOD.RESULT.OK)
            {
                switch (path)
                {
                    case string when path.StartsWith("event:/Voice/"):
                        generalTuning(skillGroup, sound);
                        break;
                    case string when path.StartsWith("event:/Voice_Story/"):
                        generalTuning(storyGroup, sound);
                        break;
                    case string when path.StartsWith("event:/BattleAnnouncer/"):
                        generalTuning(announcerGroup, sound);
                        break;
                    case string when path.StartsWith("event:/SFX/"):
                        generalTuning(sfxGroup, sound);
                        break;
                }
                return false;
            }
            return true;
        }
        public static void generalTuning(ChannelGroup group, FMOD.Sound sound)
        {
            group.setVolume(overallVolume);
            sound.setMusicChannelVolume(1, overallVolume);
            RuntimeManager.CoreSystem.playSound(sound, group, false, out _);
        }
        [HarmonyPatch(typeof(SettingsPanelSounds), nameof(SettingsPanelSounds.RefreshVolumes))]
        [HarmonyPostfix]
        private static void SettingsPanelSounds_Init(SettingsPanelSounds __instance)
        {
            overallVolume = __instance._voiceVolume * __instance._masterVolume;
        }
        [HarmonyPatch(typeof(GlobalGameManager), nameof(GlobalGameManager.Start))]
        [HarmonyPostfix]
        private static void GlobalGameManager_Start(GlobalGameManager __instance)
        {
            RuntimeManager.CoreSystem.createChannelGroup("Story", out storyGroup);
            RuntimeManager.CoreSystem.createChannelGroup("Skill", out skillGroup);
            RuntimeManager.CoreSystem.createChannelGroup("Announcer", out announcerGroup);
            RuntimeManager.CoreSystem.createChannelGroup("SFX", out sfxGroup);
        }
        [HarmonyPatch(typeof(GlobalGameManager), nameof(GlobalGameManager.OnApplicationQuit))]
        [HarmonyPostfix]
        private static void GlobalGameManager_Quit1(GlobalGameManager __instance)
        {
            storyGroup.release();
            skillGroup.release();
            announcerGroup.release();
            sfxGroup.release();
        }
        [HarmonyPatch(typeof(GlobalGameManager), nameof(GlobalGameManager.QuitGame))]
        [HarmonyPostfix]
        private static void GlobalGameManager_Quit(GlobalGameManager __instance)
        {
            storyGroup.release();
            skillGroup.release();
            announcerGroup.release();
            sfxGroup.release();
        }
    }
}
