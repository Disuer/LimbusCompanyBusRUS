using BattleUI;
using BattleUI.Information;
using HarmonyLib;
using MainUI;
using MainUI.VendingMachine;
using TMPro;
using UnityEngine;
using static UI.Utility.InfoModels;

namespace LimbusLocalizeRUS
{
    internal class LCBR_TextUI
    {
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
        [HarmonyPatch(typeof(VendingMachineUIPanel), "Initialize")]
        [HarmonyPostfix]
        private static void VendingMachineUIPanel_Init(VendingMachineUIPanel __instance)
        {
            Transform ego_dispence = __instance.transform.Find("GoodsStoreAreaMaster/PageButtonArea/BackPanel/Btn_TypeEGO/Tmp_EGO");
            if (ego_dispence != null)
            {
                ego_dispence.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЭГО";
            }
        }
        [HarmonyPatch(typeof(FormationSwitchablePersonalityUIPanel), "Initialize")]
        [HarmonyPostfix]
        private static void FormationSwitchablePersonalityUIPanel_Init(FormationSwitchablePersonalityUIPanel __instance)
        {
            Transform ego_mainui_1 = __instance.transform.Find("[Script]RightPanel/[Script]FormationEgoList/[Text]Ego_Label");
            Transform ego_mainui_2 = __instance.transform.Find("[Script]ListTabRoot/[Layout]Tabs/[Toggle]Ego/[Text]E.G.O");
            if (ego_mainui_1 != null)
            {
                ego_mainui_1.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЭГО";
                ego_mainui_2.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЭГО";
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

            //SINNERS DEF SLOTS
            Transform yisang_def = __instance.transform.Find("[Rect]MainPanel/[Rect]Contents/[Rect]Personalities/[Layout]Personalities/PersonalityFormationSlot_Yisang/[Rect]AdditionalInfo/PersonalitySlotSkillInfoItemList/PersonalitySlotSkillInfoItem (GUARD)/Text (TMP)");
            Transform faust_def = __instance.transform.Find("[Rect]MainPanel/[Rect]Contents/[Rect]Personalities/[Layout]Personalities/PersonalityFormationSlot_Faust/[Rect]AdditionalInfo/PersonalitySlotSkillInfoItemList/PersonalitySlotSkillInfoItem (GUARD)/Text (TMP)");
            Transform donquixote_def = __instance.transform.Find("[Rect]MainPanel/[Rect]Contents/[Rect]Personalities/[Layout]Personalities/PersonalityFormationSlot_Donqui/[Rect]AdditionalInfo/PersonalitySlotSkillInfoItemList/PersonalitySlotSkillInfoItem (GUARD)/Text (TMP)");
            Transform ryoshu_def = __instance.transform.Find("[Rect]MainPanel/[Rect]Contents/[Rect]Personalities/[Layout]Personalities/PersonalityFormationSlot_Ryoshu/[Rect]AdditionalInfo/PersonalitySlotSkillInfoItemList/PersonalitySlotSkillInfoItem (GUARD)/Text (TMP)");
            Transform meur_def = __instance.transform.Find("[Rect]MainPanel/[Rect]Contents/[Rect]Personalities/[Layout]Personalities/PersonalityFormationSlot_Meursault/[Rect]AdditionalInfo/PersonalitySlotSkillInfoItemList/PersonalitySlotSkillInfoItem (GUARD)/Text (TMP)");
            Transform honglu_def = __instance.transform.Find("[Rect]MainPanel/[Rect]Contents/[Rect]Personalities/[Layout]Personalities/PersonalityFormationSlot_Honglu/[Rect]AdditionalInfo/PersonalitySlotSkillInfoItemList/PersonalitySlotSkillInfoItem (GUARD)/Text (TMP)");
            Transform heathcliff_def = __instance.transform.Find("[Rect]MainPanel/[Rect]Contents/[Rect]Personalities/[Layout]Personalities/PersonalityFormationSlot_Heathcliff/[Rect]AdditionalInfo/PersonalitySlotSkillInfoItemList/PersonalitySlotSkillInfoItem (GUARD)/Text (TMP)");
            Transform ishmael_def = __instance.transform.Find("[Rect]MainPanel/[Rect]Contents/[Rect]Personalities/[Layout]Personalities/PersonalityFormationSlot_Ishmael/[Rect]AdditionalInfo/PersonalitySlotSkillInfoItemList/PersonalitySlotSkillInfoItem (GUARD)/Text (TMP)");
            Transform rodya_def = __instance.transform.Find("[Rect]MainPanel/[Rect]Contents/[Rect]Personalities/[Layout]Personalities/PersonalityFormationSlot_Rodion/[Rect]AdditionalInfo/PersonalitySlotSkillInfoItemList/PersonalitySlotSkillInfoItem (GUARD)/Text (TMP)");
            Transform sinclair_def = __instance.transform.Find("[Rect]MainPanel/[Rect]Contents/[Rect]Personalities/[Layout]Personalities/PersonalityFormationSlot_Sinclair/[Rect]AdditionalInfo/PersonalitySlotSkillInfoItemList/PersonalitySlotSkillInfoItem (GUARD)/Text (TMP)");
            Transform outis_def = __instance.transform.Find("[Rect]MainPanel/[Rect]Contents/[Rect]Personalities/[Layout]Personalities/PersonalityFormationSlot_Outis/[Rect]AdditionalInfo/PersonalitySlotSkillInfoItemList/PersonalitySlotSkillInfoItem (GUARD)/Text (TMP)");
            Transform gregor_def = __instance.transform.Find("[Rect]MainPanel/[Rect]Contents/[Rect]Personalities/[Layout]Personalities/PersonalityFormationSlot_Gregor/[Rect]AdditionalInfo/PersonalitySlotSkillInfoItemList/PersonalitySlotSkillInfoItem (GUARD)/Text (TMP)");
            if (yisang_def != null)
            {
                yisang_def.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЗАЩ.";
                yisang_def.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                yisang_def.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
                faust_def.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЗАЩ.";
                faust_def.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                faust_def.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
                donquixote_def.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЗАЩ.";
                donquixote_def.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                donquixote_def.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
                ryoshu_def.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЗАЩ.";
                ryoshu_def.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                ryoshu_def.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
                meur_def.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЗАЩ.";
                meur_def.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                meur_def.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
                honglu_def.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЗАЩ.";
                honglu_def.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                honglu_def.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
                heathcliff_def.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЗАЩ.";
                heathcliff_def.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                heathcliff_def.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
                ishmael_def.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЗАЩ.";
                ishmael_def.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                ishmael_def.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
                rodya_def.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЗАЩ.";
                rodya_def.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                rodya_def.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
                outis_def.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЗАЩ.";
                outis_def.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                outis_def.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
                sinclair_def.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЗАЩ.";
                sinclair_def.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                sinclair_def.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
                gregor_def.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЗАЩ.";
                gregor_def.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                gregor_def.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
            }
        }
        [HarmonyPatch(typeof(UnitInformationController), nameof(UnitInformationController.Initialize))]
        [HarmonyPostfix]
        private static void UnitInformationController_Init(UnitInformationController __instance)
        {
            Transform season = __instance.transform.Find("[Script]UnitInformationController_Renewal/[Script]PersonalityAndEgoNameTag/[Text]Season");
            Transform max_level = __instance.transform.Find("[Script]UnitInformationController_Renewal/[Rect]UnitStatusContent/[Button]PersonaliyLevelUpButton/[Text]MAXContent");
            Transform max_thread = __instance.transform.Find("[Script]UnitInformationController_Renewal/[Rect]UnitStatusContent/[Button]GacksungLevelUpButton/[Text]MAXContent");
            if (season != null)
            {
                season.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                season.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
            }
            if (max_level != null)
            {
                max_level.GetComponentInChildren<TextMeshProUGUI>(true).text = "MAKC.";
                //max_level.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                //max_level.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
                max_thread.GetComponentInChildren<TextMeshProUGUI>(true).text = "MAKC.";
                //max_thread.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                //max_thread.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
            }
        }
        [HarmonyPatch(typeof(UnitInfoPersonalityNameTag), nameof(UnitInfoPersonalityNameTag.SetSeasonTagUI))]
        [HarmonyPostfix]
        private static void UnitInfoPersonalityNameTag_Init(UnitInfoPersonalityNameTag __instance)
        {
            string text = __instance._seasonTagUI.tmp_season.text.Replace("SEASON", "СЕЗОН");
            __instance._seasonTagUI.tmp_season.text = text.Replace("WALPURGISNACHT", "ВАЛЬПУРГИЕВА НОЧЬ");
        }
    }
}
