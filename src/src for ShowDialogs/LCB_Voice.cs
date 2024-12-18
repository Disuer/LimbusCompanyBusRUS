using HarmonyLib;
using Voice;
using BattleUI.Dialog;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

namespace LimbusModss
{
    public static class LCB_Voice
    {
        public class devai
        {
            public string id { get; set; }
            public List<int> timeForSentence { get; set; }
            public List<string> dlg { get; set; }
        }

        public class devaiList
        {
            public List<devai> dataList { get; set; }
        }

        public static string jsonString = "{\"dataList\": [{\"id\": \"battle_devai_10910_1\",\"timeForSentence\": [1660, 3000],\"dlg\": [\"[Hostile forces detected.]\",\"[Activating Poludnitsa high-power delivery mode maneuvers.]\"]},{\"id\": \"battle_devai_10910_1-01\",\"timeForSentence\": [1194, 2610, 2953],\"dlg\": [\"[Phase 1]\",\"[Delivery assistant and control sequence initiated.]\",\"[Calmly forge a path.]\"]},{\"id\": \"battle_devai_10910_1-02\",\"timeForSentence\": [1164, 2178, 2839],\"dlg\": [\"[Phase 2]\",\"[Delivery carrier output increased]\",\"[Quick pioneering is recommended.]\"]},{\"id\": \"battle_devai_10910_1-03\",\"timeForSentence\": [2079, 2857, 4034],\"dlg\": [\"[Phase 3, Warning.]\",\"[Time-over delivery acceleartion entering final stage.]\",\"[Further delays do not guarantee personal safety.]\"]},{\"id\": \"battle_devai_10910_1-04\",\"timeForSentence\": [966, 1248, 2415, 2204, 2677],\"dlg\": [\"[Notification.]\",\"[Delivery failed.]\",\"[The responsible person will collect it shortly.]\",\"[Thank you for your hard work.]\",\"[Poludnitsa security is now operating.]\"]},{\"id\": \"battle_devai_10910_1-05\",\"timeForSentence\": [2221, 1883, 829, 2000, 2733],\"dlg\": [\"[Low-power R&R mode activated.]\",\"[Energy circulation temporarily paused.]\",\"[Caution.]\",\"[This measure is temporary.]\",\"[Immediate delivery is recommended.]\"]},{\"id\": \"battle_devai_10910_1-06\",\"timeForSentence\": [931, 3677, 2542],\"dlg\": [\"[Warning.]\",\"[For the efficiency of delivery, lifting the particle restriction for the delivery person.]\",\"[Please proceed with the delivery immediately.]\"]},{\"id\": \"battle_devai_10910_1-07\",\"timeForSentence\": [2029, 2570],\"dlg\": [\"[The customer is still waiting.]\",\"[You are being disintergrated.]\"]},{\"id\": \"battle_devai_10910_1-08\",\"timeForSentence\": [3695, 3912],\"dlg\": [\"[The Devyat Association's Poludnitsa discourages pointless killing.]\",\"[Please proceed with immediate delivery to ensure your safety.]\"]},{\"id\": \"battle_devai_10910_1-09\",\"timeForSentence\": [2285, 888, 3182, 2568],\"dlg\": [\"[Low-power R&R mode activated.]\",\"[Caution.]\",\"[Strategic R&R is provided only for the day.]\",\"[Please proceed with immediate delivery.]\"]},{\"id\": \"battle_devai_10910_1-10\",\"timeForSentence\": [3821, 3503],\"dlg\": [\"[It is not recommended to refer to this AI as 'Polu'.]\",\"[Incorrect commands can cause energy surges.]\"]},{\"id\": \"battle_devai_10910_1-11\",\"timeForSentence\": [2423],\"dlg\": [\"[Output increase request confirmed.]\"]},{\"id\": \"battle_devai_10910_1-12\",\"timeForSentence\": [924, 4214],\"dlg\": [\"[Caution.]\",\"[Unauthorized storage of non-designated delivery items is not recommended.]\"]},{\"id\": \"battle_devai_10910_1-13\",\"timeForSentence\": [3310],\"dlg\": [\"[Unauthorized lock release outside of delivery coordinates detected.]\"]},{\"id\": \"battle_devai_10910_1-14\",\"timeForSentence\": [1591],\"dlg\": [\"[Unauthorized behavior detected.]\"]},{\"id\": \"battle_devai_11011_1\",\"timeForSentence\": [1651, 3048],\"dlg\": [\"[Hostile forces detected.]\",\"[Activating Poludnitsa high-power delivery mode maneuvers.]\"]},{\"id\": \"battle_devai_11011_2\",\"timeForSentence\": [1234, 2603, 2902],\"dlg\": [\"[Phase 1]\",\"[Delivery assistant and control sequence initiated.]\",\"[Calmy forge a path.]\"]},{\"id\": \"battle_devai_11011_3\",\"timeForSentence\": [1230, 2250, 2737],\"dlg\": [\"[Phase 2]\",\"[Delivery carrier output increased.]\",\"[Quick pioneering is recommended.]\"]},{\"id\": \"battle_devai_11011_4\",\"timeForSentence\": [2087, 2869, 4050],\"dlg\": [\"[Phase 3, Warning.]\",\"[Time-over delivery acceleration reaching final stage.]\",\"[Further delays do not guarantee personal safety.]\"]},{\"id\": \"battle_devai_11011_5\",\"timeForSentence\": [1713, 1967, 2620],\"dlg\": [\"[Error opening path to retreat.]\",\"[Courier not found.]\",\"[Poludnitsa security is now operating.]\"]},{\"id\": \"battle_devai_11011_6\",\"timeForSentence\": [952, 1273, 2396, 2225, 2626],\"dlg\": [\"[Update.]\",\"[Delivery failed.]\",\"[The courier will be collected shortly.]\",\"[Thank you for your service.]\",\"[Poludnitsa, engaging Protection Mode.]\"]},{\"id\": \"battle_devai_11011_7\",\"timeForSentence\": [2271, 1849, 832, 2004, 2754],\"dlg\": [\"[Low-power R&R mode activated.]\",\"[Energy circulation is temporarily paused.]\",\"[Caution.]\",\"[This measure is temporary]\",\"[Immediate delivery is recommended.]\"]},{\"id\": \"battle_devai_11011_8\",\"timeForSentence\": [929, 3680, 2531],\"dlg\": [\"[Warning.]\",\"[For the efficiency of delivery, lifting the particle restriction for the delivery person.]\",\"[Please proceed with the delivery immediately.]\"]},{\"id\": \"battle_devai_11011_9\",\"timeForSentence\": [2038, 2570],\"dlg\": [\"[The customer is still waiting.]\",\"[You are being disintergrated.]\"]},{\"id\": \"battle_devai_11011_10\",\"timeForSentence\": [3679, 3928],\"dlg\": [\"[The Devyat Association's Poludnitsa discourages pointless killings.]\",\"[Please proceed with immediate delivery to ensure your safety.]\"]},{\"id\": \"battle_devai_11011_11\",\"timeForSentence\": [2299, 848, 3185, 2573],\"dlg\": [\"[Low-power R&R mode activated.]\",\"[Caution.]\",\"[Strategic R&R Mode is only provided for the day.]\",\"[Please proceed with the delivery immediately.]\"]}]}";
        
