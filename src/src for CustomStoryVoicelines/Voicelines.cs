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
        public static float voiceVolume;
        public static float masterVolume;
        public static ChannelGroup channelGroup;
        [HarmonyPatch(typeof(VoiceGenerator), nameof(VoiceGenerator.CreateVoiceInstance))]
        [HarmonyPrefix]
        private static bool CreateVoiceInstance(string path, bool isSpecial)
        {
            LCB_CresCorpMod.LogInfo($"{path} : {isSpecial}");
            string pathus = $"{LCB_CresCorpMod.ModPath}\\Voicelines\\{path.Substring(7)}.wav";
            LCB_CresCorpMod.LogInfo(pathus);
            FMOD.RESULT result = RuntimeManager.CoreSystem.createSound(pathus, FMOD.MODE.CREATESTREAM, out FMOD.Sound sound);
            if (result == FMOD.RESULT.OK)
            {
                VoiceGenerator.StopVoiceSound();
                float overallVolume = masterVolume * voiceVolume;
                channelGroup.stop();
                channelGroup.setVolume(overallVolume);
                RuntimeManager.CoreSystem.playSound(sound, channelGroup, false, out FMOD.Channel channel);
                sound.setMusicChannelVolume(1, overallVolume);
                channel.setVolume(overallVolume);
                return false;
            }
            return true;
        }
        [HarmonyPatch(typeof(LoadingSceneManager), nameof(LoadingSceneManager.SetHintText))]
        [HarmonyPrefix]
        private static void LoadingSceneManager_Init14(LoadingSceneManager __instance)
        {
            RuntimeManager.CoreSystem.createChannelGroup("123", out channelGroup);
            RuntimeManager.CoreSystem.getMasterChannelGroup(out var group);
            group.stop();
        }
        [HarmonyPatch(typeof(SettingsPanelSounds), nameof(SettingsPanelSounds.RefreshVolumes))]
        [HarmonyPostfix]
        private static void SettingsPanelSounds124_Init(SettingsPanelSounds __instance)
        {
            voiceVolume = __instance._voiceVolume;
            masterVolume = __instance._masterVolume;
        }
    }
}
