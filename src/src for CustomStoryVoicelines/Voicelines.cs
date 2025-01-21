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
        //PlayBasicVoice, PlayLoginVoice, PlayLobbyVoice, PlayLobbyVoice, GetLobbyVoice, PlaySmallTalkVoice, PlayNeglectVoice, PlayFormationVoice, PlayGetVoice
        //PlayGacksungVoice, PlayBattleEntryVoice, PlayBattleStartStageVoice, PlayBattleSelectVoice, PlayBattleBreakVoice, PlayBattleAllyDeadVoice, PlayBattleDeadVoice
        //PlayBattleEnemyBreakVoice, PlayBattleKillVoice, PlayBattleEndCommandVoice, PlaySkillVoice, PlayBattleLoseduelVoice, PlayChoiceSucceesPossitiveVoice, PlayChoiceSucceesNegativeVoice
        //PlayChoiceFailPossitiveVoice, PlayChoiceFailNegativeVoice, PlayBattleClearEXVoice, PlayBattleClearVoice, PlayBattleDefeatVoice, PlaySpecialVoice, PlayEGOAwakenVoice, PlayEGOErosionVoice
        //PlayAnnouncerBasicVoice, PlayAnnouncerEquipVoice, PlayAnnouncerAdvAtkPhysicalVoice, PlayAnnouncerAdvAtkAttrVoice, PlayAnnouncerDisadvAtkPhysicalVoice, PlayAnnouncerDisdvAtkAttrVoice
        [HarmonyPatch(typeof(LoadingSceneManager), nameof(LoadingSceneManager.SetHintText))]
        [HarmonyPrefix]
        private static void LoadingSceneManager_Init14(LoadingSceneManager __instance)
        {
            RuntimeManager.CoreSystem.createChannelGroup("123", out channelGroup);
            RuntimeManager.CoreSystem.getMasterChannelGroup(out var group);
            group.stop();
        }
        [HarmonyPatch(typeof(StorySoundController), nameof(StorySoundController.CallVoice))]
        [HarmonyPostfix]
        public static void StorySoundController2(StorySoundController __instance, ref string code, ref string storyID)
        {
            string name = Regex.Replace(code, "\\s", "").Split(':', StringSplitOptions.None)[0];
            if (code.Contains(storyID[..2]))
            {
                PlayStoryVoice_Custom(name, storyID);
                return;
            }
            PlayStoryVoice_Custom(name, null);
        }
        public static void PlayStoryVoice_Custom(string name, string storyID)
        {
            VoiceGenerator.StopVoiceSound();
            if (storyID != null)
            {
                if (localizedStory.Contains(storyID))
                {
                    FMOD.RESULT result = RuntimeManager.CoreSystem.createSound(LCB_CresCorpMod.GamePath + $"\\LimbusCompany_Data\\Voicelines\\1D101A\\{name}.wav", FMOD.MODE.DEFAULT, out FMOD.Sound sound);
                    if (result == FMOD.RESULT.OK)
                    {
                        float overallVolume = masterVolume * voiceVolume;
                        channelGroup.stop();
                        channelGroup.setVolume(overallVolume);
                        RuntimeManager.CoreSystem.playSound(sound, channelGroup, false, out FMOD.Channel channel);
                        sound.setMusicChannelVolume(1, overallVolume);
                        channel.setVolume(overallVolume);
                    }
                }
                else
                {
                    VoiceGenerator.SetMainVoice(VoiceGenerator.CreateVoiceInstance(VoiceGenerator.VOICE_STORY_EVENT_PATH + storyID + "/" + name, false), -1);
                }
                return;
            }
            VoiceGenerator.SetMainVoice(VoiceGenerator.CreateVoiceInstance(VoiceGenerator.VOICE_EVENT_PATH + "Default/" + name, false), -1);
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
