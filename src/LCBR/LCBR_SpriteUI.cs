using System.Runtime.InteropServices;
using HarmonyLib;
using BattleUI;
using BattleUI.Typo;
using MainUI;
using MainUI.VendingMachine;
using Login;
using UI;
using static UI.Utility.InfoModels;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using StorySystem;

namespace LimbusLocalizeRUS
{
    public static class LCBR_SpriteUI
    {
        #region Combo
        [HarmonyPatch(typeof(ParryingTypoUI), nameof(ParryingTypoUI.SetParryingTypoData))]
        [HarmonyPostfix]
        private static void ParryingTypoUI_Init(ParryingTypoUI __instance)
        {
            GameObject combo = GameObject.Find("[Prefab]ParryingTypo(Clone)/[Rect]Pivot/[Fixed,Image]ParryingText");
            if (combo != null)
            {
                combo.GetComponent<Image>().sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_Combo"];
            }
            __instance.img_parryingTypo.sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_Combo"];
        }
        #endregion

        #region Login
        /*
        [HarmonyPatch(typeof(LoginSceneManager), nameof(LoginSceneManager.OnInitLoginInfoManagerEnd))]
        [HarmonyPostfix]
        private static void LoginSceneManager_Init(LoginSceneManager __instance)
        {
            __instance.img_touchToStart.sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_Start"];
            Transform motto = __instance.transform.Find("[Canvas]/[Image]RedLine/[Image]Phrase");
            if (motto != null)
            {
                motto.GetComponentInChildren<Image>(true).sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_Motto_Season3"];
            }
        }
        */
        #endregion

        #region Main Menu
        [HarmonyPatch(typeof(LowerControlUIPanel), nameof(LowerControlUIPanel.Initialize))]
        [HarmonyPostfix]
        private static void LunacyTag_Init(LowerControlUIPanel __instance)
        {
            Transform lunacyTag = __instance.transform.Find("[Rect]Pivot/[Rect]UserInfoUI/[Rect]Info/[Button]CurrencyInfo/[Image]CashTag");
            if (lunacyTag != null)
            {
                lunacyTag.GetComponentInChildren<Image>(true).sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_LunacyTag"];
            }
        }
        #endregion

        #region Vending Machine
        [HarmonyPatch(typeof(VendingMachineUIPanel), nameof(VendingMachineUIPanel.Initialize))]
        [HarmonyPostfix]
        private static void VendingMachineUIPanel_Init(VendingMachineUIPanel __instance)
        {
            Transform soldOut = __instance.transform.Find("GoodsStoreAreaMaster/GoodsStorePanelGroup/BackPanel/Main/SoldOut");
            if (soldOut != null)
            {
                soldOut.GetComponentInChildren<Image>(true).sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_SoldOut"];
            }
        }
        #endregion

        #region Formation UI
        [HarmonyPatch(typeof(FormationSwitchablePersonalityUIPanel), nameof(FormationSwitchablePersonalityUIPanel.Initialize))]
        [HarmonyPostfix]
        private static void ParticipateSlot_Init(FormationSwitchablePersonalityUIPanel __instance)
        {
            Transform slot = __instance.transform.Find("[Script]FormationSwitchablePersonalityScrollView/Viewport/Content/[Layout]Items/PersonalitySwitchableSlot/[Image]ParticipateSlotUI");
            Transform slot_1 = __instance.transform.Find("[Script]FormationSwitchablePersonalityScrollView/Viewport/Content/[Layout]Items/PersonalitySwitchableSlot (1)/[Image]ParticipateSlotUI");
            Transform slot_2 = __instance.transform.Find("[Script]FormationSwitchablePersonalityScrollView/Viewport/Content/[Layout]Items/PersonalitySwitchableSlot (2)/[Image]ParticipateSlotUI");
            Transform slot_3 = __instance.transform.Find("[Script]FormationSwitchablePersonalityScrollView/Viewport/Content/[Layout]Items/PersonalitySwitchableSlot (3)/[Image]ParticipateSlotUI");
            Transform slot_4 = __instance.transform.Find("[Script]FormationSwitchablePersonalityScrollView/Viewport/Content/[Layout]Items/PersonalitySwitchableSlot (4)/[Image]ParticipateSlotUI");
            Transform slot_5 = __instance.transform.Find("[Script]FormationSwitchablePersonalityScrollView/Viewport/Content/[Layout]Items/PersonalitySwitchableSlot (5)/[Image]ParticipateSlotUI");
            Transform slot_6 = __instance.transform.Find("[Script]FormationSwitchablePersonalityScrollView/Viewport/Content/[Layout]Items/PersonalitySwitchableSlot (6)/[Image]ParticipateSlotUI");
            Transform slot_7 = __instance.transform.Find("[Script]FormationSwitchablePersonalityScrollView/Viewport/Content/[Layout]Items/PersonalitySwitchableSlot (7)/[Image]ParticipateSlotUI");
            Transform slot_8 = __instance.transform.Find("[Script]FormationSwitchablePersonalityScrollView/Viewport/Content/[Layout]Items/PersonalitySwitchableSlot (8)/[Image]ParticipateSlotUI");
            if (slot != null)
            {
                slot.GetComponentInChildren<Image>(true).sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_InParty"];
                slot_1.GetComponentInChildren<Image>(true).sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_InParty"];
                slot_2.GetComponentInChildren<Image>(true).sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_InParty"];
                slot_3.GetComponentInChildren<Image>(true).sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_InParty"];
                slot_4.GetComponentInChildren<Image>(true).sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_InParty"];
                slot_5.GetComponentInChildren<Image>(true).sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_InParty"];
                slot_6.GetComponentInChildren<Image>(true).sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_InParty"];
                slot_7.GetComponentInChildren<Image>(true).sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_InParty"];
                slot_8.GetComponentInChildren<Image>(true).sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_InParty"];
            }
        }
        #endregion