        public static devaiList devyatdata = System.Text.Json.JsonSerializer.Deserialize<devaiList>(jsonString);
        [HarmonyPatch(typeof(VoiceGenerator), nameof(VoiceGenerator.CreateVoiceInstance))]
        [HarmonyPrefix]
        private static void CreateVoiceInstance(string path, bool isSpecial)
        {
            if (!path.StartsWith("event:/Voice/battle_") || path.StartsWith("event:/Voice/battle_awaken") || !UnitView)
                return;
            path = path[VoiceGenerator.VOICE_EVENT_PATH.Length..];
            if (path.Contains("devai"))
                CallForPoluAsync(path);
            if (!TextDataManager.Instance.personalityVoiceText._voiceDictionary.TryGetValue(path.Split('_')[^2],
                    out var dataList)) return;
            foreach (var data in dataList.dataList)
                if (path.Equals(data.id))
                {
                    UnitView._uiManager.ShowDialog(new BattleDialogLine(data.dlg, null));
                    break;
                }
        }
        [HarmonyPatch(typeof(BattleUnitView), nameof(BattleUnitView.SetPlayVoice))]
        [HarmonyPrefix]
        private static void BattleUnitView_Func(BattleUnitView __instance, BattleCharacterVoiceType key, bool isSpecial, BattleSkillViewer skillViewer)
        {
            UnitView = __instance;
        }
        static BattleUnitView UnitView;
        public static async void CallForPoluAsync(string path)
        {
            var polu = SingletonBehavior<OutterGradiantEffectController>.Instance;
            polu._dialogText_Upper.m_fontStyle = TMPro.FontStyles.Normal;
            var poludlg = lookingfordlg(path);
            var polutime = lookingfortime(path);
            for (int i = 0; i < polutime.Count; i++)
            {
                polu.SetDialog_Upper($"<color=#4dff49>{poludlg[i]}</color>", 0, polutime[i]);
                await Task.Delay(polutime[i]);
            }
            polu._dialogText_Upper.text = null;
            polu._dialogText_Upper.m_fontStyle = TMPro.FontStyles.Italic;
        }
        private static List<string> lookingfordlg(string search)
        {
            var lookingfor1 = devyatdata.dataList.FirstOrDefault(f => f.id == search);
            if (lookingfor1 != null)
            {
                return lookingfor1.dlg;
            }
            return null;
        }
        private static List<int> lookingfortime(string search)
        {
            var lookingfor1 = devyatdata.dataList.FirstOrDefault(f => f.id == search);
            if (lookingfor1 != null)
            {
                return lookingfor1.timeForSentence;
            }
            return null;
        }
    }
}