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
using Dungeon.Mirror;
using BattleUI.BattleUnit;
using BattleUI.Operation;
using TMPro;
using UnityEngine.Playables;
using UtilityUI;
using System.Collections.Generic;
using MainUI.Gacha;
using Dungeon.Shop;

namespace LimbusLocalizeRUS
{
    public static class LCBR_SpriteUI
    {
        #region Combo
        [HarmonyPatch(typeof(ParryingTypoUI), nameof(ParryingTypoUI.SetParryingTypoData))]
        [HarmonyPrefix]
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
        [HarmonyPatch(typeof(LoginSceneManager), nameof(LoginSceneManager.OnInitLoginInfoManagerEnd))]
        [HarmonyPostfix]
        private static void LoginSceneManager_Init(LoginSceneManager __instance)
        {
            __instance.img_touchToStart.sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_Start"];
            Transform motto = __instance.transform.Find("[Canvas]/[Image]RedLine/[Image]Phrase");
            if (motto != null)
            {
                motto.GetComponentInChildren<Image>(true).sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_Motto"];
            }
        }
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
        #endregion

        #region Dungeon Formation UI
        [HarmonyPatch(typeof(FormationPersonalityUI), nameof(FormationPersonalityUI.SetData))]
        [HarmonyPostfix]
        private static void Support_Init(FormationPersonalityUI __instance)
        {
            __instance.img_isParticipaged.sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_InParty"];
            __instance.img_support.sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_SupportTag"];
        }
        #endregion

        #region Support Formation UI
        #endregion

        #region Mirror Dungeon
        [HarmonyPatch(typeof(EgoGiftCategorySetUIToggleButton), nameof(EgoGiftCategorySetUIToggleButton.SetData))]
        [HarmonyPostfix]
        private static void EgoGiftCategorySetUIToggleButton_Init(EgoGiftCategorySetUIToggleButton __instance)
        {
            __instance.img_bonus.sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_StarlightBonus"];
        }
        [HarmonyPatch(typeof(AbnormalityStatUI), nameof(AbnormalityStatUI.SetAbnormalityGuideUIActive))]
        [HarmonyPostfix]
        private static void BottomStat_Init(AbnormalityStatUI __instance)
        {
            Transform new_info = __instance.transform.Find("[Rect]FixedScalePivot/[Text]UnitName/[Image]Icon");
            if (new_info != null)
                new_info.GetComponentInChildren<Image>(true).sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_NewInfo"];
        }
        [HarmonyPatch(typeof(MirrorDungeonShopItemSlot), nameof(MirrorDungeonShopItemSlot.SetData))]
        [HarmonyPostfix]
        private static void MirrorDungeonShopItemSlot_Init(MirrorDungeonShopItemSlot __instance)
        {
            __instance._soldOutTitleObject.GetComponentInChildren<UnityEngine.UI.Image>().sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_Mirror_SoldOut"];
        }
        #endregion