        #region Battle UI
        [HarmonyPatch(typeof(BattleUIRoot), nameof(BattleUIRoot.Init))]
        [HarmonyPostfix]
        private static void WaveUI_Init(BattleUIRoot __instance)
        {
            Transform waveUI = __instance.transform.Find("[Canvas]PerspectiveUI/SafeArea/[Script]WaveUI/[Rect]Pivot/[Image]WavePanel");
            Transform turnUI = __instance.transform.Find("[Canvas]PerspectiveUI/SafeArea/[Script]WaveUI/[Rect]Pivot/[Image]TurnPanel");
            if (waveUI != null)
            {
                waveUI.GetComponentInChildren<Image>(true).sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_WaveUI"];
                waveUI.GetComponentInChildren<Image>(true).m_Sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_WaveUI"];
                waveUI.GetComponentInChildren<Image>(true).overrideSprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_WaveUI"];
            }
            if (turnUI != null)
            {
                turnUI.GetComponentInChildren<Image>(true).sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_TurnUI"];
                turnUI.GetComponentInChildren<Image>(true).m_Sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_TurnUI"];
                turnUI.GetComponentInChildren<Image>(true).overrideSprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_TurnUI"];
            }
        }
        #endregion

        #region Skip Button
        [HarmonyPatch(typeof(GachaResultUI), nameof(GachaResultUI.Initialize))]
        [HarmonyPostfix]
        private static void SkipGacha_Init(GachaResultUI __instance)
        {
            Transform skip_gacha = __instance.transform.Find("[Rect]GetNewCardRoot/[Button]Skip");
            if (skip_gacha != null)
            {
                skip_gacha.GetComponentInChildren<Image>(true).sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_Skip"];
            }
        }

        [HarmonyPatch(typeof(BattleUIRoot), nameof(BattleUIRoot.Init))]
        [HarmonyPostfix]
        private static void BattleUIRoot_Init(BattleUIRoot __instance)
        {
            GameObject start = GameObject.Find("[Script]BattleUIRoot/[Canvas,Script]BattleUIController/SafeArea/[Script]NewOperationController/[Rect]ActiveControl/[Rect]Pivot/[Rect]ActionableSlotList/[Layout]SinActionSlotsGrid/[EventTrigger]EndButton/[Image]RightLeg/[Rect]StartUI/[Rect]Pivot/[Image]Start");
            if (start != null)
            {
                start.GetComponentInChildren<Image>(true).name = "СТАРТ";
            }
        }
        [HarmonyPatch(typeof(StoryManager), nameof(StoryManager.Init))]
        [HarmonyPostfix]
        private static void StoryManager_Init(StoryManager __instance)
        {
            GameObject auto = GameObject.Find("StoryManager/[Rect]NonPostProcessCanvas/[Rect]Buttons/[Rect]MenuObject/[Button]Auto");
            if (auto != null)
            {
                auto.GetComponentInChildren<Image>(true).sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_Auto"];
                auto.GetComponentInChildren<StoryUIButton>(true)._buttonImageList[0] = LCBR_ReadmeManager.ReadmeSprites["LCBR_Auto"];
                auto.GetComponentInChildren<StoryUIButton>(true)._buttonImageList[1] = LCBR_ReadmeManager.ReadmeSprites["LCBR_AutoH"];
                auto.GetComponentInChildren<StoryUIButton>(true)._buttonImageList[2] = LCBR_ReadmeManager.ReadmeSprites["LCBR_Text"];
            }
        }
        #endregion
    }
}
