/*
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
using MainUI.BattleResult;

namespace LimbusCompanyBusRUS
{
    internal class LCBR_TemporaryTextures
    {
        #region MainMenu
        public static void getBurnTS(List<Transform> transforms)
        {
            foreach (Transform t in transforms)
            {
                getBurnT(t);
            }
        }
        public static void getBurnT(Transform t)
        {
            Color yellowish = new Color(1.0f, 0.306f, 0, 0.502f);
            t.GetComponentInChildren<TextMeshProUGUI>().m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(7);
            t.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.EnableKeyword("GLOW_ON");
            t.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetColor("_GlowColor", yellowish);
            t.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat("_GlowInner", (float)0.6);
            t.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat("_GlowPower", 3);
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
            railway_line.GetComponentInChildren<TextMeshProUGUI>(true).m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(7);
            railway_line.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetColor("_GlowColor", railway);
            railway_line.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetColor("_UnderlayColor", charcoal);
            railway_line.GetComponentInChildren<TextMeshProUGUI>(true).characterSpacing = 1;
        }
        private static Material glowingBurn = new Material(LCB_Cyrillic_Font.GetCyrillicMats(7));
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
        [HarmonyPatch(typeof(GetNewCardTimelineScriptBase), nameof(GetNewCardTimelineScriptBase.Init))]
        [HarmonyPostfix]
        private static void GetNewCardTimelineScriptBase_Init(GetNewCardTimelineScriptBase __instance)
        {
            Transform subtitle = __instance._subtitle.transform.Find("TextRect/TextLayout/[LocalizeText]Subtitle");
            subtitle.GetComponentInChildren<TextMeshProUGUI>().m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(11);
        }
        #endregion

        #region
        [HarmonyPatch(typeof(VendingMachineUIPresenter), nameof(VendingMachineUIPresenter.SetSeason))]
        [HarmonyPostfix]
        private static void VendingMachineUI_Init(VendingMachineUIPresenter __instance)
        {
            Color yellowish = new Color(1.0f, 0.306f, 0, 0.502f);
            Transform sold_out = __instance.transform.Find("ActiveRect/VendingMachineUIPanel/GoodsStoreAreaMaster/GoodsStorePanelGroup/BackPanel/Main/SoldOut/[LocalizeText]WaitRestock");
            if (sold_out != null)
            {
                sold_out.GetComponentInChildren<TextMeshProUGUI>(true).fontSharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(7);
                sold_out.GetComponentInChildren<TextMeshProUGUI>(true).fontSharedMaterial.SetColor("_GlowColor", yellowish);
                sold_out.GetComponentInChildren<TextMeshProUGUI>(true).fontSharedMaterial.SetFloat("_GlowInner", (float)0.6);
                sold_out.GetComponentInChildren<TextMeshProUGUI>(true).fontSharedMaterial.SetFloat("_GlowPower", 3);
                __instance._panel.tmp_notice_sold_out.fontSharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(7);
            }
        }
        #endregion

        #region Dialogues
        [HarmonyPatch(typeof(MainLobbyUIPanel), nameof(MainLobbyUIPanel.SetDataOpen))]
        [HarmonyPostfix]
        private static void Lobby_Init(MainLobbyUIPanel __instance)
        {
            __instance.tmpro_dialog.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(11);
        }
        [HarmonyPatch(typeof(StoryUIPanel), nameof(StoryUIPanel.SetDataOpen))]
        [HarmonyPostfix]
        private static void Story_Init (StoryUIPanel __instance)
        {
            __instance._personalityStoryUI.PersonalityUI._voiceText.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(10);
        }
        [HarmonyPatch(typeof(BattleSkillViewUIInfo), nameof(BattleSkillViewUIInfo.SetSkillViewVoiceText))]
        [HarmonyPrefix]
        public static void BattleSkillEGO(BattleSkillViewUIInfo __instance)
        {
            Color abColor = __instance._materialSetter_abText.underlayColor;
            Color skillColor = __instance._materialSetter_skillText.underlayColor;
            __instance._materialSetter_abText.defaultMat = LCB_Cyrillic_Font.GetCyrillicMats(12);
            __instance._materialSetter_skillText.defaultMat = LCB_Cyrillic_Font.GetCyrillicMats(12);

            Transform skill_text = __instance.transform.Find("[Canvas]Canvas/[Script]SkillViewCanvas/DialogHolder/[Image]Shadow/SkillViewText");
            if (skill_text != null)
            {
                skill_text.GetComponentInChildren<TextMeshProUGUI>(true).m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(12);
            }
        }
        [HarmonyPatch(typeof(BattleDialogUI), nameof(BattleDialogUI.Init))]
        [HarmonyPostfix]
        private static void EGO_Init(BattleDialogUI __instance)
        {
            __instance.tmp_dialog.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(12);
        }
        [HarmonyPatch(typeof(BattleResultUIPanel), nameof(BattleResultUIPanel.SetStatusUI))]
        [HarmonyPostfix]
        private static void BattleResult_Init (BattleResultUIPanel __instance)
        {
            __instance.tmp_dialog.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(11);
        }
        [HarmonyPatch(typeof(FormationPersonalityUI), nameof(FormationPersonalityUI.SetData))]
        [HarmonyPostfix]
        private static void FixedLabel_Init(FormationPersonalityUI __instance)
        {
            __instance._forceParticipation.tmp_label.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(0);
        }
        [HarmonyPatch(typeof(ExpGaugeUI), nameof(ExpGaugeUI.SetLevelText))]
        [HarmonyPostfix]
        private static void ExpGaugeUI_Init(ExpGaugeUI __instance)
        {
            Transform Lv = __instance.tmp_levelText.transform.Find("[Tmpro]Lv");
            Lv.GetComponentInChildren<TextMeshProUGUI>().text = "УР.";
            Lv.GetComponentInChildren<TextMeshProUGUI>().m_fontAsset = LCB_Cyrillic_Font.GetCyrillicFonts(2);
            Lv.GetComponentInChildren<TextMeshProUGUI>().m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(5);
            Transform Exp = __instance.tmp_gainExpText.transform.parent.Find("[Tmpro]ExpTitle");
            Exp.GetComponentInChildren<TextMeshProUGUI>().text = "ОПЫТ";
            Exp.GetComponentInChildren<TextMeshProUGUI>().fontSize = 40;
            Exp.GetComponentInChildren<TextMeshProUGUI>().m_fontAsset = LCB_Cyrillic_Font.GetCyrillicFonts(2);
            Exp.GetComponentInChildren<TextMeshProUGUI>().m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(5);
        }
        [HarmonyPatch(typeof(BattleResultPersonalityExpGaugeUI), nameof(BattleResultPersonalityExpGaugeUI.SetLevelText))]
        [HarmonyPostfix]
        private static void BattleResultPersonalityExpGaugeUI_Init(BattleResultPersonalityExpGaugeUI __instance)
        {
            Transform Lv = __instance.tmp_levelText.transform.Find("tmp_level_text");
            Lv.GetComponentInChildren<TextMeshProUGUI>().text = "УР.";
            Lv.GetComponentInChildren<TextMeshProUGUI>().m_fontAsset = LCB_Cyrillic_Font.GetCyrillicFonts(2);
            Lv.GetComponentInChildren<TextMeshProUGUI>().m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(5);
        }
        
        //[Canvas]RatioMainUI/[Rect]PanelRoot/BattleResultPanel_renewal(Clone)/[Rect]Right/[Rect]Frames/rect_titleGroup/[Script]UserLevel/[Tmpro]LvValue/[Tmpro]Lv
        //[Canvas]RatioMainUI/[Rect]PanelRoot/BattleResultPanel_renewal(Clone)/[Rect]Right/[Rect]VictoryInfo/[Script]PersonalityList/[Layout]Personalities (1)/BattleResultPersonalitySlot_renewal (6)/tmp_level_number/tmp_level_text
        #endregion
    }
}
*/

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
using MonoMod.Cil;
using TextAssetPatch;
using UnityEngine.UI;

