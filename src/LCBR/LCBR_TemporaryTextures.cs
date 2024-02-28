using BattleUI;
using BattleUI.BattleUnit.SkillInfoUI;
using BattleUI.Information;
using UnitInformation.Tab;
using HarmonyLib;
using MainUI;
using MainUI.VendingMachine;
using TMPro;
using TMPro.SpriteAssetUtilities;
using UnityEngine;
using MainUI.Gacha;
using BattleUI.UIRoot;
using Login;
using static UI.Utility.InfoModels;
using static UI.Utility.TMProStringMatcher;
using BattleUI.EvilStock;
using UnityEngine.Playables;
using BattleUI.Typo;
using Dungeon.Map.UI;
using LimbusLocalizeRUS;
using BattleUI.BattleUnit;
using System.Collections.Generic;
using UtilityUI;

namespace LimbusCompanyBusRUS
{
    internal class LCBR_TemporaryTextures
    {
        #region MainMenu
        [HarmonyPatch(typeof(GetNewCardTimelineScriptBase), nameof(GetNewCardTimelineScriptBase.Init))]
        [HarmonyPostfix]
        private static void GetNewCardTimelineScriptBase_Init(GetNewCardTimelineScriptBase __instance)
        {
            Transform subtitle = __instance._subtitle.transform.Find("TextRect/TextLayout/[LocalizeText]Subtitle");
            subtitle.GetComponentInChildren<TextMeshProUGUI>().m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(14);
        }
        [HarmonyPatch(typeof(GachaUIPanel), nameof(GachaUIPanel.SetGachaInfoPanel))]
        [HarmonyPostfix]
        private static void Gacha_Init(GachaUIPanel __instance)
        {
            Color charcoal = new Color(0.016f, 0.016f, 0.016f, 0.91f);
            Transform yisang = __instance.transform.Find("[Rect]CurrentGachaPage/ReasonPointAnchor/ReasonPointIndicator/tmp_number_of_extract");
            yisang.GetComponentInChildren<TextMeshProUGUI>(true).m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(16);
            yisang.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.EnableKeyword("UNDERLAY_ON");
            yisang.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetColor("_UnderlayColor", charcoal);
            yisang.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetFloat("_UnderlayOffsetX", 5);
            yisang.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetFloat("_UnderlayOffsetY", -5);
            yisang.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetFloat("_UnderlayDilate", 3);
            yisang.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetFloat("_UnderlaySoftness", 0);
            Transform exchange = __instance.transform.Find("[Rect]CurrentGachaPage/ReasonPointAnchor/ReasonPointIndicator/tmp_exchange");
            exchange.GetComponentInChildren<TextMeshProUGUI>(true).m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(16);
            exchange.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.EnableKeyword("UNDERLAY_ON");
            exchange.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetColor("_UnderlayColor", charcoal);
            exchange.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetFloat("_UnderlayOffsetX", 5);
            exchange.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetFloat("_UnderlayOffsetY", -5);
            exchange.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetFloat("_UnderlayDilate", 3);
            exchange.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetFloat("_UnderlaySoftness", 0);
        }
        [HarmonyPatch(typeof(StageEventBanner), nameof(StageEventBanner.Init))]
        [HarmonyPostfix]
        private static void EventOpen_Init(StageEventBanner __instance)
        {
            Color yellowish = new Color(1.0f, 0.306f, 0, 0.502f);
            __instance._eventStateUI.tmp_eventState.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(9);
            __instance._eventStateUI.tmp_eventState.color = Color.yellow;
            __instance._eventStateUI.tmp_eventState.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.EnableKeyword("GLOW_ON");
            __instance._eventStateUI.tmp_eventState.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetColor("_GlowColor", yellowish);
            __instance._eventStateUI.tmp_eventState.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat("_GlowInner", (float)0.6);
            __instance._eventStateUI.tmp_eventState.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat("_GlowPower", 3);
        }
        #endregion

