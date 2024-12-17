using HarmonyLib;
using Voice;
using BattleUI.Dialog;
using System;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.Intrinsics;
using Newtonsoft.Json;
using UnityEngine;
using Mono.Cecil;
using UnityEngine.UI;

namespace LimbusModss
{
    public static class LCB_Voice
    {
        public class devai
        {
            public string id { get; set; }  
            public List<float> timeForSentence { get; set; }
            public List<string> dlg { get; set; }
        }

        public class devaiList
        {
            public List<devai> dataList { get; set; }
        }

        //public static string jsonString = File.ReadAllText(LCB_ConfMod.ModPath + "/devai.json");
        public static string jsonString = "{\"dataList\": [{\"id\": \"battle_devai_10910_1\",\"timeForSentence\": [1.660, 3.000],\"dlg\": [\"[Hostile forces detected.]\",\"[Activating Poludnitsa high-power delivery mode maneuvers.]\"]},{\"id\": \"battle_devai_10910_1-01\",\"timeForSentence\": [1.194, 2.610, 2.953],\"dlg\": [\"[Phase 1]\",\"[Delivery assistant and control sequence initiated.]\",\"[Calmly forge a path.]\"]},{\"id\": \"battle_devai_10910_1-02\",\"timeForSentence\": [1.164, 2.178, 2.839],\"dlg\": [\"[Phase 2]\",\"[Delivery carrier output increased]\",\"[Quick pioneering is recommended.]\"]},{\"id\": \"battle_devai_10910_1-03\",\"timeForSentence\": [2.079, 2.857, 4.034],\"dlg\": [\"[Phase 3, Warning.]\",\"[Time-over delivery acceleartion entering final stage.]\",\"[Further delays do not guarantee personal safety.]\"]},{\"id\": \"battle_devai_10910_1-04\",\"timeForSentence\": [0.966, 1.248, 2.415, 2.204, 2.677],\"dlg\": [\"[Notification.]\",\"[Delivery failed.]\",\"[The responsible person will collect it shortly.]\",\"[Thank you for your hard work.]\",\"[Poludnitsa security is now operating.]\"]},{\"id\": \"battle_devai_10910_1-05\",\"timeForSentence\": [2.221, 1.883, 0.829, 2.000, 2.733],\"dlg\": [\"[Low-power R&R mode activated.]\",\"[Energy circulation temporarily paused.]\",\"[Caution.]\",\"[This measure is temporary.]\",\"[Immediate delivery is recommended.]\"]},{\"id\": \"battle_devai_10910_1-06\",\"timeForSentence\": [0.931, 3.677, 2.542],\"dlg\": [\"[Warning.]\",\"[For the efficiency of delivery, lifting the particle restriction for the delivery person.]\",\"[Please proceed with the delivery immediately.]\"]},{\"id\": \"battle_devai_10910_1-07\",\"timeForSentence\": [2.029, 2.570],\"dlg\": [\"[The customer is still waiting.]\",\"[You are being disintergrated.]\"]},{\"id\": \"battle_devai_10910_1-08\",\"timeForSentence\": [3.695, 3.912],\"dlg\": [\"[The Devyat Association's Poludnitsa discourages pointless killing.]\",\"[Please proceed with immediate delivery to ensure your safety.]\"]},{\"id\": \"battle_devai_10910_1-09\",\"timeForSentence\": [2.285, 0.888, 3.182, 2.568],\"dlg\": [\"[Low-power R&R mode activated.]\",\"[Caution.]\",\"[Strategic R&R is provided only for the day.]\",\"[Please proceed with immediate delivery.]\"]},{\"id\": \"battle_devai_10910_1-10\",\"timeForSentence\": [3.821, 3.503],\"dlg\": [\"[It is not recommended to refer to this AI as 'Polu'.]\",\"[Incorrect commands can cause energy surges.]\"]},{\"id\": \"battle_devai_10910_1-11\",\"timeForSentence\": [2.423],\"dlg\": [\"[Output increase request confirmed.]\"]},{\"id\": \"battle_devai_10910_1-12\",\"timeForSentence\": [0.924, 4.214],\"dlg\": [\"[Caution.]\",\"[Unauthorized storage of non-designated delivery items is not recommended.]\"]},{\"id\": \"battle_devai_10910_1-13\",\"timeForSentence\": [3.310],\"dlg\": [\"[Unauthorized lock release outside of delivery coordinates detected.]\"]},{\"id\": \"battle_devai_10910_1-14\",\"timeForSentence\": [1.591],\"dlg\": [\"[Unauthorized behavior detected.]\"]},{\"id\": \"battle_devai_11011_1\",\"timeForSentence\": [1.651, 3.048],\"dlg\": [\"[Hostile forces detected.]\",\"[Activating Poludnitsa high-power delivery mode maneuvers.]\"]},{\"id\": \"battle_devai_11011_2\",\"timeForSentence\": [1.234, 2.603, 2.902],\"dlg\": [\"[Phase 1.]\",\"[Delivery assistant and control sequence initiated.]\",\"[Calmy forge a path.]\"]},{\"id\": \"battle_devai_11011_3\",\"timeForSentence\": [1.230, 2.250, 2.737],\"dlg\": [\"[Phase 2.]\",\"[Delivery carrier output increased.]\",\"[Quick pioneering is recommended.]\"]},{\"id\": \"battle_devai_11011_4\",\"timeForSentence\": [2.087, 2.869, 4.050],\"dlg\": [\"[Phase 3, Warning.]\",\"[Time-over delivery acceleration reaching final stage.]\",\"[Further delays do not guarantee personal safety.]\"]},{\"id\": \"battle_devai_11011_5\",\"timeForSentence\": [1.713, 1.967, 2.620],\"dlg\": [\"[Error opening path to retreat.]\",\"[Courier not found.]\",\"[Poludnitsa security is now operating.]\"]},{\"id\": \"battle_devai_11011_6\",\"timeForSentence\": [0.952, 1.273, 2.396, 2.225, 2.626],\"dlg\": [\"[Update.]\",\"[Delivery failed.]\",\"[The courier will be collected shortly.]\",\"[Thank you for your service.]\",\"[Poludnitsa, engaging Protection Mode.]\"]},{\"id\": \"battle_devai_11011_7\",\"timeForSentence\": [2.271, 1.849, 0.832, 2.004, 2.754],\"dlg\": [\"[Low-power R&R mode activated.]\",\"[Energy circulation is temporarily paused.]\",\"[Caution.]\",\"[This measure is temporary]\",\"[Immediate delivery is recommended.]\"]},{\"id\": \"battle_devai_11011_8\",\"timeForSentence\": [0.929, 3.680, 2.531],\"dlg\": [\"[Warning.]\",\"[For the efficiency of delivery, lifting the particle restriction for the delivery person.]\",\"[Please proceed with the delivery immediately.]\"]},{\"id\": \"battle_devai_11011_9\",\"timeForSentence\": [2.038, 2.570],\"dlg\": [\"[The customer is still waiting.]\",\"[You are being disintergrated.]\"]},{\"id\": \"battle_devai_11011_10\",\"timeForSentence\": [3.679, 3.928],\"dlg\": [\"[The Devyat Association's Poludnitsa discourages pointless killings.]\",\"[Please proceed with immediate delivery to ensure your safety.]\"]},{\"id\": \"battle_devai_11011_11\",\"timeForSentence\": [2.299, 0.848, 3.185, 2.573],\"dlg\": [\"[Low-power R&R mode activated.]\",\"[Caution.]\",\"[Strategic R&R Mode is only provided for the day.]\",\"[Please proceed with the delivery immediately.]\"]}]}";
        public static devaiList devyatdata = System.Text.Json.JsonSerializer.Deserialize<devaiList>(jsonString);
        [HarmonyPatch(typeof(VoiceGenerator), nameof(VoiceGenerator.CreateVoiceInstance))]
        [HarmonyPrefix]
        private static async void CreateVoiceInstance(string path, bool isSpecial)
        {
            if (!path.StartsWith(VoiceGenerator.VOICE_EVENT_PATH + "battle_") || !UnitView)
                return;
            path = path[VoiceGenerator.VOICE_EVENT_PATH.Length..];
            var polu = SingletonBehavior<OutterGradiantEffectController>.Instance;
            if (path.Contains("devai"))
            {
                var currMat = polu._dialogText_Upper.material;
                Material GreenGlow = Resources.Load<Material>("Font/EN/Pretendard/Pretendard-Regular SDF GreenGlow");
                polu._dialogText_Upper.m_FontStyleInternal = TMPro.FontStyles.Normal;
                polu._dialogText_Upper.m_fontStyle = TMPro.FontStyles.Normal;
                polu._dialogText_Upper.fontSharedMaterial = GreenGlow;
                var poludlg = lookingfordlg(path);
                var polutime = lookingfortime(path);
                Image shadow = polu._dialogText_Upper.transform.parent.GetComponent<Image>();
                shadow.enabled = true;
                for (int i = 0; i < polutime.Count; i++)
                {
                    polu.SetDialog_Upper($"<color=#8B9C15FF>{poludlg[i]}</color>", 0, polutime[i]);
                    await Task.Delay((int)Math.Round(polutime[i] * 1000));
                }
                float sum = polutime.Sum();
                await Task.Delay((int)Math.Round(sum * 1000));
                polu._dialogText_Upper.m_FontStyleInternal = TMPro.FontStyles.Italic;
                polu._dialogText_Upper.m_fontStyle = TMPro.FontStyles.Italic;
                polu._dialogText_Upper.fontSharedMaterial = currMat;
                shadow.enabled = false;
            }
            if (!TextDataManager.Instance.personalityVoiceText._voiceDictionary.TryGetValue(path.Split('_')[^2], out var dataList))
            {
                return;
            }
            foreach (var data in dataList.dataList)
            {
                if (path.Equals(data.id))
                {
                    UnitView._uiManager.ShowDialog(new BattleDialogLine(data.dlg, null));
                    break;
                }
            }
        }
        [HarmonyPatch(typeof(BattleUnitView), nameof(BattleUnitView.SetPlayVoice))]
        [HarmonyPrefix]
        private static void BattleUnitView_Func(BattleUnitView __instance, BattleCharacterVoiceType key, bool isSpecial, BattleSkillViewer skillViewer)
        {
            UnitView = __instance;
        }
        static BattleUnitView UnitView;
        private static List<string> lookingfordlg(string search)
        {
            var lookingfor1 = devyatdata.dataList.FirstOrDefault(f => f.id == search);
            if (lookingfor1 != null)
            {
                return lookingfor1.dlg;
            }
            return null;
        }
        private static List<float> lookingfortime(string search)
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