using HarmonyLib;
using MainUI;
using UnityEngine.EventSystems;
using TMPro;
using static UI.Utility.InfoModels;
using UnityEngine;
using UnityEngine.UI;
using UI;

namespace LimbusLocalizeRUS
{
    public static class LCBR_EventUI
    {
        [HarmonyPatch(typeof(SeventhAnniversaryEventPopup), nameof(SeventhAnniversaryEventPopup.InitEventStataicData))]
        [HarmonyPostfix]
        private static void ProjectMoon7AnnivCG_Init(SeventhAnniversaryEventPopup __instance)
        {
            Transform anniversaryBG = __instance.transform.Find("GameObject/[Image]Bg");
            if (anniversaryBG != null)
            {
                anniversaryBG.GetComponentInChildren<Image>(true).sprite = LCBR_ReadmeManager.ReadmeEventSprites["LCBR_7thAnniversary"];
            }
        }
        [HarmonyPatch(typeof(SeventhAnniversaryEventPopup), nameof(SeventhAnniversaryEventPopup.InitLocalizeText))]
        [HarmonyPostfix]
        private static void ProjectMoon7AnnivText_Init(SeventhAnniversaryEventPopup __instance)
        {
            Transform anniversaryDate = __instance.transform.Find("GameObject/[Text]EventDate");
            if (anniversaryDate != null)
            {
                anniversaryDate.GetComponentInChildren<TextMeshProUGUI>(true).m_text = "18:00 17.11.2023(ПТ) - 17:59 24.11.2023(ПТ) (МСК)";
                anniversaryDate.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_Cyrillic_Font.tmpcyrillicfonts[2];
                anniversaryDate.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_Cyrillic_Font.tmpcyrillicfonts[2].material;
            }
        }
    }
}