        #region Details
        [HarmonyPatch(typeof(VendingMachineUIPresenter), nameof(VendingMachineUIPresenter.SetSeason))]
        [HarmonyPostfix]
        private static void VendingMachineUI_Init(VendingMachineUIPresenter __instance)
        {
            Color yellowish = new Color(1.0f, 0.306f, 0, 0.502f);
            Transform sold_out = __instance.transform.Find("ActiveRect/VendingMachineUIPanel/GoodsStoreAreaMaster/GoodsStorePanelGroup/BackPanel/Main/SoldOut/[LocalizeText]WaitRestock");
            if (sold_out != null)
            {
                sold_out.GetComponentInChildren<TextMeshProUGUI>(true).m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(11);
                sold_out.GetComponentInChildren<TextMeshProUGUI>(true).fontSharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(11);
                sold_out.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetColor("_GlowColor", yellowish);
                sold_out.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetFloat("_GlowInner", (float)0.6);
                sold_out.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetFloat("_GlowPower", 3);
                __instance._panel.tmp_notice_sold_out.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(11);
                __instance._panel.tmp_notice_sold_out.fontSharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(11);
            }
        }
        [HarmonyPatch(typeof(GacksungLevelUpCompletionPopup), nameof(GacksungLevelUpCompletionPopup.SetDataByType))]
        [HarmonyPostfix]
        private static void GacksungLevelUpCompletionPopup_Init(GacksungLevelUpCompletionPopup __instance)
        {
            Color yellowish = new Color(1.0f, 0.306f, 0, 0.502f);
            __instance.tmp_contentTitle.fontSharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(9);
            __instance.tmp_contentTitle.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(9);
            __instance.tmp_contentTitle.color = Color.yellow;
            __instance.tmp_contentTitle.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.EnableKeyword("GLOW_ON");
            __instance.tmp_contentTitle.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetColor("_GlowColor", yellowish);
            __instance.tmp_contentTitle.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat("_GlowInner", (float)0.6);
            __instance.tmp_contentTitle.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat("_GlowPower", 3);
        }
        #endregion

        #region Dialogues
        Color yisang = new Color(0.831f, 0.882f, 0.909f, 1.0f);
        Color faust = new Color(1.0f, 0.694f, 0.705f, 1.0f);
        Color donquixote = new Color(1.0f, 0.937f, 0.137f, 1.0f);
        Color ryoshu = new Color(0.811f, 0, 0, 1.0f);
        Color meursault = new Color(0.352f, 0411f, 0.701f, 1.0f);
        Color honglu = new Color(0.356f, 1.0f, 0.870f, 1.0f);
        Color heathcliff = new Color(0.549f, 0.388f, 0.760f, 1.0f);
        Color ishmael = new Color(1.0f, 0.584f, 0, 1.0f);
        Color rodya = new Color(0.572f, 0.219f, 0.219f, 1.0f);
        Color sinclair = new Color(0.545f, 0.611f, 0.082f, 1.0f);
        Color outis = new Color(0.415f, 0.6f, 0.454f, 1.0f);
        Color gregor = new Color(0.631f, 0.349f, 0.117f, 1.0f);

        Color wrath = new Color(1.0f, 0.294f, 0.2f, 1.0f);
        Color lust = new Color(1.0f, 0.396f, 0.101f, 1.0f);
        Color sloth = new Color(1.0f, 0.729f, 0.341f, 1.0f);
        Color gluttony = new Color(0.796f, 0.913f, 0, 1.0f);
        Color gloom = new Color(0.247f, 0.870f, 1.0f, 1.0f);
        Color pride = new Color(0, 0.388f, 0.737f, 1.0f);
        Color envy = new Color(0.760f, 0.266f, 1.0f, 1.0f);



