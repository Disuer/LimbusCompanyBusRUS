using HarmonyLib;
using MainUI;
using System.IO;
using UnityEngine;

using System.Net.Http;
using System.Net;
using System.Text.Json;
using System.Linq;
using UnityEngine.Networking;
using Il2CppSystem.Threading;
using System.Collections.Generic;

namespace LimbusMods
{
    public static class LCB_Text
    {
        public class limbuss
        {
            public string true_id { get; set; }
            public string custom_name { get; set; }
        }

        public class generaldata
        {
            public bool enablebanners { get; set; }
            public bool checkyourfriends { get; set; }
            public List<limbuss> friendlist { get; set; }
        }

        public static string jsonString = File.ReadAllText(LCB_ConfMod.ModPath + "/userid.json");
        public static generaldata fruends = JsonSerializer.Deserialize<generaldata>(jsonString);
        public static void checkmyjson()
        {
            foreach (var friend in fruends.friendlist)
            {
                if (friend.custom_name.Count<char>() > 13 || HasSpecialChars(friend.custom_name))
                {
                    LCB_ConfMod.LogError("Correct your userid.json file. One of your 'custom-name' keys contains more than 13 characters or forbidden symbols.");
                    friend.custom_name = friend.true_id;
                    return;
                }
            }
        }
        public static bool HasSpecialChars(string yourString)
        {
            return yourString.Any(ch => !char.IsLetterOrDigit(ch));
        }
        private static void BannerList(GameObject wawa)
        {
            if (!fruends.enablebanners)
            {
                wawa.active = false;
            }
        }
        private static string lookingfor(string search)
        {
            var friend = fruends.friendlist.FirstOrDefault(f => f.true_id == search);
            if (friend != null)
            {
                return friend.custom_name;
            }
            return search;
        }
        [HarmonyPatch(typeof(UserInfoFriend), nameof(UserInfoFriend.SetData))]
        [HarmonyPostfix]
        private static void UserInfoFriend_Init(UserInfoFriend __instance)
        {
            if (fruends.checkyourfriends)
            {
                Dictionary<string, int> summ = new Dictionary<string, int>();
                int shuup = 0;
                foreach (var lala in __instance._friendsList)
                {
                    var tempbefore = lala.public_uid;
                    var tempafter = lookingfor(tempbefore);
                    if (tempbefore != tempafter)
                    {
                        int fD = lala.level / 100;
                        if (fD == 0)
                        {
                            shuup = lala.level % 100;
                        }
                        summ.Add($"\n\nTrue ID: {tempbefore} \tCustom name: {tempafter} \nLVL: {shuup} \t\tLast online: {littleformation(lala._date)}", shuup);
                    }
                }
                var sortedD = summ.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
                LCB_ConfMod.LogInfo("\n--------------------------------------------------" + string.Concat(sortedD.Keys) + "\n\n--------------------------------------------------");
                sortedD = null;
                summ = null;
            }
        }
        public static string littleformation(DateUtil hahaha)
        {
            Il2CppSystem.TimeSpan timeSpanFrom = hahaha.getTimeSpanFrom(null);
            string text;
            if (timeSpanFrom.Days <= 1)
            {
                text = Singleton<TextDataManager>.Instance.UIList.GetData("Today");
            }
            else if (timeSpanFrom.Days <= 7)
            {
                text = string.Format(Singleton<TextDataManager>.Instance.UIList.GetData("Ago"), timeSpanFrom.Days);
            }
            else
            {
                text = hahaha.ToString(Singleton<TextDataManager>.Instance.UIList.GetData("Day_Ago"), false);
            }
            return text;
        }
        [HarmonyPatch(typeof(UserInfoCard), nameof(UserInfoCard.SetData))]
        [HarmonyPostfix]
        private static void UserInfoCard_Init(UserInfoCard __instance)
        {
            BannerList(__instance.tmp_level.transform.parent.parent.Find("[Rect]BannerList").gameObject);
            __instance.tmp_publicIdAlphabet.text = lookingfor(__instance.tmp_publicIdAlphabet.text);
        }
        [HarmonyPatch(typeof(UserInfoFriednsSlot), nameof(UserInfoFriednsSlot.SetData))]
        [HarmonyPostfix]
        private static void UserInfoFriednsSlot_Init(UserInfoFriednsSlot __instance)
        {
            BannerList(__instance._friendCard.tmp_level.transform.parent.Find("[Rect]BannerList").gameObject);
            __instance._friendCard.tmp_publicIdAlphabet.fontSizeMax = 30;
            __instance._friendCard.tmp_publicIdAlphabet.text = lookingfor(__instance._friendCard.tmp_publicIdAlphabet.text);
        }
        [HarmonyPatch(typeof(UserInfoFriendsInfoPopup), nameof(UserInfoFriendsInfoPopup.SetData))]
        [HarmonyPostfix]
        private static void UserInfoFriendsInfoPopup_Init(UserInfoFriendsInfoPopup __instance)
        {
            BannerList(__instance._friendsManager._friendCard.tmp_level.transform.parent.parent.Find("[Rect]BannerList").gameObject);
            __instance._friendsManager._friendCard.tmp_publicIdAlphabet.text = lookingfor(__instance._friendsManager._friendCard.tmp_publicIdAlphabet.text);
        }
        [HarmonyPatch(typeof(UserInfoFriendsInfoPopup), nameof(UserInfoFriendsInfoPopup.OpenManagerUI))]
        [HarmonyPostfix]
        private static void UserInfoFriendsInfoPopup_Open(UserInfoFriendsInfoPopup __instance)
        {
            __instance._friendsManager._friendCard.tmp_publicIdAlphabet.text = lookingfor(__instance._friendsManager._friendCard.tmp_publicIdAlphabet.text);
        }
        [HarmonyPatch(typeof(UserInfoFriendsAddSendPopup), nameof(UserInfoFriendsAddSendPopup.SetData))]
        [HarmonyPostfix]
        private static void UserInfoFriendsAddSendPopup_Open(UserInfoFriendsAddSendPopup __instance)
        {
            BannerList(__instance._friendsSlot._friendCard.tmp_level.transform.parent.Find("[Rect]BannerList").gameObject);
            __instance._friendsSlot._friendCard.tmp_publicIdAlphabet.text = lookingfor(__instance._friendsSlot._friendCard.tmp_publicIdAlphabet.text);
        }
    }
}