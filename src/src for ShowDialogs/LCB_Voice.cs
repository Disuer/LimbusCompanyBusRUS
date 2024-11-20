using HarmonyLib;
using Voice;
using BattleUI.Dialog;

namespace LimbusModss
{
    public static class LCB_Voice
    {
        [HarmonyPatch(typeof(BattleUnitView), nameof(BattleUnitView.SetPlayVoice))]
        [HarmonyPostfix]
        private static void BattleUnitView_Func(BattleUnitView __instance, ref BattleCharacterVoiceType key, bool isSpecial = false, BattleSkillViewer skillViewer = null)
        {
            var sinners = new System.Collections.Generic.List<string>() { "Yi Sang", "Faust", "Don Quixote", "Ryōshū", "Meursault", "Hong Lu", "Heathcliff", "Ishmael", "Rodion", "Sinclair", "Outis", "Gregor" };
            string id_sin = __instance.Appearance.name.Substring(0, 5);
            TextData_Personality data = Singleton<TextDataManager>.Instance.PersonalityList.GetData(id_sin);
            string haha;
            if (sinners.Contains(data.name))
            {
                string id_voice;
                switch (key)
                {
                    case BattleCharacterVoiceType.AllyDead:
                        id_voice = $"battle_allydead_{id_sin}_1";
                        break;
                    case BattleCharacterVoiceType.AllyBreak:
                        id_voice = $"battle_break_{id_sin}_1";
                        break;
                    case BattleCharacterVoiceType.BattleStart:
                        id_voice = $"battleentry_{id_sin}_1";
                        break;
                    case BattleCharacterVoiceType.Dead:
                        id_voice = $"battle_dead_{id_sin}_1";
                        break;
                    case BattleCharacterVoiceType.EndCommand:
                        id_voice = $"battle_endcommand_{id_sin}_1";
                        break;
                    case BattleCharacterVoiceType.EnemyBreak:
                        id_voice = $"battle_enemy_break_{id_sin}_1";
                        break;
                    case BattleCharacterVoiceType.Kill:
                        id_voice = $"battle_kill_{id_sin}_1";
                        break;
                    case BattleCharacterVoiceType.Select:
                        id_voice = $"battle_select_{id_sin}_1";
                        break;
                    default:
                        id_voice = "";
                        break;
                }
                if (id_voice != "")
                {
                    LocalizeTextDataRoot<TextData_PersonalityVoice> dataList = Singleton<TextDataManager>.Instance.personalityVoiceText.GetDataList(id_sin);
                    foreach (var lala in dataList.dataList)
                    {
                        if (id_voice == lala.id)
                        {
                            haha = lala.dlg;
                            BattleDialogLine battleDialogLine = new BattleDialogLine(haha, null);
                            __instance._uiManager.ShowDialog(battleDialogLine);
                        }
                    }
                }
            }
        }
    }
}