        [HarmonyPatch(typeof(MainLobbyUIPanel), nameof(MainLobbyUIPanel.StartDialog))]
        [HarmonyPostfix]
        private static void Lobby_Init(MainLobbyUIPanel __instance)
        {
            __instance.tmpro_dialog.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(14);
            __instance.tmpro_dialog.m_currentMaterial = LCB_Cyrillic_Font.GetCyrillicMats(14);
        }
        [HarmonyPatch(typeof(TierUpEffectUIPanel), nameof(TierUpEffectUIPanel.SetupAndOpen))]
        [HarmonyPostfix]
        private static void TierUp_Init(TierUpEffectUIPanel __instance)
        {
            __instance._subtitle.tmp_punchLine.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(15);
        }
        [HarmonyPatch(typeof(StoryUIPanel), nameof(StoryUIPanel.SetDataOpen))]
        [HarmonyPostfix]
        private static void Story_Init(StoryUIPanel __instance)
        {
            __instance._personalityStoryUI.PersonalityUI._voiceText.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(14);

            Transform dialogue = __instance.transform.Find("[Rect]PersonalityStoryUI/[Rect]PersonalityUI/[Rect]Banner/[Image]Panel/[Rect]Dialog_BG/img_shadow/[Text]VoiceLocal");
            if (dialogue != null)
            {
                __instance.GetComponentInChildren<TextMeshProUGUI>(true).m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(14);
            }
        }
        [HarmonyPatch(typeof(BattleDialogUI), nameof(BattleDialogUI.Init))]
        [HarmonyPostfix]
        private static void EGO_Init(BattleDialogUI __instance)
        {
            __instance.tmp_dialog.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(15);
        }
        [HarmonyPatch(typeof(BattleResultUIPanel), nameof(BattleResultUIPanel.SetStatusUI))]
        [HarmonyPostfix]
        private static void BattleResult_Init(BattleResultUIPanel __instance)
        {
            __instance.tmp_dialog.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(14);

            Color yellowish = new Color(1.0f, 0.306f, 0, 0.502f);
            Color reddish = new Color(0.686f, 0.003f, 0.003f, 1.0f);
            __instance.tmp_result.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(11);
            __instance.tmp_result.fontMaterial.EnableKeyword("GLOW_ON");
            __instance.tmp_result.fontMaterial.SetFloat("_GlowInner", 0.3f);
            __instance.tmp_result.fontMaterial.SetFloat("_GlowOuter", 0.3f);
            __instance.tmp_result.fontMaterial.SetFloat("_GlowPower", 0.3f);
            if (__instance.tmp_result.text.Contains("Победа"))
                __instance.tmp_result.fontMaterial.SetColor("_GlowColor", yellowish);
            else
                __instance.tmp_result.fontMaterial.SetColor("_GlowColor", reddish);
        }
        [HarmonyPatch(typeof(GachaResultUI), nameof(GachaResultUI.SetData))]
        [HarmonyPostfix]
        private static void GachaDialogue_Init(GachaResultUI __instance)
        {
            __instance._getNewCardTimelineManager._currentTimeline._subtitle.tmp_punchLine.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(14);
            __instance._getNewCardTimelineManager._currentTimeline._punchline.tmp_punchLine.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(15);
        }
        #endregion

