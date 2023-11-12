using BattleUI;
using BattleUI.Information;
using HarmonyLib;
using MainUI;
using MainUI.VendingMachine;
using TMPro;
using UnityEngine;

namespace LimbusLocalizeRUS
{
    internal class LCBR_TextUI
    {
        [HarmonyPatch(typeof(NetworkingUI), "Initialize")]
        [HarmonyPostfix]
        private static void NetworkingUI_Init(NetworkingUI __instance)
        {
            Transform transform = __instance.transform.Find("connecting_background/tmp_connecting");
            if (transform != null)
            {
                transform.GetComponentInChildren<TextMeshProUGUI>(true).text = "ПОДКЛЮЧЕНИЕ";
                transform.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[0];
                transform.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[0].material;
                transform.GetComponentInChildren<TextMeshProUGUI>(true).fontSize = 77f;
            }
        }
        [HarmonyPatch(typeof(VendingMachineUIPanel), "Initialize")]
        [HarmonyPostfix]
        private static void VendingMachineUIPanel_Init(VendingMachineUIPanel __instance)
        {
            Transform transform = __instance.transform.Find("GoodsStoreAreaMaster/PageButtonArea/BackPanel/Btn_TypeEGO/Tmp_EGO");
            if (transform != null)
            {
                transform.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЭГО";
            }
        }
        [HarmonyPatch(typeof(FormationSwitchablePersonalityUIPanel), "Initialize")]
        [HarmonyPostfix]
        private static void FormationSwitchablePersonalityUIPanel_Init(FormationSwitchablePersonalityUIPanel __instance)
        {
            Transform transform = __instance.transform.Find("[Script]RightPanel/[Script]FormationEgoList/[Text]Ego_Label");
            Transform transform2 = __instance.transform.Find("[Script]ListTabRoot/[Layout]Tabs/[Toggle]Ego/[Text]E.G.O");
            if (transform != null)
            {
                transform.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЭГО";
            }
            if (transform2 != null)
            {
                transform2.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЭГО";
            }
        }
        [HarmonyPatch(typeof(FormationUIPanel), nameof(FormationUIPanel.Initialize))]
        [HarmonyPostfix]
        private static void FormationUIPanel_Init(FormationUIPanel __instance)
        {
            //MAIN UI HOVER EGO TEXT
            Transform transform = __instance.transform.Find("[Rect]MainPanel/[Rect]Contents/[Rect]Personalities/PersonalityDetail/[Button]Main/[Rect]Select/[Button]EGO/[Text]EGO");
            if (transform != null)
            {
                transform.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЭГО";
                transform.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[3];
                transform.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[3].material;
            }
            Transform transform1 = __instance.transform.Find("[Rect]MainPanel/[Rect]Contents/[Rect]Personalities/PersonalityDetail/[Button]Main/[Rect]Select/[Button]EGO/[Text]EGO/[Text]EGO_Highlight");
            if (transform1 != null)
            {
                transform1.GetComponentInChildren<TextMeshProUGUI>(true).text = "ЭГО";
                transform1.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[3];
                transform1.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[3].material;
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
            Transform transform = __instance.transform.Find("[Script]UnitInformationController_Renewal/[Script]PersonalityAndEgoNameTag/[Text]Season");
            if (transform != null)
            {
                transform.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[1];
                transform.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[1].material;
            }
        }
    }
}