        #region Battle UI
        [HarmonyPatch(typeof(BattleUIRoot), nameof(BattleUIRoot.Init))]
        [HarmonyPostfix]
        private static void BattleUI_Init(BattleUIRoot __instance)
        {
            Transform waveUI = __instance.transform.Find("[Canvas]PerspectiveUI/SafeArea/[Script]WaveUI/[Rect]Pivot/[Image]WavePanel");
            Transform turnUI = __instance.transform.Find("[Canvas]PerspectiveUI/SafeArea/[Script]WaveUI/[Rect]Pivot/[Image]TurnPanel");
            Transform start = __instance.transform.Find("[Canvas,Script]BattleUIController/SafeArea/[Script]NewOperationController/[Rect]ActiveControl/[Rect]Pivot/[Rect]ActionableSlotList/[Layout]SinActionSlotsGrid/[EventTrigger]EndButton/[Image]RightLeg/[Rect]StartUI/[Rect]Pivot/[Image]Start");
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
            if (start != null)
            {
                start.GetComponentInChildren<Image>(true).sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_StartBattle"];
                start.GetComponentInChildren<Image>(true).m_Sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_StartBattle"];
                start.GetComponentInChildren<Image>(true).overrideSprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_StartBattle"];
            }
        }
        [HarmonyPatch(typeof(ActTypoController), nameof(ActTypoController.Init))]
        [HarmonyPostfix]
        private static void PreBattleUI_Init(ActTypoController __instance)
        {
            Transform turn = __instance.transform.Find("[Rect]Active/[Script]ActTypoTurnUI/[Image]Turn");
            if (turn != null)
            {
                turn.GetComponentInChildren<Image>(true).sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_Turn"];
                turn.GetComponentInChildren<Image>(true).m_Sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_Turn"];
                turn.GetComponentInChildren<Image>(true).overrideSprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_Turn"];
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
        #endregion

        #region Auto Button
        [HarmonyPatch(typeof(StoryManager), nameof(StoryManager.Init))]
        [HarmonyPostfix]
        private static void AutoButton_Init(StoryManager __instance)
        {
            Transform autoButton = __instance._nonPostProcessRectTransform.transform.Find("[Rect]Buttons/[Rect]MenuObject/[Button]Auto");
            autoButton.GetComponentInChildren<Image>(true).sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_AutoButton"];
            autoButton.GetComponentInChildren<StoryUIButton>(true)._buttonImageList[0] = LCBR_ReadmeManager.ReadmeSprites["LCBR_AutoButton"];
            autoButton.GetComponentInChildren<StoryUIButton>(true)._buttonImageList[1] = LCBR_ReadmeManager.ReadmeSprites["LCBR_AutoButton_Enabled"];
            autoButton.GetComponentInChildren<StoryUIButton>(true)._buttonImageList[2] = LCBR_ReadmeManager.ReadmeSprites["LCBR_TextButton"];
        }
        [HarmonyPatch(typeof(FormationSwitchablePersonalityUIPanel), nameof(FormationSwitchablePersonalityUIPanel.SetDataOpen))]
        [HarmonyPostfix]
        private static void FormationSwitchablePersonalityUIPanel_Init(FormationSwitchablePersonalityUIPanel __instance)
        {
            /*
            Transform red = __instance._egoList.transform.Find("[Script]RedDot");
            red.GetComponentInChildren<Image>(true).overrideSprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_New"];
            red.name = "AHAB";
            */
            __instance._egoRedDot.GetComponentInChildren<Image>(true).overrideSprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_New"];
            __instance._personalityRedDot.GetComponentInChildren<Image>(true).overrideSprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_New"];
            //[Canvas]RatioMainUI/[Rect]PanelRoot/[UIPanel]FormationSwitchablePersonalityUIPanel(Clone)/[Script]RightPanel/[Script]FormationEgoList/[Script]RedDot
            //[Canvas]RatioMainUI/[Rect]PopupRoot/ElementListPopup(Clone)/MainPanel/Scroll View/Viewport/Content/[Layout]Items/[Image]AttachmentsSummary/RedDotRect/[Script]RedDot
        }
        /*
        //[Transform]BattleManager/[Script]BattleObjectManager/[Transform]Units/BattleUnitView(Clone)/[Transform]CamViewRotatePivot/[Transform]Zpivot/[Canvas]UpperUI/[Script]BufTypo/TypoSlotContainer_Buff(Clone)/TypoSlot_Buff/[Text,Fixed]Typo
        [HarmonyPatch(typeof(BattleUnitUIManager), nameof(BattleUnitUIManager.SetUISize))]
        [HarmonyPostfix]
        private static void BattleUnitUIManager_Init(BattleUnitUIManager __instance)
        {
            Transform AHAHA = __instance.bufTypoUI.transform.Find("TypoSlotContainer_Buff(Clone)/TypoSlot_Buff/[Text,Fixed]Typo");
            AHAHA.name = "SOSI";
            AHAHA.GetComponentInChildren<TextMeshProUGUI>().text = "DOWN ON YOUR KNEES!";
        }
        [HarmonyPatch(typeof(AbilityTypoUI), nameof(AbilityTypoUI.Start))]
        [HarmonyPostfix]
        private static void AbilityTypoUI_Init(AbilityTypoUI __instance)
        {
            __instance._typo_Buff._text.name = "AHAB!";
            __instance._typo_Buff._text.text = "SOSAT!";
            LCB_LCBRMod.LogInfo("typoN: " + __instance._typo_Buff._text.name);
            LCB_LCBRMod.LogInfo("typoT" + __instance._typo_Buff._text.text);
        }
        */
        [HarmonyPatch(typeof(TypoText), nameof(TypoText.SetEnable))]
        [HarmonyPostfix]
        private static void TypoText_Init(TypoText __instance)
        {
            __instance._text.text = __instance._text.text.Replace("Дыхание счётчик", "Счётчик Дыхания");
            __instance._text.text = __instance._text.text.Replace("Заряд счётчик", "Счётчик Заряда");
            __instance._text.text = __instance._text.text.Replace("Кровотечение счётчик", "Счётчик Кровотечения");
            __instance._text.text = __instance._text.text.Replace("Огонь счётчик", "Счётчик Огня");
            __instance._text.text = __instance._text.text.Replace("Разрыв счётчик", "Счётчик Разрывов");
            __instance._text.text = __instance._text.text.Replace("Тремор счётчик", "Счётчик Тремора");
            __instance._text.text = __instance._text.text.Replace("Утопание счётчик", "Счётчик Утопания");
            __instance._text.text = __instance._text.text.Replace("Lack of Патрон", "Патронов нет");
        }
        public static Color yellowish = new Color(1.0f, 0.306f, 0, 0.502f);
        public static void getBurnTS(List<Transform> transforms)
        {
            foreach (Transform t in transforms)
            {
                getBurnT(t);
            }
        }
        public static void getBurnT(Transform t)
        {
            t.GetComponentInChildren<TextMeshProUGUI>().m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(11);
            t.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.EnableKeyword("GLOW_ON");
            t.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetColor("_GlowColor", yellowish);
            t.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat("_GlowInner", (float)5);
            t.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat("_GlowOuter", (float)0.2);
            t.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat("_GlowPower", (float)5);
            t.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat("_GlowOffset", (float)0.3);
            t.GetComponentInChildren<TextMeshProUGUI>().characterSpacing = 3;
        }
        [HarmonyPatch(typeof(ChapterSelectionUIPanel), nameof(ChapterSelectionUIPanel.SetDataOpen))]
        [HarmonyPostfix]
        private static void ChapterSelectionUIPanel_Init(ChapterSelectionUIPanel __instance)
        {
            List<Transform> transforms = new List<Transform>
            {
                __instance._rewardDungeonBanner.transform.Find("[Rect]Items/[Text]Entrance"),
                __instance._rewardDungeonBanner.transform.Find("[Rect]Items/[Text]Entrance/[Text]Entrance (1)"),
                __instance._mirrorDungeonBanner.transform.Find("[Rect]Items/[Text]Entrance"),
                __instance._mirrorDungeonBanner.transform.Find("[Rect]Items/[Text]Entrance/[Text]Entrance (1)"),
                __instance._railwayDungeonBanner.transform.Find("[Rect]Items/[Text]Entrance"),
                __instance._railwayDungeonBanner.transform.Find("[Rect]Items/[Text]Entrance/[Text]Entrance (1)")
            };
            getBurnTS(transforms);
            Transform railway_line = __instance._railwayDungeonBanner.transform.Find("[Rect]Items/[Image]ImageBackground/[Image]Image/[Text]RailTextDeco");
            Color railway = railway_line.GetComponentInChildren<TextMeshProUGUI>(true).color;
            Color charcoal = new Color(0.016f, 0.016f, 0.016f, 0.91f);
            railway_line.GetComponentInChildren<TextMeshProUGUI>(true).m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(11);
            railway_line.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetColor("_GlowColor", railway);
            railway_line.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetColor("_UnderlayColor", charcoal);
            railway_line.GetComponentInChildren<TextMeshProUGUI>(true).characterSpacing = 3;
        }
        [HarmonyPatch(typeof(RailwayDungeonUIPanel), nameof(RailwayDungeonUIPanel.SetDataOpen))]
        [HarmonyPostfix]
        private static void RailwayDungeonUIPanel_Init(RailwayDungeonUIPanel __instance)
        {
            List<Transform> transforms = new List<Transform>
            {
                __instance._upperUI.transform.Find("[Text]Title_Highlight"),
                __instance._upperUI.transform.Find("[Text]Title_Highlight/[Text]Title_Highlight")
            };
            getBurnTS(transforms);
        }
        #region Details
        [HarmonyPatch(typeof(VendingMachineUIPanel), nameof(VendingMachineUIPanel.RefreshPage))]
        [HarmonyPostfix]
        private static void VendingMachineUI_Init(VendingMachineUIPanel __instance)
        {
            __instance.tmp_notice_sold_out.GetComponentInChildren<TextMeshProLanguageSetter>().enabled = false;
            __instance.tmp_notice_sold_out.m_currentMaterial = LCB_Cyrillic_Font.GetCyrillicMats(11);
            __instance.tmp_notice_sold_out.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(11);
            __instance.tmp_notice_sold_out.fontSharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(11);
            getBurnT(__instance.tmp_notice_sold_out.transform);
        }
        [HarmonyPatch(typeof(GacksungLevelUpCompletionPopup), nameof(GacksungLevelUpCompletionPopup.UpdateAcquiredContentsLayout))]
        [HarmonyPostfix]
        private static void GacksungLevelUpCompletionPopup_Init(GacksungLevelUpCompletionPopup __instance)
        {
            __instance.tmp_contentTitle.fontSharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(11);
            __instance.tmp_contentTitle.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(11);
            getBurnT(__instance.tmp_contentTitle.transform);
            __instance.tmp_contentTitle.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetColor("_GlowColor", Color.white);
        }
        #endregion
        [HarmonyPatch(typeof(GachaCardUI), nameof(GachaCardUI.OnDisable))]
        [HarmonyPostfix]
        private static void GachaCardUI_SetData(GachaCardUI __instance)
        {
            __instance.img_newMark.overrideSprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_NewGacha"];
        }
        #endregion
    }
}
