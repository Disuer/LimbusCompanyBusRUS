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

        #region Formation UI
        [HarmonyPatch(typeof(FormationPersonalityUI), nameof(FormationPersonalityUI.SetData))]
        [HarmonyPostfix]
        private static void FormationPersonalityUI_Init(FormationPersonalityUI __instance)
        {
            __instance.img_isParticipaged.sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_InParty"];
            __instance.img_support.sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_SupportTag"];
        }
        [HarmonyPatch(typeof(FormationSwitchablePersonalityUIScrollViewItem), nameof(FormationSwitchablePersonalityUIScrollViewItem.SetData))]
        [HarmonyPostfix]
        private static void FormationSwitchablePersonalityUIScrollViewItem_Init(FormationSwitchablePersonalityUIScrollViewItem __instance)
        {
            Transform img_isParticipaged = __instance._participatedObject.transform.parent.parent.parent.Find("[Image]ParticipateSlotUI");
            img_isParticipaged.GetComponentInChildren<Image>().sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_InParty"];
        }
        #endregion

        #region Support Formation UI
        [HarmonyPatch(typeof(FormationSwitchablePersonalityUIPanel), nameof(FormationSwitchablePersonalityUIPanel.SetDataOpen))]
        [HarmonyPostfix]
        private static void Support_Init(FormationSwitchablePersonalityUIPanel __instance)
        {
            Transform support_tag = __instance.transform.Find("[Script]RightPanel/[Script]FormationEgoList/[Image]SupportTag");
            if (support_tag != null)
                support_tag.GetComponentInChildren<Image>(true).sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_SupportTag"];
        }
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
        #endregion
    }
}
