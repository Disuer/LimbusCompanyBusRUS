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

namespace LimbusLocalizeRUS
{
    internal class LCBR_TextUI
    {
        #region Login
        [HarmonyPatch(typeof(NetworkingUI), "Initialize")]
        [HarmonyPostfix]
        private static void NetworkingUI_Init(NetworkingUI __instance)
        {
            Transform connection = __instance.transform.Find("connecting_background/tmp_connecting");
            if (connection != null)
            {
                connection.GetComponentInChildren<TextMeshProUGUI>(true).text = "ПОДКЛЮЧЕНИЕ";
                connection.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
                connection.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
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
            if (district4 != null)
            {
                district4.GetComponentInChildren<TextMeshProUGUI>(true).text = "4-й район";
                district4.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
            }
            if (district10 != null)
            {
                district10.GetComponentInChildren<TextMeshProUGUI>(true).text = "10-й район";
                district10.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
            }
            if (district11 != null)
            {
                district11.GetComponentInChildren<TextMeshProUGUI>(true).text = "11-й район";
                district11.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
            }
            if (district21 != null)
            {
                district21.GetComponentInChildren<TextMeshProUGUI>(true).text = "21-й район";
                district21.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
            }
        }
        #endregion

        #region Mirror Dungeons
        [HarmonyPatch(typeof(MirrorDungeonEntranceScrollUIPanel), nameof(MirrorDungeonEntranceScrollUIPanel.Initialize))]
        [HarmonyPostfix]
        private static void MirrorDungeonDoors_Init(MirrorDungeonEntranceScrollUIPanel __instance)
        {
            Transform dungeon_1 = __instance.transform.Find("[Script]EntranceItemsScrollView/[Rect]ViewPort/[Layout]Items/[Script]MirrorDungeonEntranceItemView/[Rect]Selectable/[Tmpro]DungeonLabel");
            if (dungeon_1 != null)
            {
                dungeon_1.GetComponentInChildren<TextMeshProUGUI>(true).text = "<cspace=-2px>Подземелье</cspace>";
                dungeon_1.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
                dungeon_1.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
            }
            Transform dungeon_2 = __instance.transform.Find("[Script]EntranceItemsScrollView/[Rect]ViewPort/[Layout]Items/[Script]MirrorDungeonEntranceItemView (1)/[Rect]Selectable/[Tmpro]DungeonLabel");
            if (dungeon_2 != null)
            {
                dungeon_2.GetComponentInChildren<TextMeshProUGUI>(true).text = "<cspace=-2px>Подземелье</cspace>";
                dungeon_2.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
                dungeon_2.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
            }
            Transform mirror = __instance.transform.Find("[Script]EntranceItemsScrollView/[Rect]ViewPort/[Layout]Items/[Script]MirrorDungeonEntranceItemView/[Rect]Selectable/[Button]Stage Frame/Text (TMP)");
            if (mirror != null)
            {
                mirror.GetComponentInChildren<TextMeshProUGUI>(true).text = "Обычное";
                mirror.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
                mirror.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
            }
        }
        #endregion

        #region Vending Machine
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
        }
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
        [HarmonyPatch(typeof(FormationSwitchablePersonalityUIPanel), nameof(FormationSwitchablePersonalityUIPanel.InitRedDot))]
        [HarmonyPostfix]
        private static void Switch_Init(FormationSwitchablePersonalityUIPanel __instance)
        {

            Transform identity_mainui = __instance.transform.Find("[Script]RightPanel/[Script]FormationEgoList/[Text]Personality_Label");
            if (identity_mainui != null)
            {
                identity_mainui.GetComponentInChildren<TextMeshProUGUI>(true).text = "Идентичности";
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
            GameObject komanda = GameObject.Find("[Canvas]RatioMainUI/[Rect]PanelRoot/[UIPanel]PersonalityFormationUIPanel(Clone)/[Rect]LeftObjects/[Rect]DeckSettings/[Rect]Contents/[Text]DeckTitle");
            if(komanda != null)
            {
                komanda.GetComponentInChildren<TextMeshProUGUI>(true).name = "КОМАНДЫ";
                komanda.GetComponentInChildren<UITextDataLoader>(true).enabled = false;
                komanda.GetComponentInChildren<TextMeshProUGUI>(true).text = "КОМАНДЫ";
            }
        }
        [HarmonyPatch(typeof(PersonalitySlotSkillInfoList), nameof(PersonalitySlotSkillInfoList.SetData))]
        [HarmonyPostfix]
        private static void PersonalitySlotSkillInfoList_Init(PersonalitySlotSkillInfoList __instance)
        {
            Transform guard = __instance._guardItem.transform.Find("Text (TMP)");
            if(guard != null)
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
        [HarmonyPatch(typeof(FormationUIDeckToggle), nameof(FormationUIDeckToggle.Initialize))]
        [HarmonyPostfix]
        private static void FormationUIDeckToggle_Init(FormationUIDeckToggle __instance)
        {
            __instance.tmp_title.text = __instance.tmp_title.text.Replace("#", "№");
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

        #region Sinner UI
        [HarmonyPatch(typeof(UnitInformationController), nameof(UnitInformationController.Init))]
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
        #endregion

        #region Battle UI
        #endregion

        #region Announcers
        [HarmonyPatch(typeof(AnnouncerSelectionUI), nameof(AnnouncerSelectionUI.UpdateBattleAnnouncer))]
        [HarmonyPostfix]
        private static void AnnouncerSelectionUI_Init(AnnouncerSelectionUI __instance)
        {
            Transform dante = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/[Script]BattleAnnouncerSlot/[Image]SelectedTag/[Text]Selected");
            Transform gregor = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/[Script]BattleAnnouncerSlot (1)/[Image]SelectedTag/[Text]Selected");
            Transform charon = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/[Script]BattleAnnouncerSlot (2)/[Image]SelectedTag/[Text]Selected");
            if (dante != null)
            {
                dante.GetComponentInChildren<TextMeshProUGUI>(true).text = "Выбран";
                dante.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                dante.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
            }
            if (gregor != null)
            {
                gregor.GetComponentInChildren<TextMeshProUGUI>(true).text = "Выбран";
                gregor.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                gregor.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
            }
            if (charon != null)
            {
                charon.GetComponentInChildren<TextMeshProUGUI>(true).text = "Выбрана";
                charon.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                charon.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
            }
            Transform sinclair = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (sinclair != null)
            {
                sinclair.GetComponentInChildren<TextMeshProUGUI>(true).name = "Выбран";
                sinclair.GetComponentInChildren<TextMeshProUGUI>(true).text.Replace("SELECTED", "Выбран");
                sinclair.GetComponentInChildren<TextMeshProUGUI>(true).m_text.Replace("SELECTED", "Выбран");
                sinclair.GetComponentInChildren<TextMeshProUGUI>(true).text = "Выбран";
                sinclair.GetComponentInChildren<TextMeshProUGUI>(true).m_text = "Выбран";
                sinclair.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                sinclair.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
            }
            Transform rodya = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (rodya != null)
            {
                rodya.GetComponentInChildren<TextMeshProUGUI>(true).name = "Выбран";
                rodya.GetComponentInChildren<TextMeshProUGUI>(true).text.Replace("SELECTED", "Выбрана");
                rodya.GetComponentInChildren<TextMeshProUGUI>(true).m_text.Replace("SELECTED", "Выбрана");
                rodya.GetComponentInChildren<TextMeshProUGUI>(true).text = "Выбрана";
                rodya.GetComponentInChildren<TextMeshProUGUI>(true).m_text = "Выбрана";
                rodya.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                rodya.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
            }
            Transform yisang = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (yisang != null)
            {
                yisang.GetComponentInChildren<TextMeshProUGUI>(true).name = "Выбран";
                yisang.GetComponentInChildren<TextMeshProUGUI>(true).text.Replace("SELECTED", "Выбран");
                yisang.GetComponentInChildren<TextMeshProUGUI>(true).m_text.Replace("SELECTED", "Выбран");
                yisang.GetComponentInChildren<TextMeshProUGUI>(true).text = "Выбран";
                yisang.GetComponentInChildren<TextMeshProUGUI>(true).m_text = "Выбран";
                yisang.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                yisang.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
            }
            Transform yuri = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (yuri != null)
            {
                yuri.GetComponentInChildren<TextMeshProUGUI>(true).name = "Выбрана";
                yuri.GetComponentInChildren<TextMeshProUGUI>(true).text.Replace("SELECTED", "Выбрана");
                yuri.GetComponentInChildren<TextMeshProUGUI>(true).m_text.Replace("SELECTED", "Выбрана");
                yuri.GetComponentInChildren<TextMeshProUGUI>(true).text = "Выбрана";
                yuri.GetComponentInChildren<TextMeshProUGUI>(true).m_text = "Выбрана";
                yuri.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                yuri.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
            }
            Transform epie = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (epie != null)
            {
                epie.GetComponentInChildren<TextMeshProUGUI>(true).name = "Выбраны";
                epie.GetComponentInChildren<TextMeshProUGUI>(true).text.Replace("SELECTED", "Выбраны");
                epie.GetComponentInChildren<TextMeshProUGUI>(true).m_text.Replace("SELECTED", "Выбраны");
                epie.GetComponentInChildren<TextMeshProUGUI>(true).text = "Выбраны";
                epie.GetComponentInChildren<TextMeshProUGUI>(true).m_text = "Выбраны";
                epie.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                epie.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
            }
            Transform ishmael = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (ishmael != null)
            {
                ishmael.GetComponentInChildren<TextMeshProUGUI>(true).name = "Выбрана";
                ishmael.GetComponentInChildren<TextMeshProUGUI>(true).text.Replace("SELECTED", "Выбрана");
                ishmael.GetComponentInChildren<TextMeshProUGUI>(true).m_text.Replace("SELECTED", "Выбрана");
                ishmael.GetComponentInChildren<TextMeshProUGUI>(true).text = "Выбрана";
                ishmael.GetComponentInChildren<TextMeshProUGUI>(true).m_text = "Выбрана";
                ishmael.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                ishmael.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
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
            __instance._seasonTagUI.tmp_season.font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
            __instance._seasonTagUI.tmp_season.fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
        }
        [HarmonyPatch(typeof(UnitInformationSeasonTagUI), nameof(UnitInformationSeasonTagUI.SetSeasonData))]
        [HarmonyPostfix]
        private static void UnitInformationSeasonTagUI_Init(UnitInformationSeasonTagUI __instance)
        {
            string text = __instance.tmp_season.text.Replace("SEASON", "СЕЗОН");
            __instance.tmp_season.text = text.Replace("WALPURGISNACHT", "<cspace=-1px>ВАЛЬПУРГИЕВА НОЧЬ</cspace>");
            __instance.tmp_season.font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
            __instance.tmp_season.fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
        }
        #endregion

        #region BattlePass
        [HarmonyPatch(typeof(BattlePassUIPopup), nameof(BattlePassUIPopup.localizeHelper.Initialize))]
        [HarmonyPostfix]
        private static void BattlePass_Init(BattlePassUIPopup __instance)
        {
            Transform limbus_pass = __instance.transform.Find("[Rect]Right/[Rect]Ticket/[Button]TicketImage_BuyNotYet/[Rect]Texts/[Text]LIMBUSPASS");
            Transform limbus_pass_bought = __instance.transform.Find("[Rect]Right/[Rect]Ticket/[Image]LimTicketImage_YesIHave/[LocalizeText]Useing/[Text]LimbusPass");
            Transform battle_pass = __instance.transform.Find("[Rect]Right/[Rect]Ticket/[Button]TicketImage_BuyNotYet/[Rect]Texts/[LocalizeText]Buying");
            Transform battle_pass_bought = __instance.transform.Find("[Rect]Right/[Rect]Ticket/[Image]LimTicketImage_YesIHave/[LocalizeText]Useing");
            Transform package = __instance.transform.Find("[Rect]Right/[Rect]Package/[Text]Title");
            if (limbus_pass != null)
            {
                limbus_pass.GetComponentInChildren<TextMeshProUGUI>(true).text = "<cspace=-2px>ЛИМБУС ПАСС</cspace>";
                limbus_pass.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
                limbus_pass.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
                battle_pass.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
                battle_pass.GetComponentInChildren<TextMeshProUGUI>(true).m_fontAsset = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
                battle_pass.GetComponentInChildren<TextMeshProUGUI>(true).m_currentFontAsset = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
                battle_pass.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
                battle_pass.GetComponentInChildren<TextMeshProUGUI>(true).m_fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
                battle_pass.GetComponentInChildren<TextMeshProUGUI>(true).m_currentMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
            }
            if (limbus_pass_bought != null)
            {
                limbus_pass_bought.GetComponentInChildren<TextMeshProUGUI>(true).text = "<cspace=-2px>ЛИМБУС ПАСС</cspace>";
                limbus_pass_bought.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
                limbus_pass_bought.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
                battle_pass_bought.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
                battle_pass_bought.GetComponentInChildren<TextMeshProUGUI>(true).m_fontAsset = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
                battle_pass_bought.GetComponentInChildren<TextMeshProUGUI>(true).m_currentFontAsset = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
                battle_pass_bought.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
                battle_pass_bought.GetComponentInChildren<TextMeshProUGUI>(true).m_fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
                battle_pass_bought.GetComponentInChildren<TextMeshProUGUI>(true).m_currentMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
            }
            package.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
            package.GetComponentInChildren<TextMeshProUGUI>(true).m_fontAsset = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
            package.GetComponentInChildren<TextMeshProUGUI>(true).m_currentFontAsset = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
            package.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
            package.GetComponentInChildren<TextMeshProUGUI>(true).m_fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
            package.GetComponentInChildren<TextMeshProUGUI>(true).m_currentMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
            Transform package_popUp = __instance.transform.Find("BattlePassPurchaseLimbusOrPackagePopup/PanelGroup/PopupBase/Container/[Rect]Contents/[Button]PurchasePackage/[Text]Title");
            if (package_popUp != null)
            {
                package_popUp.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
                package_popUp.GetComponentInChildren<TextMeshProUGUI>(true).m_fontAsset = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
                package_popUp.GetComponentInChildren<TextMeshProUGUI>(true).m_currentFontAsset = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
                package_popUp.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
                package_popUp.GetComponentInChildren<TextMeshProUGUI>(true).m_fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
                package_popUp.GetComponentInChildren<TextMeshProUGUI>(true).m_currentMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
            }
            __instance.limbusPassPopup.tmp_description.font = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
            __instance.limbusPassPopup.tmp_description.fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
            __instance.tmp_be_in_use.font = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
            __instance.tmp_be_in_use.fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
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
                episode.GetComponentInChildren<TextMeshProUGUI>(true).m_text = "ЭПИЗОД";
                episode.GetComponentInChildren<TextMeshProUGUI>(true).text.Replace("EPISODE", "ЭПИЗОД");
                episode.GetComponentInChildren<TextMeshProUGUI>(true).m_text.Replace("EPISODE", "ЭПИЗОД");
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
            //[Button]OtherStorySlot/[Rect]UnLockObject/[Text]EPISODE
            if (episode != null)
            {
                episode.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЭПИЗОД";
                episode.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                episode.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
            }
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
        //[Script]BattleUIRoot/[Canvas]BattleFrontUI/[Script]ActTypoController/[Rect]Active/[Script]ActTypoWaveStartUI/[Tmpro]Content
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
        [HarmonyPatch(typeof(BattleSkillViewUIOverClock), nameof(BattleSkillViewUIOverClock.SetActiveOverClock))]
        [HarmonyPostfix]
        private static void BattleSkillViewUIOverClock_Init(BattleSkillViewUIOverClock __instance)
        {
            GameObject over_s = GameObject.Find("[Script]BattleUIRoot/[Script]BattleSkillViewUIController/[Canvas]Canvas/[Script]SkillViewCanvas/OverClock");
            GameObject over_i = GameObject.Find("[Script]BattleUIRoot/[Script]BattleSkillViewUIController/[Canvas]Canvas/[Script]SkillViewCanvas/OverClock/OverClockImg");
            if (over_s != null)
            {
                if(over_s.GetComponentInChildren<BattleSkillViewUIOverClock>(true)._curString == "Stable")
                {
                    over_i.GetComponentInChildren<Image>(true).m_OverrideSprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_Overclock_Legacy_2"];
                    over_i.GetComponentInChildren<Image>(true).name = "STABLESHIT";
                }
            }
        }
        [HarmonyPatch(typeof(FormationPersonalityUI), nameof(FormationPersonalityUI.SetData))]
        [HarmonyPostfix]
        private static void FormationPersonalityUI_Init(FormationPersonalityUI __instance)
        {
            __instance.img_isParticipaged.sprite = LCBR_ReadmeManager.ReadmeSprites["LCBR_InParty"];
        }
        [HarmonyPatch(typeof(RewardDungeonUIPanel), nameof(RewardDungeonUIPanel.Initialize))]
        [HarmonyPostfix]
        private static void RewardDungeonUIPanel_Init(RewardDungeonUIPanel __instance)
        {
            GameObject mytext = GameObject.Find("[Canvas]RatioMainUI/[Rect]PanelRoot/[UIPanel]RewardDungeonUIPanel(Clone)/[Script]CheckPopup/PanelGroup/PopupBase/Container/[Rect]ButtonsLayoutGroup_231116/ThreadDungeonselectStageButton_231116/AutoBackgroundSizeText/Text (TMP)");
            if(mytext!= null)
            {
                mytext.GetComponentInChildren<UITextDataLoader>().enabled = false;
                mytext.GetComponentInChildren<TextMeshProUGUI>(true).text = "Мой текст";
            }
        }
        #endregion
    }
}