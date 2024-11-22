using HarmonyLib;
using Voice;
using BattleUI.Dialog;
using System;

namespace LimbusModss
{
    public static class LCB_Voice
    {
        [HarmonyPatch(typeof(VoiceGenerator), nameof(VoiceGenerator.CreateVoiceInstance))]
        [HarmonyPrefix]
        private static void CreateVoiceInstance(string path, bool isSpecial)
        {
            if (!path.StartsWith("event:/Voice/battle_"))
                return;
            path = path[VoiceGenerator.VOICE_EVENT_PATH.Length..];
            string id_sin = path.Split('_')[^2];
            var dataList = Singleton<TextDataManager>.Instance.personalityVoiceText.GetDataList(id_sin);
            Func<TextData_PersonalityVoice, bool> func = (x) => {return path == x.id; };
            var data = dataList.dataList.Find(func);
            if (data == null)
                return;
            BattleDialogLine battleDialogLine = new(data.dlg, null);
            if (UnitView != null)
            {
                UnitView._uiManager.ShowDialog(battleDialogLine);
            }
        }
        [HarmonyPatch(typeof(BattleUnitView), nameof(BattleUnitView.SetPlayVoice))]
        [HarmonyPrefix]
        private static void BattleUnitView_Func(BattleUnitView __instance, BattleCharacterVoiceType key, bool isSpecial, BattleSkillViewer skillViewer)
        {
            UnitView = __instance;
        }
        static BattleUnitView UnitView;
    }
}
