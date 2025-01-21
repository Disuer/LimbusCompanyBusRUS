using FMOD;
using FMOD.Studio;
using FMODUnity;
using HarmonyLib;
using LimbusLocalizeRUS;
using LocalSave;
using MainUI;
using StorySystem;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace LimbusCompanyBusRUS
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
        [HarmonyPatch(typeof(VoiceGenerator), nameof(VoiceGenerator.CreateVoiceInstance))]
        [HarmonyPrefix]
        private static bool CreateVoiceInstance(string path, bool isSpecial)
        {
            LCB_CresCorpMod.LogInfo($"{path} : {isSpecial}");
            string pathus = $"{LCB_CresCorpMod.ModPath}\\Voicelines\\{path.Substring(7)}.wav";
            FMOD.RESULT result = RuntimeManager.CoreSystem.createSound(pathus, FMOD.MODE.CREATESTREAM, out FMOD.Sound sound);
            stopAllGroups();
            if (result == FMOD.RESULT.OK)
            {
                switch (path)
                {
                    case string when path.StartsWith("event:/Voice/"):
                        generalTuning(skillGroup, sound);
                        //skillGroup.stop();
                        //skillGroup.setVolume(overallVolume);
                        //sound.setMusicChannelVolume(1, overallVolume);
                        //RuntimeManager.CoreSystem.playSound(sound, skillGroup, false, out _);
                        break;
                    case string when path.StartsWith("event:/Voice_Story/"):
                        generalTuning(storyGroup, sound);
                        //storyGroup.stop();
                        //storyGroup.setVolume(overallVolume);
                        //sound.setMusicChannelVolume(1, overallVolume);
                        //RuntimeManager.CoreSystem.playSound(sound, storyGroup, false, out _);
                        break;
                    case string when path.StartsWith("event:/BattleAnnouncer/"):
                        generalTuning(announcerGroup, sound);
                        //announcerGroup.stop();
                        //announcerGroup.setVolume(overallVolume);
                        //sound.setMusicChannelVolume(1, overallVolume);
                        //RuntimeManager.CoreSystem.playSound(sound, announcerGroup, false, out _);
                        break;
                }
                return false;
            }
            return true;
        }
        public static void stopAllGroups()
        {
            skillGroup.stop();
            storyGroup.stop();
            announcerGroup.stop();
        }
        public static void generalTuning(ChannelGroup group, FMOD.Sound sound)
        {
            group.stop();
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
        }
        [HarmonyPatch(typeof(GlobalGameManager), nameof(GlobalGameManager.OnApplicationQuit))]
        [HarmonyPostfix]
        private static void GlobalGameManager_Quit1(GlobalGameManager __instance)
        {
            storyGroup.release();
            skillGroup.release();
            announcerGroup.release();
        }
        [HarmonyPatch(typeof(GlobalGameManager), nameof(GlobalGameManager.QuitGame))]
        [HarmonyPostfix]
        private static void GlobalGameManager_Quit(GlobalGameManager __instance)
        {
            storyGroup.release();
            skillGroup.release();
            announcerGroup.release();
        }
        //[HarmonyPatch(typeof(LoadingSceneManager), nameof(LoadingSceneManager.SetHintText))]
        //[HarmonyPrefix]
        //private static void LoadingSceneManager_Init(LoadingSceneManager __instance)
        //{
        //    RuntimeManager.CoreSystem.getMasterChannelGroup(out var group);
        //    group.stop();
        //}
    }
}