namespace LimbusCompanyBusRUS
{
    internal class LCBR_TemporaryTextures
    {
        #region MainMenu
        public static void getBurnTS(List<Transform> transforms)
        {
            foreach (Transform t in transforms)
            {
                getBurnT(t);
            }
        }
        public static void getBurnT(Transform t)
        {
            Color yellowish = new Color(1.0f, 0.306f, 0, 0.502f);
            t.GetComponentInChildren<TextMeshProUGUI>().m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(11);
            t.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.EnableKeyword("GLOW_ON");
            t.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetColor("_GlowColor", yellowish);
            t.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat("_GlowInner", (float)0.6);
            t.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat("_GlowPower", 3);
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
            railway_line.GetComponentInChildren<TextMeshProUGUI>(true).characterSpacing = 1;
        }
        private static Material glowingBurn = new Material(LCB_Cyrillic_Font.GetCyrillicMats(11));
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
        [HarmonyPatch(typeof(TierUpEffectUIPanel), nameof(TierUpEffectUIPanel.SetupAndOpen))]
        [HarmonyPostfix]
        private static void TierUp_Init(TierUpEffectUIPanel __instance)
        {
            __instance._subtitle.tmp_punchLine.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(15);
        }
        [HarmonyPatch(typeof(PersonalityStoryUI), nameof(PersonalityStoryUI.SetCurrentSelectCharacter))]
        [HarmonyPostfix]
        private static void Story_Init(PersonalityStoryUI __instance)
        {
            __instance.PersonalityUI._voiceText.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(14);
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
        [HarmonyPatch(typeof(BattleUnitView), nameof(BattleUnitView.Update))]
        [HarmonyPostfix]
        private static void BattleUnitView_Init(BattleUnitView __instance)
        {
            __instance._uiManager._dialogUI.GetComponentInChildren<BattleDialogUI>(true).tmp_dialog.name = "AHUET";
            __instance._uiManager._dialogUI.GetComponentInChildren<BattleDialogUI>(true).tmp_dialog.text = "Ох мой Синклер..\nя даже не знаю что сказать, предатель.";
            __instance._uiManager._dialogUI.GetComponentInChildren<BattleDialogUI>(true).tmp_dialog.m_fontAsset = LCB_Cyrillic_Font.GetCyrillicFonts(4);
            __instance._uiManager._dialogUI.GetComponentInChildren<BattleDialogUI>(true).tmp_dialog.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(16);
        }
        [HarmonyPatch(typeof(MainLobbyUIPanel), nameof(MainLobbyUIPanel.ActiveDialog))]
        [HarmonyPostfix]
        private static void Lobby_Init(MainLobbyUIPanel __instance)
        {
            __instance.tmpro_dialog.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(14);
            __instance.tmpro_dialog.m_currentMaterial = LCB_Cyrillic_Font.GetCyrillicMats(14);
        }
        [HarmonyPatch(typeof(PersonalityStoryPersonalityUI), nameof(PersonalityStoryPersonalityUI.OpenPersonalityVoiceTab))]
        [HarmonyPostfix]
        private static void PersonalityStoryPersonalityUI_Init(PersonalityStoryPersonalityUI __instance)
        {
            __instance._voiceText.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(14);
            __instance._voiceText.m_sharedMaterial.EnableKeyword("UNDELAY_ON");
            __instance._voiceText.GetComponentInChildren<TextMeshProLanguageSetter>().enabled = false;
        }
        [HarmonyPatch(typeof(ActBattleEndTypoUI), nameof(ActBattleEndTypoUI.Open))]
        [HarmonyPostfix]
        private static void ActBattleEndTypoUI_Init(ActBattleEndTypoUI __instance)
        {
            Transform Def = __instance._defeatGroup.transform.Find("[Image]Typo_Defeat");
            Transform Win = __instance._victoryGroup.transform.Find("[Image]Typo_Victory");
            Def.GetComponentInChildren<Image>().overrideSprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_DefeatT"];
            Win.GetComponentInChildren<Image>().overrideSprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_WinT"];
        }
        [HarmonyPatch(typeof(BattleResultUIPanel), nameof(BattleResultUIPanel.SetStatusUI))]
        [HarmonyPostfix]
        private static void BattleResultUIPanel_Init(BattleResultUIPanel __instance)
        {
            if (__instance.img_ResultMark.sprite.name == "MainUI_BattleResult_1_20")
            {
                __instance.img_ResultMark.overrideSprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_Defeat"];
            }
            else
            {
                __instance.img_ResultMark.overrideSprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_Win"];
            }
        }
        //[Script]BattleUIRoot/[Canvas]BattleFrontUI/[Script]ActTypoController/[Rect]Active/[Script]ActBattleEndResultTypoUI/[Rect]TypoMasterRoot/[Rect]DefeatGroup/[Image]Typo_Defeat
        //[Script]BattleUIRoot/[Canvas]BattleFrontUI/[Script]ActTypoController/[Rect]Active/[Script]ActBattleEndResultTypoUI/[Rect]TypoMasterRoot/[Rect]VictoryGroup/[Image]Typo_Victory
        //[Canvas]RatioMainUI/[Rect]PanelRoot/BattleResultPanel_renewal(Clone)/[Rect]Left/[Image]Mark
        #endregion
    }
}