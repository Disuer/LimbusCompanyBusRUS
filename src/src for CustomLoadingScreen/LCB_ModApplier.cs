using HarmonyLib;
using MainUI;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UObject = UnityEngine.Object;
using UnityEngine.Video;
using UnityEngine.UI;
using System.Text.Json;
using UnityEngine.Networking;
using System.Threading;
using System.Net.Http;
using System.Net;

namespace LimbusMODS
{
    public static class LCB_ModApplier
    {
        public class loadingScreenConfig
        {
            public string loadingScreenMode { get; set; }
            public float loadingScreenSpeed { get; set; }
            public float loadingScreenZoom { get; set; }
        }
        public static string jsonString = File.ReadAllText(LCB_Core.ModPath + "/config.json");
        public static loadingScreenConfig globalConfig = JsonSerializer.Deserialize<loadingScreenConfig>(jsonString);

        static LCB_ModApplier()
        {
            if(globalConfig.loadingScreenMode == "random" || globalConfig.loadingScreenMode == "onlyArts")
                ReadMySprites();
        }
        public static Dictionary<string, Sprite> ReadSprites = new();
        public static void ReadMySprites()
        {
            ReadSprites = new Dictionary<string, Sprite>();
            foreach (FileInfo fileInfo in new DirectoryInfo(LCB_Core.ModPath + "/").GetFiles().Where(f => f.Extension == ".jpg" || f.Extension == ".png"))
            {
                Texture2D texture2D = new(2, 2);
                ImageConversion.LoadImage(texture2D, File.ReadAllBytes(fileInfo.FullName));
                Sprite sprite = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileInfo.FullName);
                texture2D.name = fileNameWithoutExtension;
                sprite.name = fileNameWithoutExtension;
                UObject.DontDestroyOnLoad(sprite);
                sprite.hideFlags |= HideFlags.HideAndDontSave;
                ReadSprites[fileNameWithoutExtension] = sprite;
            }
        }
        public static TValue SelectOne<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
        {
            if (dictionary.Count == 0)
            {
                return default;
            }

            List<TValue> values = new List<TValue>(dictionary.Values);
            return values[UnityEngine.Random.Range(0, values.Count)];
        }
        public static List<string> egos = new List<string> {"20102", "20103", "20104", "20105", "20106", "20107", "20202","20203","20204","20205","20206","20207","20302","20303","20304","20305","20306","20307","20402","20403","20404","20405","20406","20407","20502","20503","20504","20505","20506","20507","20602","20603","20604","20605","20606","20607","20702","20703","20704","20705","20706","20707","20802","20803","20804","20805","20806","20807","20902","20903","20904","20905","20906","20907","21002","21003","21004","21005","21006","21007","21102","21103","21104","21105","21106","21107", "21202", "21203", "21204", "21205", "21206", "21207"};
        public static List<string> personalities = new List<string> {"10103","10104","10106","10109","10110","10204","10206","10207","10208","10210","10302","10305","10306","10309","10403","10404","10405","10408","10410","10503","10504","10506","10508","10510","10511","10603","10605","10608","10609","10703","10705","10707","10708","10710","10802","10806","10807","10808","10810","10902","10905","10907","10908","10910","10911","11002","11005","11008","11009","11104","11105","11107","11108","11110","11111","11203","11206","11207","11209","11210"};
        public static RenderTexture updateuss = Resources.Load<RenderTexture>("Title/UpdateVideoTexture");
        public static VideoClip videoClip1 = null;

        [HarmonyPatch(typeof(LoadingSceneManager), nameof(LoadingSceneManager.SetHintText))]
        [HarmonyPrefix]
        private static void LoadingSceneManager_Init14(LoadingSceneManager __instance)
        {
            __instance._loadingImage.enabled = false;
            int myrand = UnityEngine.Random.Range(0, 100);
            switch (globalConfig.loadingScreenMode)
            {
                case "onlyCG":
                    switch (myrand)
                    {
                        case int n when (n <= 50):
                            int ego = UnityEngine.Random.Range(0, egos.Count);
                            videoClip1 = Singleton<EgoVideoList>.Instance.GetVideo(egos[ego]);
                            break;
                        case int n when (n > 50):
                            int personality = UnityEngine.Random.Range(0, personalities.Count);
                            videoClip1 = Singleton<PersonalityVideoList>.Instance.GetVideo(personalities[personality]);
                            break;
                    }
                    CallClip(videoClip1, __instance.transform.Find("LeftArea"), updateuss);
                    break;
                case "onlyArts":
                    CallArt(__instance._defaultCG, __instance._loadingImage);
                    break;
                case "random":
                    switch (myrand)
                    {
                        case int n when (n <= 33):
                            int ego = UnityEngine.Random.Range(0, egos.Count);
                            videoClip1 = Singleton<EgoVideoList>.Instance.GetVideo(egos[ego]);
                            break;
                        case int n when (n > 33 && n <= 66):
                            int personality = UnityEngine.Random.Range(0, personalities.Count);
                            videoClip1 = Singleton<PersonalityVideoList>.Instance.GetVideo(personalities[personality]);
                            break;
                        case int n when (n > 66 && n <= 100):
                            CallArt(__instance._defaultCG, __instance._loadingImage);
                            break;
                    }
                    CallClip(videoClip1, __instance.transform.Find("LeftArea"), updateuss);
                    break;
            }
        }
        public static void CallClip(VideoClip  clip, Transform leftArea, RenderTexture updateuss)
        {
            if (clip != null)
            {
                GameObject rawImageObject;
                GameObject videoPlayerObject;

                rawImageObject = new GameObject("RawImageObject");
                rawImageObject.transform.SetParent(leftArea);

                videoPlayerObject = new GameObject("VideoPlayerObject");
                videoPlayerObject.transform.SetParent(leftArea);

                RawImage rawImage = rawImageObject.AddComponent<RawImage>();
                rawImage.enabled = true;

                RectTransform rawImageRect = rawImageObject.GetComponent<RectTransform>();
                rawImageRect.anchorMin = new Vector2(0, 0);
                rawImageRect.anchorMax = new Vector2(1, 1);
                rawImageRect.offsetMin = Vector2.zero;
                rawImageRect.offsetMax = Vector2.zero;

                RectTransform rectTransform = rawImage.GetComponent<RectTransform>();
                rectTransform.localScale = new Vector3(globalConfig.loadingScreenZoom, globalConfig.loadingScreenZoom, globalConfig.loadingScreenZoom);

                VideoPlayer videoPlayer = videoPlayerObject.AddComponent<VideoPlayer>();
                videoPlayer.source = VideoSource.VideoClip;
                videoPlayer.playbackSpeed = globalConfig.loadingScreenSpeed;
                videoPlayer.clip = clip;
                videoPlayer.waitForFirstFrame = true;
                videoPlayer.isLooping = true;
                videoPlayer.renderMode = VideoRenderMode.RenderTexture;
                videoPlayer.targetTexture = updateuss;

                updateuss = new RenderTexture(1920, 1080, 24);
                videoPlayer.targetTexture = updateuss;
                rawImage.texture = updateuss;

                videoPlayer.Play();
                videoPlayer.Prepare();
            }
        }
        public static void CallArt(Sprite defaultCG, Image loading)
        {
            defaultCG = SelectOne(ReadSprites);
            loading.sprite = SelectOne(ReadSprites);
            loading.enabled = true;
        }
    }
}