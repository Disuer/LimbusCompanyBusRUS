using Addressable;
using HarmonyLib;
using Il2CppInterop.Runtime;
using MainUI;
using SimpleJSON;
using StorySystem;
using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UtilityUI;
using static Il2CppSystem.DateTimeParse;
using static Interop;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Server;
using static LimbusMods.LCB_Text;
using LimbusMods;
using System.Net;
using YamlDotNet.Serialization;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using System.Text.Json;
using System.Linq;
using UnityEngine.Networking;
using Il2CppSystem.Threading;
using Il2CppSystem;
using UnityEngine.Events;
using Il2CppMono.Security;

namespace LimbusMods
{
    public static class LCB_Text
    {
        static void DownloadFileAsync(string uri, string filePath)
        {
            try
            {
                LCB_ConfMod.LogWarning("Download " + uri + " to " + filePath);
                using HttpClient client = new();
                using HttpResponseMessage response = client.GetAsync(uri).GetAwaiter().GetResult();
                using HttpContent content = response.Content;
                using FileStream fileStream = new(filePath, FileMode.Create);
                content.CopyToAsync(fileStream).GetAwaiter().GetResult();
            }
            catch (System.Exception ex)
            {
                if (ex is HttpRequestException httpException && httpException.StatusCode == HttpStatusCode.NotFound)
                    LCB_ConfMod.LogWarning($"{uri} 404 NotFound,No Resource");
                else
                    LCB_ConfMod.LogWarning($"{uri} Error!!!" + ex.ToString());
            }   
        }
        public static void downloadAsync()
        {
            string my_uri = "https://raw.githubusercontent.com/Disuer/LimbusCompanyBusRUS/master_ilcpp/src/userid.json";
            UnityWebRequest www = UnityWebRequest.Get(my_uri);
            www.timeout = 4;
            www.SendWebRequest();
            while (!www.isDone)
                Thread.Sleep(100);
            string filename = LCB_ConfMod.ModPath + "/userid.json";
            if (!File.Exists(filename))
            {
                DownloadFileAsync(my_uri, filename);
                LCB_ConfMod.LogWarning("IDS DOWNLOADED!!!!!");
            }
        }
        public class limbuss
        {
            public string true_id { get; set; }
            public string custom_name { get; set; }
        }
        public static string limbussyfriends = File.ReadAllText(LCB_ConfMod.ModPath + "/userid.json");
        public static List<limbuss> fruends = JsonSerializer.Deserialize<List<limbuss>>(limbussyfriends);
        public static void checkmyjson()
        {
            foreach (var friend in fruends)
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
            __instance._friendCard.tmp_publicIdAlphabet.text = lookingfor(__instance._friendCard.tmp_publicIdAlphabet.text);
            __instance._friendCard.tmp_publicIdAlphabet.fontSizeMax = 30;
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
        private static void BannerList(GameObject wawa)
        {
            wawa.active = false;
        }
        private static string lookingfor(string search)
        {
            var friend = fruends.FirstOrDefault(f => f.true_id == search);
            if (friend != null)
            {
                return friend.custom_name;
            }
            return search;
        }
        /*
         * Forgot the functionality of this part..
        [HarmonyPatch(typeof(UserInfoFriednsSlot), nameof(UserInfoFriednsSlot.SetLoginDay))]
        [HarmonyPostfix]
        private static void UserInfoFriednsSlot1_Init(UserInfoFriednsSlot __instance)
        {
            var friend = fruends.FirstOrDefault(f => f.true_id == __instance._friendCard.tmp_publicIdAlphabet.text);
            if (friend != null)
            {
                __instance._friendCard.tmp_publicIdAlphabet.text = friend.custom_name;
            }
            __instance._friendCard.tmp_publicIdAlphabet.text = "6th";
        }
        */
    }
}