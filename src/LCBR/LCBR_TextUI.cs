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
using static Interop;
using static UnitinfoUnitStatusContent;
using Microsoft.VisualBasic;
using static Il2CppMono.Globalization.Unicode.SimpleCollator;
using BattleUI.Announcer;
using System.Runtime.InteropServices;
using UI;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using StorySystem;
using BattleUI.Typo;
using static Dungeon.Map.MapSpawnManager;
using static BattleUI.Abnormality.AbnormalityPartSkills;
using BattleUI.Operation;
using Dungeon.Map.UI;
using System.Collections.Generic;
using UtilityUI;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.PlayerLoop;
using System;
using System.Text.RegularExpressions;
using Il2CppSystem;

namespace LimbusLocalizeRUS
{
    internal class LCBR_TextUI
    {
        #region Login
        [HarmonyPatch(typeof(LoginSceneManager), nameof(LoginSceneManager.SetLoginInfo))]
        [HarmonyPostfix]
        private static void Client_Init(LoginSceneManager __instance)
        {
            __instance.tmp_loginAccount.font = LCB_Cyrillic_Font.tmpcyrillicfonts[4];
            __instance.tmp_loginAccount.fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[4].material;
        }
        [HarmonyPatch(typeof(NetworkingUI), "Initialize")]
        [HarmonyPostfix]
        private static void NetworkingUI_Init(NetworkingUI __instance)
        {
            Transform connection = __instance.transform.Find("connecting_background/tmp_connecting");
            if (connection != null)
            {
                connection.GetComponentInChildren<TextMeshProUGUI>(true).text = "ПОДКЛЮЧЕНИЕ";
                connection.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                connection.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
                connection.GetComponentInChildren<TextMeshProUGUI>(true).fontSize = 77f;
            }
        }
        [HarmonyPatch(typeof(UpdateMovieScreen), nameof(UpdateMovieScreen.SetDownLoadProgress))]
        [HarmonyPostfix]
        private static void UpdateMovieScreen_Init(UpdateMovieScreen __instance)
        {
            if (__instance._loadingCategoryText != null)
            {
                GameObject now_l = GameObject.Find("[Canvas]DownloadScreen/UpdateMovieScreen/[Rect]LoadingUI/Text_NowLoading");
                now_l.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЗАГРУЗКА...";
                now_l.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                now_l.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
                __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).name = "ОБНОВЛЕНИЕ";
                __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).text = __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).text.Replace("Downloading", "ЗАГРУЗКА");
                __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).text = __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).text.Replace("UPDATE", "ОБНОВЛЕНИЯ");
                __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).text = __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).text.Replace("Sound", "ЗВУКОВ");
                __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).text = __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).text.Replace("Sprite", "СПРАЙТОВ");
                __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
            }
        }
        #endregion

        #region Main Menu
        [HarmonyPatch(typeof(LowerControlUIPanel), nameof(LowerControlUIPanel.Initialize))]
        [HarmonyPostfix]
        private static void ControlPanel_Init(LowerControlUIPanel __instance)
        {
            Transform level = __instance.transform.Find("[Rect]Pivot/[Rect]UserInfoUI/[Rect]Info/[Rect]UserInfo/[Tmpro]Lv");
            Transform No = __instance.transform.Find("[Rect]Pivot/[Rect]UserInfoUI/[Rect]Info/[Rect]UserInfo/[Tmpro]No");
            if (level != null)
            {
                level.GetComponentInChildren<TextMeshProUGUI>(true).text = "УР";
                level.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                level.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
                No.GetComponentInChildren<TextMeshProUGUI>(true).text = "№";
                No.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
                No.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
            }
        }
        [HarmonyPatch(typeof(StageUIPresenter), nameof(StageUIPresenter.Initialize))]
        [HarmonyPostfix]
        private static void StageUIPresenter_Init(StageUIPresenter __instance)
        {
            Transform district4 = __instance.transform.Find("[Rect]Active/[Script]PartAndChapterSelectionUIPanel/[Rect]Active/[Rect]Right/[Rect]Pivot/[Rect]StoryMap/[Mask]StoryMap/[Rect]ZoomPivot/[Image]MapBG/[Script]D_4/[Rect]TextData/[Tmpro]Area");
            Transform district10 = __instance.transform.Find("[Rect]Active/[Script]PartAndChapterSelectionUIPanel/[Rect]Active/[Rect]Right/[Rect]Pivot/[Rect]StoryMap/[Mask]StoryMap/[Rect]ZoomPivot/[Image]MapBG/[Script]J_10/[Rect]TextData/[Tmpro]Area");
            Transform district11 = __instance.transform.Find("[Rect]Active/[Script]PartAndChapterSelectionUIPanel/[Rect]Active/[Rect]Right/[Rect]Pivot/[Rect]StoryMap/[Mask]StoryMap/[Rect]ZoomPivot/[Image]MapBG/[Script]K_11/[Rect]TextData/[Tmpro]Area");
            Transform district21 = __instance.transform.Find("[Rect]Active/[Script]PartAndChapterSelectionUIPanel/[Rect]Active/[Rect]Right/[Rect]Pivot/[Rect]StoryMap/[Mask]StoryMap/[Rect]ZoomPivot/[Image]MapBG/[Script]U_21/[Rect]TextData/[Tmpro]Area");
            List<Transform> transforms = new List<Transform> {district10, district11, district21, district4 };
            if (district4 != null)
            {
                district4.GetComponentInChildren<TextMeshProUGUI>(true).text = "4-й район";
                district10.GetComponentInChildren<TextMeshProUGUI>(true).text = "10-й район";
                district11.GetComponentInChildren<TextMeshProUGUI>(true).text = "11-й район";
                district21.GetComponentInChildren<TextMeshProUGUI>(true).text = "21-й район";
            }
            foreach (Transform t in transforms)
            {
                if (t != null)
                {
                    t.GetComponentInChildren<TextMeshProUGUI>(true).color = Color.red;
                    t.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.GetCyrillicFonts(0);
                    t.GetComponentInChildren<TextMeshProUGUI>(true).m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(0);
                }
            }
        }
        [HarmonyPatch(typeof(StageInfoUI), nameof(StageInfoUI.SetDataOpen))]
        [HarmonyPostfix]
        private static void StageInfoUI_Init(StageInfoUI __instance)
        {
            Transform level = __instance.transform.Find("[UIPanel]StageInfoUIRenewal/[Rect]Pivot/[Rect]StageInfoStatus/[Script]ExclearCondition/[Tmpro]Desc (1)/[Image]RecommentLevelTitleFrame/[Tmpro]Lv");
            if (level != null)
            {
                level.GetComponentInChildren<TextMeshProUGUI>(true).text = level.GetComponentInChildren<TextMeshProUGUI>(true).text.Replace("Lv", "Ур");
                level.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[2];
                level.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[2].material;
            }
        }
        [HarmonyPatch(typeof(SubChapterScrollViewItem), nameof(SubChapterScrollViewItem.SetData))]
        [HarmonyPostfix]
        private static void SubChapterScrollViewItem_Init(SubChapterScrollViewItem __instance)
        {
            __instance.tmp_pageForBebaskai.text = __instance.tmp_pageForBebaskai.text.Replace("MINI", "МИНИ");
            __instance.tmp_pageForBebaskai.font = LCB_Cyrillic_Font.tmpcyrillicfonts[3];
            __instance.tmp_pageForBebaskai.fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[3].material;
        }
        #endregion

        #region Settings
        [HarmonyPatch(typeof(SettingsPopup), nameof(SettingsPopup.Initialize))]
        [HarmonyPostfix]
        private static void SettingsSound_Init(SettingsPopup __instance)
        {
            Transform bgm = __instance.transform.Find("PanelGroup/PopupBase/Container/[Rect]Contents/Viewport/Content/[Script]SettingsSound/SettingsSoundBGM/[Text]Label");
            if (bgm != null)
                bgm.GetComponentInChildren<TextMeshProUGUI>(true).text = "Фоновая музыка";
        }
        #endregion

        #region Luxcavation
        [HarmonyPatch(typeof(ExpDungeonItem), nameof(ExpDungeonItem.SetData))]
        [HarmonyPostfix]
        private static void ExpDungeonItem_Init(ExpDungeonItem __instance)
        {
            __instance.tmp_title.fontStyle = FontStyles.Normal | FontStyles.SmallCaps;
            __instance.tmp_level.text = __instance.tmp_level.text.Replace("Lv", "Ур.");
            __instance.tmp_level.font = LCB_Cyrillic_Font.tmpcyrillicfonts[2];
            __instance.tmp_level.fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[2].material;
            Transform label = __instance.tmp_level.transform.parent.parent.Find("[Text]StageLabel");
            label.GetComponentInChildren<TextMeshProUGUI>().text = "ЭТАП";
            label.GetComponentInChildren<TextMeshProUGUI>().font = LCB_Cyrillic_Font.tmpcyrillicfonts[2];
            label.GetComponentInChildren<TextMeshProUGUI>().fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[2].material;
        }
        [HarmonyPatch(typeof(ThreadDungeonSelectStageButton), nameof(ThreadDungeonSelectStageButton.SetData))]
        [HarmonyPostfix]
        private static void ThreadDungeonSelectStageButton_Init(ThreadDungeonSelectStageButton __instance)
        {
            __instance.tmp_level.text = __instance.tmp_level.text.Replace("Lv", "Ур.");
            __instance.tmp_level.font = LCB_Cyrillic_Font.tmpcyrillicfonts[2];
            __instance.tmp_level.fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[2].material;
            __instance.tmp_level.fontSize = 60;
        }
        #endregion

        #region Mirror Dungeons
        [HarmonyPatch(typeof(MirrorDungeonEntranceScrollUIPanel), nameof(MirrorDungeonEntranceScrollUIPanel.Initialize))]
        [HarmonyPostfix]
        private static void MirrorDungeonDoors_Init(MirrorDungeonEntranceScrollUIPanel __instance)
        {
            Transform dungeon = __instance.transform.Find("[Script]EntranceItemsScrollView/[Rect]ViewPort/[Layout]Items/[Script]MirrorDungeonEntranceItemView_Single/[Rect]Selectable/[Tmpro]DungeonLabel");
            if (dungeon != null)
            {
                dungeon.GetComponentInChildren<TextMeshProUGUI>(true).text = "<cspace=-2px>Подземелье</cspace>";
                dungeon.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
                dungeon.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
            }
            Transform dungeon_hard = __instance.transform.Find("[Script]EntranceItemsScrollView/[Rect]ViewPort/[Layout]Items/[Script]MirrorDungeonEntranceItemView_Single (1)/[Rect]Selectable/[Tmpro]DungeonLabel");
            if (dungeon_hard != null)
            {
                dungeon_hard.GetComponentInChildren<TextMeshProUGUI>(true).text = "<cspace=-2px>Подземелье</cspace>";
                dungeon_hard.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
                dungeon_hard.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
            }
            Transform mirror = __instance.transform.Find("[Script]EntranceItemsScrollView/[Rect]ViewPort/[Layout]Items/[Script]MirrorDungeonEntranceItemView_Single/[Rect]Selectable/[Button]Stage Frame/Text (TMP)");
            if (mirror != null)
            {
                mirror.GetComponentInChildren<TextMeshProUGUI>(true).text = "Обычное";
                mirror.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
                mirror.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
            }
            Transform mirror_hard = __instance.transform.Find("[Script]EntranceItemsScrollView/[Rect]ViewPort/[Layout]Items/[Script]MirrorDungeonEntranceItemView_Single (1)/[Rect]Selectable/[Button]Stage Frame/Text (TMP)");
            if (mirror_hard != null)
            {
                mirror_hard.GetComponentInChildren<TextMeshProUGUI>(true).text = "Сложное";
                mirror_hard.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
                mirror_hard.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
            }
        }
        #endregion

        #region Vending Machine
        #endregion

        #region Formation UI
        [HarmonyPatch(typeof(FormationSwitchablePersonalityUIPanel), nameof(FormationSwitchablePersonalityUIPanel.Initialize))]
        [HarmonyPostfix]
        private static void FormationSwitchablePersonalityUIPanel_Init(FormationSwitchablePersonalityUIPanel __instance)
        {
            Transform id_mainui = __instance.transform.Find("[Script]RightPanel/[Script]FormationEgoList/[Text]Personality_Label");
            Transform ego_mainui_1 = __instance.transform.Find("[Script]RightPanel/[Script]FormationEgoList/[Text]Ego_Label");
            Transform ego_mainui_2 = __instance.transform.Find("[Script]ListTabRoot/[Layout]Tabs/[Toggle]Ego/[Text]E.G.O");
            if (ego_mainui_1 != null)
            {
                ego_mainui_1.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЭГО";
                ego_mainui_2.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЭГО";
                ego_mainui_2.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[3];
                ego_mainui_2.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[3].material;
            }
            if (id_mainui != null)
            {
                id_mainui.GetComponentInChildren<UITextDataLoader>().enabled = false;
                id_mainui.GetComponentInChildren<TextMeshProUGUI>(true).richText = false;
                id_mainui.GetComponentInChildren<TextMeshProUGUI>(true).autoSizeTextContainer = true;
                id_mainui.GetComponentInChildren<TextMeshProUGUI>(true).text = "Идентичности";
            }
        }
        [HarmonyPatch(typeof(FormationUIPanel), nameof(FormationUIPanel.Initialize))]
        [HarmonyPostfix]
        private static void FormationUIPanel_Init(FormationUIPanel __instance)
        {
            //MAIN UI HOVER EGO TEXT
            Transform ego = __instance.transform.Find("[Rect]MainPanel/[Rect]Contents/[Rect]Personalities/PersonalityDetail/[Button]Main/[Rect]Select/[Button]EGO/[Text]EGO");
            Transform ego_hover = __instance.transform.Find("[Rect]MainPanel/[Rect]Contents/[Rect]Personalities/PersonalityDetail/[Button]Main/[Rect]Select/[Button]EGO/[Text]EGO/[Text]EGO_Highlight");
            if (ego != null)
            {
                ego.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЭГО";
                ego.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[3];
                ego.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[3].material;
                ego_hover.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЭГО";
                ego_hover.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[3];
                ego_hover.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[3].material;
            }
            // TEAMS
            GameObject teams = GameObject.Find("[Canvas]RatioMainUI/[Rect]PanelRoot/[UIPanel]PersonalityFormationUIPanel(Clone)/[Rect]LeftObjects/[Rect]DeckSettings/[Rect]Contents/[Text]DeckTitle");
            if (teams != null)
            {
                teams.GetComponentInChildren<TextMeshProUGUI>(true).name = "КОМАНДЫ";
                teams.GetComponentInChildren<UITextDataLoader>(true).enabled = false;
                teams.GetComponentInChildren<TextMeshProUGUI>(true).text = "КОМАНДЫ";
            }
        }
        [HarmonyPatch(typeof(PersonalitySlotSkillInfoList), nameof(PersonalitySlotSkillInfoList.SetData))]
        [HarmonyPostfix]
        private static void PersonalitySlotSkillInfoList_Init(PersonalitySlotSkillInfoList __instance)
        {
            Transform guard = __instance._guardItem.transform.Find("Text (TMP)");
            if (guard != null)
            {
                guard.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЗАЩ.";
                guard.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[3];
                guard.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[3].material;
            }
        }
        [HarmonyPatch(typeof(FormationUIPanel), nameof(FormationUIPanel.InitializeBase))]
        [HarmonyPostfix]
        private static void FormationSecondChance_Init(FormationUIPanel __instance)
        {

            Transform skill = __instance.transform.Find("[Rect]MainPanel/[Rect]Contents/[Rect]Personalities/PersonalityDetail/[Button]Main/[Rect]Select/[Button]Skill/[Text]Skill");
            Transform skill_hover = __instance.transform.Find("[Rect]MainPanel/[Rect]Contents/[Rect]Personalities/PersonalityDetail/[Button]Main/[Rect]Select/[Button]Skill/[Text]Skill/[Text]Skill_Highlight");
            if (skill != null)
            {
                skill.GetComponentInChildren<TextMeshProUGUI>(true).text = "Атаки";
                skill_hover.GetComponentInChildren<TextMeshProUGUI>(true).text = "Атаки";
            }
        }
        [HarmonyPatch(typeof(FormationUIDeckToggle), nameof(FormationUIDeckToggle.SetText))]
        [HarmonyPostfix]
        private static void FormationUIDeckToggle_Init(FormationUIDeckToggle __instance)
        {
            __instance.tmp_title.text = __instance.tmp_title.text.Replace("#", "№");
        }
        #endregion

        #region Sinner UI
        [HarmonyPatch(typeof(UnitInformationController), nameof(UnitInformationController.Initialize))]
        [HarmonyPostfix]
        private static void UnitInformationController_Init(UnitInformationController __instance)
        {
            Transform max_level = __instance.transform.Find("[Script]UnitInformationController_Renewal/[Rect]UnitStatusContent/[Button]PersonaliyLevelUpButton/[Text]MAXContent");
            Transform max_thread = __instance.transform.Find("[Script]UnitInformationController_Renewal/[Rect]UnitStatusContent/[Button]GacksungLevelUpButton/[Text]MAXContent");
            if (max_level != null)
            {
                max_level.GetComponentInChildren<TextMeshProUGUI>(true).text = "MAKC.";
                max_thread.GetComponentInChildren<TextMeshProUGUI>(true).text = "MAKC.";
            }
        }
        [HarmonyPatch(typeof(UnitInformationSkillSlot), nameof(UnitInformationSkillSlot.SetData))]
        [HarmonyPostfix]
        private static void UnitInformationSkillSlot_Init(UnitInformationSkillSlot __instance)
        {
            GameObject skill = GameObject.Find("[Canvas]RatioMainUI/[Rect]PanelRoot/[Script]UnitInformationController(Clone)/[Script]UnitInformationController_Renewal/[Script]TabContentManager/[Layout]UnitInfoTabList/[Button]UnitInfoTab (1)/[Text]UnitInfoTabName");
            if (skill != null)
            {
                skill.GetComponentInChildren<TextMeshProUGUI>(true).text = "Атаки";
                skill.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[3];
                skill.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[3].material;
            }
            if (__instance.tmp_skillTier.text == "DEFENSE")
            {
                __instance.tmp_skillTier.text = "ЗАЩИТА";
                __instance.tmp_skillTier.GetComponent<TextMeshProUGUI>().enabled = true;
                __instance.tmp_skillTier.GetComponentInChildren<TextMeshProUGUI>(true).enabled = true;
            }
            __instance.tmp_skillTier.font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
            __instance.tmp_skillTier.fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
        }
        [HarmonyPatch(typeof(UnitInformationTabButton), nameof(UnitInformationTabButton.SetData))]
        [HarmonyPostfix]
        private static void UnitInformationTabButton_Init(UnitInformationTabButton __instance)
        {
            if (__instance.tmp_tabName.text == "E.G.O")
            {
                __instance.tmp_tabName.text = "ЭГО";
            }
        }
        #endregion

        #region Battle UI
        [HarmonyPatch(typeof(EvilStockController), nameof(EvilStockController.Init))]
        [HarmonyPostfix]
        private static void BattleUI_Init(EvilStockController __instance)
        {
            Transform min = __instance.transform.Find("[Rect]ActiveControl/[Rect]Pivot/[Rect]UpperSkillInfoUIStateField/[Rect]ChangeState/[Image]Min/[Text]MIN");
            Transform mid = __instance.transform.Find("[Rect]ActiveControl/[Rect]Pivot/[Rect]UpperSkillInfoUIStateField/[Rect]ChangeState/[Image]Mid/[Text]MID");
            Transform max = __instance.transform.Find("[Rect]ActiveControl/[Rect]Pivot/[Rect]UpperSkillInfoUIStateField/[Rect]ChangeState/[Image]Max/[Text]MAX");
            if (min != null)
            {
                min.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                min.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
                min.GetComponentInChildren<TextMeshProUGUI>(true).text = "<size=50>МИН</size>";
            }
            if (mid != null)
            {
                mid.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                mid.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
                mid.GetComponentInChildren<TextMeshProUGUI>(true).text = "<size=50>СР</size>";
            }
            if (max != null)
            {
                max.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                max.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
                max.GetComponentInChildren<TextMeshProUGUI>(true).text = "<size=50><cspace=-3px>МАКС</cspace></size>";
            }
            Transform ordealName = __instance.transform.Find("[Rect]ActiveControl/[Rect]Pivot/[Rect]KillCountUI/[Text]TestTitle");
            Transform killCount = __instance.transform.Find("[Rect]ActiveControl/[Rect]Pivot/[Rect]KillCountUI/[Text]StaticTitle");
            if (ordealName != null)
            {
                ordealName.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[3];
                ordealName.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[3].material;
            }
            if (killCount != null)
            {
                killCount.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[4];
                killCount.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[4].material;
            }
        }
        [HarmonyPatch(typeof(UpperSkillInfoUIStateSettingButton), nameof(UpperSkillInfoUIStateSettingButton.SetCurrentState))]
        [HarmonyPostfix]
        private static void UpperSkillInfoUIStateSettingButton_Init(UpperSkillInfoUIStateSettingButton __instance)
        {
            __instance._currentStateText.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
            __instance._currentStateText.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
            __instance._currentStateText.text = __instance._currentStateText.text.Replace("MAX", "<size=50><cspace=-3px>МАКС</cspace></size>");
            __instance._currentStateText.text = __instance._currentStateText.text.Replace("MID", "<size=50>CР</size>");
            __instance._currentStateText.text = __instance._currentStateText.text.Replace("MIN", "<size=50>МИН</size>");
        }
        [HarmonyPatch(typeof(BattleEncounterDamageTypoController), nameof(BattleEncounterDamageTypoController.SetDirection))]
        [HarmonyPostfix]
        private static void BattleEncounterDamageTypoController_Init(BattleEncounterDamageTypoController __instance)
        {
            __instance.playerDamagedSlot.tmp_total.text = "<size=40>ВСЕГО</size>";
            __instance.playerDamagedSlot.tmp_total.font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
            __instance.playerDamagedSlot.tmp_total.fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
            __instance.enemyDamagedSlot.tmp_total.text = "<size=40>ВСЕГО</size>";
            __instance.enemyDamagedSlot.tmp_total.font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
            __instance.enemyDamagedSlot.tmp_total.fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
            GameObject ego_t = GameObject.Find("[Script]BattleUIRoot/[Script]BattleSkillViewUIController/[Canvas]Canvas/[Script]SkillViewCanvas/[Rect]NameBox_EGO/[Image]EgoNameBg/[Rect]TotalDamageSlot/[Tmpro]Total");
            if (ego_t != null)
            {
                ego_t.GetComponentInChildren<TextMeshProUGUI>(true).text = "<size=40>ВСЕГО</size>";
                ego_t.GetComponentInChildren<TextMeshProUGUI>(true).name = "ВСЕГО";
                ego_t.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                ego_t.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
            }
        }
        [HarmonyPatch(typeof(ActTypoWaveStartUI), nameof(ActTypoWaveStartUI.Open))]
        [HarmonyPostfix]
        private static void ActTypoWaveStartUI_Init(ActTypoWaveStartUI __instance)
        {
            if (__instance.tmp_content.text.Contains("WAVE"))
            {
                __instance.tmp_content.text = __instance.tmp_content.text.Replace("WAVE", "ВОЛНА");
                __instance.tmp_content.font = LCB_Cyrillic_Font.tmpcyrillicfonts[3];
                __instance.tmp_content.fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[3].material;
            }
        }
        [HarmonyPatch(typeof(UnitInformationController), nameof(UnitInformationController.OpenInit))]
        [HarmonyPostfix]
        private static void UnitInfo_Init(UnitInformationController __instance)
        {
            Transform skill = __instance.transform.Find("[Script]UnitInformationController_Renewal/[Script]TabContentManager/[Layout]UnitInfoTabList/[Button]UnitInfoTab (1)/[Text]UnitInfoTabName");
            if (skill != null)
                skill.GetComponentInChildren<TextMeshProUGUI>(true).text = "Атаки";
        }
        #endregion

        #region Dungeon
        [HarmonyPatch(typeof(NodeUI), nameof(NodeUI.SetLineUIVisualActive))]
        [HarmonyPostfix]
        private static void Nodes_Init(NodeUI __instance)
        {
            __instance._startTypo.GetComponentInChildren<TextMeshProUGUI>().text = "НАЧАЛО";
            __instance._startTypo.GetComponentInChildren<TextMeshProUGUI>().font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
            __instance._startTypo.GetComponentInChildren<TextMeshProUGUI>().fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
        }
        #endregion

        #region Announcers
        [HarmonyPatch(typeof(AnnouncerSelectionUI), nameof(AnnouncerSelectionUI.UpdateBattleAnnouncer))]
        [HarmonyPostfix]
        private static void AnnouncerSelectionUI_Init(AnnouncerSelectionUI __instance)
        {
            Transform dante = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot/[Image]SelectedTag/[Text]Selected");
            if (dante != null)
            {
                dante.GetComponentInChildren<TextMeshProUGUI>(true).text = "Выбран";
            }
            Transform gregor = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot (1)/[Image]SelectedTag/[Text]Selected");
            if (gregor != null)
            {
                gregor.GetComponentInChildren<TextMeshProUGUI>(true).text = "Выбран";
            }
            Transform charon = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot (2)/[Image]SelectedTag/[Text]Selected");
            if (charon != null)
            {
                charon.GetComponentInChildren<TextMeshProUGUI>(true).text = "Выбрана";
            }
            Transform sinclair = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (sinclair != null)
            {
                sinclair.GetComponentInChildren<TextMeshProUGUI>(true).text = "Выбран";
                sinclair.GetComponentInChildren<TextMeshProUGUI>(true).name = "Выбран";
            }
            Transform rodya = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (rodya != null)
            {
                rodya.GetComponentInChildren<TextMeshProUGUI>(true).text = "Выбрана";
                rodya.GetComponentInChildren<TextMeshProUGUI>(true).name = "Выбрана";
            }
            Transform yisang = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (yisang != null)
            {
                yisang.GetComponentInChildren<TextMeshProUGUI>(true).text = "Выбран";
                yisang.GetComponentInChildren<TextMeshProUGUI>(true).name = "Выбран";
            }
            Transform yuri = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (yuri != null)
            {

                yuri.GetComponentInChildren<TextMeshProUGUI>(true).text = "Выбрана";
                yuri.GetComponentInChildren<TextMeshProUGUI>(true).name = "Выбрана";
            }
            Transform effiesod = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (effiesod != null)
            {
                effiesod.GetComponentInChildren<TextMeshProUGUI>(true).text = "Выбраны";
                effiesod.GetComponentInChildren<TextMeshProUGUI>(true).name = "Выбраны";
            }
            Transform ishmael = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (ishmael != null)
            {
                ishmael.GetComponentInChildren<TextMeshProUGUI>(true).text = "Выбрана";
                ishmael.GetComponentInChildren<TextMeshProUGUI>(true).name = "Выбрана";
            }
            Transform malkuth = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (malkuth != null)
            {
                malkuth.GetComponentInChildren<TextMeshProUGUI>(true).text = "Выбрана";
                malkuth.GetComponentInChildren<TextMeshProUGUI>(true).name = "Выбрана";
            }
            Transform pierrejack = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (pierrejack != null)
            {
                pierrejack.GetComponentInChildren<TextMeshProUGUI>(true).text = "Выбраны";
                pierrejack.GetComponentInChildren<TextMeshProUGUI>(true).name = "Выбраны";
            }
        }
        [HarmonyPatch(typeof(FormationBattleAnnouncerSelectionScrollViewItem), nameof(FormationBattleAnnouncerSelectionScrollViewItem.SetData))]
        [HarmonyPostfix]
        private static void FormationBattleAnnouncerSelectionScrollViewItem_Init(FormationBattleAnnouncerSelectionScrollViewItem __instance)
        {
            __instance.cg_selectedTag.GetComponentInChildren<TextMeshProUGUI>().font = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
            __instance.cg_selectedTag.GetComponentInChildren<TextMeshProUGUI>().fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
        }
        [HarmonyPatch(typeof(FormationUIPanel), nameof(FormationUIPanel.InitializeBase))]
        [HarmonyPostfix]
        private static void FixedAnnouncer_Init(FormationUIPanel __instance)
        {
            GameObject fixedAnnouncer = GameObject.Find("[Canvas]RatioMainUI/[Rect]PanelRoot/[UIPanel]PersonalityFormationUIPanel(Clone)/[Rect]LeftObjects/[Script]FormationBattleAnnouncer/[Rect]Contents/[Rect]LeftSide/[Rect]FixedLabel/[Image]FixedLabel/[Text]Fixed");
            if (fixedAnnouncer != null)
            {
                fixedAnnouncer.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[4];
                fixedAnnouncer.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[4].material;
            }
        }
        #endregion

        #region SeasonTag
        [HarmonyPatch(typeof(UnitInfoPersonalityNameTag), nameof(UnitInfoPersonalityNameTag.SetSeasonTagUI))]
        [HarmonyPostfix]
        private static void UnitInfoPersonalityNameTag_Init(UnitInfoPersonalityNameTag __instance)
        {
            string text = __instance._seasonTagUI.tmp_season.text.Replace("SEASON", "СЕЗОН");
            __instance._seasonTagUI.tmp_season.text = text.Replace("WALPURGISNACHT", "<cspace=-1px>ВАЛЬПУРГИЕВА НОЧЬ</cspace>");
            __instance._seasonTagUI.tmp_season.font = LCB_Cyrillic_Font.GetCyrillicFonts(0);
            __instance._seasonTagUI.tmp_season.fontMaterial = LCB_Cyrillic_Font.GetCyrillicMats(0);
        }
        [HarmonyPatch(typeof(UnitInformationSeasonTagUI), nameof(UnitInformationSeasonTagUI.SetSeasonData))]
        [HarmonyPostfix]
        private static void UnitInformationSeasonTagUI_Init(UnitInformationSeasonTagUI __instance)
        {
            string text = __instance.tmp_season.text.Replace("SEASON", "СЕЗОН");
            __instance.tmp_season.text = text.Replace("WALPURGISNACHT -", "<cspace=-6px>ВАЛЬПУРГИЕВА НОЧЬ -</cspace>");
            __instance.tmp_season.font = LCB_Cyrillic_Font.GetCyrillicFonts(0);
            __instance.tmp_season.fontMaterial = LCB_Cyrillic_Font.GetCyrillicMats(0);
        }
        #endregion

        #region BattlePass
        public static void bebaspass(List<Transform> transforms)
        {
            foreach (Transform t in transforms)
            {
                t.GetComponentInChildren<TextMeshProUGUI>(true).m_fontAsset = LCB_Cyrillic_Font.GetCyrillicFonts(0);
                t.GetComponentInChildren<TextMeshProUGUI>(true).m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(1);
            }
        }
        [HarmonyPatch(typeof(BattlePassUIPopup), nameof(BattlePassUIPopup.localizeHelper.Initialize))]
        [HarmonyPostfix]
        private static void BattlePass_Init(BattlePassUIPopup __instance)
        {
            Transform limbus_pass = __instance.transform.Find("[Rect]Right/[Rect]Ticket/[Button]TicketImage_BuyNotYet/[Rect]Texts/[Text]LIMBUSPASS");
            Transform limbus_pass_bought = __instance.transform.Find("[Rect]Right/[Rect]Ticket/[Image]LimTicketImage_YesIHave/[LocalizeText]Useing/[Text]LimbusPass");
            Transform battle_pass = __instance.transform.Find("[Rect]Right/[Rect]Ticket/[Button]TicketImage_BuyNotYet/[Rect]Texts/[LocalizeText]Buying");
            Transform battle_pass_bought = __instance.transform.Find("[Rect]Right/[Rect]Ticket/[Image]LimTicketImage_YesIHave/[LocalizeText]Useing");
            Transform package = __instance.transform.Find("[Rect]Right/[Rect]Package/[Text]Title");
            Transform package_popUp = __instance.transform.Find("BattlePassPurchaseLimbusOrPackagePopup/PanelGroup/PopupBase/Container/[Rect]Contents/[Button]PurchasePackage/[Text]Title");
            limbus_pass.GetComponentInChildren<TextMeshProUGUI>(true).text = "<cspace=-2px>ЛИМБУС ПАСС</cspace>";
            limbus_pass_bought.GetComponentInChildren<TextMeshProUGUI>(true).text = "<cspace=-2px>ЛИМБУС ПАСС</cspace>";
            List<Transform> transforms = new List<Transform> { limbus_pass, limbus_pass_bought, battle_pass, battle_pass_bought, package, package_popUp, __instance.tmp_be_in_use.transform, __instance.limbusPassPopup.tmp_description.transform};
            bebaspass(transforms);
        }
        [HarmonyPatch(typeof(BattlePassPurchasedModal), nameof(BattlePassPurchasedModal.SetCurrentSeasonOpen))]
        [HarmonyPostfix]
        private static void Activation_Init(BattlePassPurchasedModal __instance)
        {
            Transform limbuspass_active = __instance.transform.Find("MainPanel/[Text]Activation");
            if (limbuspass_active != null)
            {
                limbuspass_active.GetComponentInChildren<TextMeshProUGUI>(true).m_fontAsset = LCB_Cyrillic_Font.GetCyrillicFonts(0);
                limbuspass_active.GetComponentInChildren<TextMeshProUGUI>(true).m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(2);
            }
        }
        #endregion

        #region Story UI
        [HarmonyPatch(typeof(MainStorySlot), nameof(MainStorySlot.SetData))]
        [HarmonyPostfix]
        private static void MainStorySlot_Init(MainStorySlot __instance)
        {
            GameObject episode = GameObject.Find("[Canvas]RatioMainUI/[Rect]PanelRoot/[UIPanel]StoryUIPanel(Clone)/[Rect]MainStoryUI/[Rect]MainStory/Scroll View/Viewport/Content/[Rect]MainStorySlot(Clone)/[Rect]Panel/[Rect]Title/[Text]Chapter");
            if (episode != null)
            {
                episode.GetComponentInChildren<TextMeshProUGUI>(true).name = "ЭПИЗОД";
                episode.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЭПИЗОД";
                episode.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                episode.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
            }
            __instance._conditionComingSoonText.GetComponent<TextMeshProUGUI>().text = "Скоро...";
            __instance._conditionComingSoonText.GetComponent<TextMeshProUGUI>().font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
            __instance._conditionComingSoonText.GetComponent<TextMeshProUGUI>().fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
        }
        [HarmonyPatch(typeof(OtherStorySlot), nameof(OtherStorySlot.SetData))]
        [HarmonyPostfix]
        private static void OtherStorySlot_Init(OtherStorySlot __instance)
        {
            Transform coming_soon = __instance.transform.Find("[Button]OtherStorySlot/[Rect]LockObject/[Text]LockComingSoon");
            if (coming_soon != null)
            {
                coming_soon.GetComponent<TextMeshProUGUI>().text = "Скоро";
                coming_soon.GetComponent<TextMeshProUGUI>().font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                coming_soon.GetComponent<TextMeshProUGUI>().fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
            }
        }
        [HarmonyPatch(typeof(OtherStorySlot), nameof(OtherStorySlot.SetCallback))]
        [HarmonyPostfix]
        private static void OSS_Init(OtherStorySlot __instance)
        {
            Transform episode = __instance.transform.Find("[Button]OtherStorySlot/[Rect]UnLockObject/[Text]EPISODE");
            if (episode != null)
            {
                episode.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЭПИЗОД";
                episode.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                episode.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
            }
        }
        [HarmonyPatch(typeof(BattleSkillViewUIOverClock), nameof(BattleSkillViewUIOverClock.SetActiveOverClock))]
        [HarmonyPostfix]
        private static void BattleSkillViewUIOverClock_Init(BattleSkillViewUIOverClock __instance)
        {
            GameObject over_s = GameObject.Find("[Script]BattleUIRoot/[Script]BattleSkillViewUIController/[Canvas]Canvas/[Script]SkillViewCanvas/OverClock");
            GameObject over_i = GameObject.Find("[Script]BattleUIRoot/[Script]BattleSkillViewUIController/[Canvas]Canvas/[Script]SkillViewCanvas/OverClock/OverClockImg");
            if (over_s != null)
            {
                if (over_s.GetComponentInChildren<BattleSkillViewUIOverClock>(true)._curString == "Stable")
                {
                    over_i.GetComponentInChildren<UnityEngine.UI.Image>(true).m_OverrideSprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_Overclock_Legacy_2"];
                    over_i.GetComponentInChildren<UnityEngine.UI.Image>(true).name = "STABLESHIT";
                }
            }
        }
        public static void getBurnTS(List<Transform> transforms)
        {
            foreach (Transform t in transforms)
            {
                getBurnT(t);
            }
        }
        public static void getBurnT(Transform t)
        {
            Color yellowg = new Color(1.0f, 0.306f, 0, 0.502f);
            t.GetComponentInChildren<TextMeshProUGUI>().m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(6);
            t.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.EnableKeyword("GLOW_ON");
            t.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetColor("_GlowColor", yellowg);
            t.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat("_GlowInner", (float)0.6);
            t.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat("_GlowPower", 3);
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
        [HarmonyPatch(typeof(GetNewCardTimelineScriptBase), nameof(GetNewCardTimelineScriptBase.Init))]
        [HarmonyPostfix]
        private static void GetNewCardTimelineScriptBase_Init(GetNewCardTimelineScriptBase __instance)
        {
            Transform subtitle = __instance._subtitle.transform.Find("TextRect/TextLayout/[LocalizeText]Subtitle");
            subtitle.GetComponentInChildren<TextMeshProUGUI>().m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(10);
        }
        [HarmonyPatch(typeof(MainLobbyUIPanel), nameof(MainLobbyUIPanel.StartDialog))]
        [HarmonyPostfix]
        private static void MainLobbyUIPanel_Init(MainLobbyUIPanel __instance)
        {
            __instance.tmpro_dialog.name = "DIALOG";
            __instance.tmpro_dialog.m_sharedMaterial = LCB_Cyrillic_Font.GetCyrillicMats(10);
            __instance.tmpro_dialog.fontMaterial.EnableKeyword("GLOW_ON");
            __instance.tmpro_dialog.fontMaterial.SetFloat("_GlowInner", (float)0.6);
            __instance.tmpro_dialog.fontMaterial.SetFloat("_GlowOuter", (float)0.6);
            __instance.tmpro_dialog.fontMaterial.SetFloat("_GlowPower", 3);
        }
        [HarmonyPatch(typeof(VendingMachineUIPanel), "Initialize")]
        [HarmonyPostfix]
        private static void VendingMachineUIPanel_Init(VendingMachineUIPanel __instance)
        {
            Transform comment = __instance.transform.Find("GoodsStoreAreaMaster/PageButtonArea/BackPanel/Btn_TypeAnnouncer/Tmp_Announcer");
            Transform ego_dispence = __instance.transform.Find("GoodsStoreAreaMaster/PageButtonArea/BackPanel/Btn_TypeEGO/Tmp_EGO");
            if (ego_dispence != null)
            {
                ego_dispence.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЭГО";
            }
            if (comment != null)
            {
                comment.GetComponentInChildren<TextMeshProUGUI>(true).text = "<cspace=-1px>Комментатор</cspace>";
            }
            __instance._soldOut.GetComponentInChildren<UnityEngine.UI.Image>(true).sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_SoldOut"];

        }
        private static string getTimerD(int days)
        {
            int lastDigit = days % 10;
            int lastTwoDigits = days % 100;

            if (lastTwoDigits >= 11 && lastTwoDigits <= 19)
            {
                return "дней";
            }
            else if (lastDigit == 1)
            {
                return "день";
            }
            else if (lastDigit >= 2 && lastDigit <= 4)
            {
                return "дня";
            }
            else
            {
                return "дней";
            }
        }

        private static string getTimerH(int hours)
        {
            int lastDigit = hours % 10;
            int lastTwoDigits = hours % 100;

            if (lastTwoDigits >= 11 && lastTwoDigits <= 19)
            {
                return "часов";
            }
            else if (lastDigit == 1)
            {
                return "час";
            }
            else if (lastDigit >= 2 && lastDigit <= 4)
            {
                return "часа";
            }
            else
            {
                return "часов";
            }
        }

        [HarmonyPatch(typeof(EventTimerUI), nameof(EventTimerUI.UpdateRemainEventTime))]
        [HarmonyPostfix]
        private static void EventTimerUI_Init(EventTimerUI __instance)
        {
            __instance.tmp_remainingTime.name = "EVENT!";
            string pattern = @"(\d+ дней)(\d+ часов)";
            Match match = Regex.Match(__instance.tmp_remainingTime.text, pattern);
            if (match.Success)
            {
                int days = int.Parse(match.Groups[1].Value.Split(' ')[0]);
                int hours = int.Parse(match.Groups[2].Value.Split(' ')[0]);
                string dayWord = getTimerD(days);
                string hourWord = getTimerH(hours);
                __instance.tmp_remainingTime.text = Regex.Replace(__instance.tmp_remainingTime.text, pattern, days + " " + dayWord + " " + hours + " " + hourWord);
            }
        }
        [HarmonyPatch(typeof(BattlePassUIPopup), nameof(BattlePassUIPopup.SetLevelText))]
        [HarmonyPostfix]
        private static void BattlePassUIPopup_Init(BattlePassUIPopup __instance)
        {
            __instance.tmp_remainDate.GetComponentInChildren<TextMeshProUGUI>().text = "PIZDEC";
            __instance.tmp_remainDate.GetComponentInChildren<TextMeshProUGUI>().name = "PIZDEC";
            GameObject aahh = GameObject.Find("[Canvas]RatioMainUI/[Rect]PopupRoot/[UIPopup]BattlePassUIPopup(Clone)/[Rect]LimitTime/[Text]RemainTime");

            aahh.GetComponentInChildren<TextMeshProUGUI>().name = "";
            aahh.GetComponentInChildren<TextMeshProUGUI>().text = "";
            //[Canvas]RatioMainUI/[Rect]PopupRoot/[UIPopup]BattlePassUIPopup(Clone)/[Rect]LimitTime/[Text]RemainTime
            /*
            string text = __instance.tmp_remainDate.text; // Ваше исходное значение

            string[] parts = text.Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i] == "дней" && int.Parse(parts[i - 1]) == 1)
                {
                    parts[i] = "день";
                }
                else if (parts[i] == "часов" && int.Parse(parts[i - 1]) == 1)
                {
                    parts[i] = "час";
                }
            }
            __instance.tmp_remainDate.text = string.Join(" ", parts); // Обновленное значение
            */
        }
        #endregion
    }
}