        #region Experimental properties
        /*
        [HarmonyPatch(typeof(TextMeshProMaterialSetter), nameof(TextMeshProMaterialSetter.WriteMaterialProperty))]
        [HarmonyPrefix]
        public static bool WriteMaterialProperty(TextMeshProMaterialSetter __instance)
        {
            if (!__instance._text.font.name.StartsWith("Pretendard-Regular") && !__instance._text.font.name.StartsWith("Mikodacs") || !LCB_Cyrillic_Font.GetCyrillicFonts(__instance._text.font.name, out _) && !LCB_Cyrillic_Font.IsCyrillicFont(__instance._text.font))
                return true;
            Color underlay = __instance._text.fontMaterial.GetColor("_UnderlayColor");

            if (__instance._text.font.name.StartsWith("Pretendard-Regular"))
                __instance._text.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(15);

            Color underlayColor = __instance.underlayColor;

            if (__instance._text.font.name.StartsWith("Pretendard-Regular"))
            {
                if (__instance.underlayOn && __instance._fontMaterialInstance.HasProperty(ShaderUtilities.ID_UnderlayColor))
                {
                    underlayColor = __instance.underlayHdrColorOn ? __instance.underlayHdrColor : underlayColor;
                    if (underlayColor.r > 0f || underlayColor.g > 0f || underlayColor.b > 0f)
                        __instance._text.color = underlayColor;
                }

                Color charcoal = new Color(0.016f, 0.016f, 0.016f, 0.91f);

                if (__instance.underlayHdrColorOn == false)
                {
                    __instance._text.fontMaterial.SetColor("_UnderlayColor", underlayColor);
                    __instance._text.fontMaterial.SetColor("_GlowColor", underlayColor);
                    __instance._text.fontMaterial.SetFloat("_GlowPower", 0.3f);
                    __instance._text.color = Color.white;
                    return false;
                }
                else
                {
                    __instance._text.fontMaterial.SetColor("_UnderlayColor", underlayColor);
                    __instance._text.fontMaterial.SetColor("_GlowColor", charcoal);
                    __instance._text.color = charcoal;
                    return false;
                }
            }
            return false;
        }
        */
        [HarmonyPatch(typeof(BattleLyricsContoller), nameof(BattleLyricsContoller.Init))]
        [HarmonyPostfix]
        private static void BattleLyricsMat1(BattleLyricsContoller __instance)
        {
            __instance.tmp.color = Color.white;
            __instance.tmp.fontMaterial.EnableKeyword("GLOW_ON");
            __instance.tmp.fontMaterial.SetColor("_GlowColor", Color.white);
            __instance.tmp.fontMaterial.SetFloat("_GlowPower", 1f);
            __instance.tmp.m_fontAsset = LCB_Cyrillic_Font.GetCyrillicFonts(3);
            __instance.tmp.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(10);
            if (__instance._curText.Contains("</color>"))
            {
                __instance.tmp.m_fontAsset = LCB_Cyrillic_Font.GetCyrillicFonts(3);
                __instance.tmp.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(9);
                __instance.tmp.color = Color.black;
                __instance.tmp.fontMaterial.EnableKeyword("GLOW_ON");
                __instance.tmp.fontMaterial.SetColor("_GlowColor", Color.red);
                __instance.tmp.fontMaterial.SetFloat("_GlowInner", 0.025f);
                __instance.tmp.fontMaterial.SetFloat("_GlowOuter", 0.5f);
            }
        }
        [HarmonyPatch(typeof(BattleLyricsContoller), nameof(BattleLyricsContoller.CompleteText))]
        [HarmonyPostfix]
        private static void BattleLyricsMatC(BattleLyricsContoller __instance)
        {
            __instance.tmp.color = Color.white;
            __instance.tmp.fontMaterial.EnableKeyword("GLOW_ON");
            __instance.tmp.fontMaterial.SetColor("_GlowColor", Color.white);
            __instance.tmp.fontMaterial.SetFloat("_GlowPower", 1f);
            __instance.tmp.m_fontAsset = LCB_Cyrillic_Font.GetCyrillicFonts(3);
            __instance.tmp.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(10);
            if (__instance._curText.Contains("</color>"))
            {
                __instance.tmp.m_fontAsset = LCB_Cyrillic_Font.GetCyrillicFonts(3);
                __instance.tmp.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(9);
                __instance.tmp.color = Color.black;
                __instance.tmp.fontMaterial.EnableKeyword("GLOW_ON");
                __instance.tmp.fontMaterial.SetColor("_GlowColor", Color.red);
                __instance.tmp.fontMaterial.SetFloat("_GlowInner", 0.025f);
                __instance.tmp.fontMaterial.SetFloat("_GlowOuter", 0.5f);
            }
        }
        #endregion
    }
}
