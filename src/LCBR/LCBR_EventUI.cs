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
        [HarmonyPatch(typeof(DawnOfGreenEventRewardButton), nameof(DawnOfGreenEventRewardButton.SetData))]
        [HarmonyPostfix]
        private static void RewardClear_Init(DawnOfGreenEventRewardButton __instance)
        {
            __instance._completeImage.sprite = LCBR_ReadmeManager.ReadmeEventSprites["LCBR_VN2_Clear"];
        }
    }
}
