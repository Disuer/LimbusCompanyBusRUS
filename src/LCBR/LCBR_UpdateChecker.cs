using BepInEx.Configuration;
using Il2CppSystem.Threading;
using SimpleJSON;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.Networking;

namespace LimbusLocalizeRUS
{
    public static class LCBR_UpdateChecker
    {
        public static ConfigEntry<bool> AutoUpdate = LCB_LCBRMod.LCBR_Settings.Bind("LCBR Settings", "AutoUpdate", true, "Автоматически проверять и загружать обновления ( true | false )");
        public static ConfigEntry<URI> UpdateURI = LCB_LCBRMod.LCBR_Settings.Bind("LCBR Settings", "UpdateURI", URI.GitHub, "URI, используемый для автоматических обновлений (GitHub: Default )");
        public static void StartAutoUpdate()
        {
                LCB_LCBRMod.LogWarning("Xmmm... ||poBepka update-ov...");
                Action ModUpdate = CheckModUpdate;
                new Thread(ModUpdate).Start();
        }
        static void CheckModUpdate()
        {
            string release_uri = "https://api.github.com/repos/Crescent-Corporation/LimbusCompanyBusRUS/releases/latest";
            UnityWebRequest www = UnityWebRequest.Get(release_uri);
            www.timeout = 4;
            www.SendWebRequest();
            while (!www.isDone)
                Thread.Sleep(100);
            var latest = JSONNode.Parse(www.downloadHandler.text).AsObject;
            string latestReleaseTag = latest["tag_name"].Value;
            string updatelog = "LimbusCompanyRUS";
            Updatelog += updatelog + ".zip ";
            string download_uri = $"https://github.com/Crescent-Corporation/LimbusCompanyBusRUS/releases/download/{latestReleaseTag}/{updatelog}.zip";
            var dirs = download_uri.Split('/');
            string filename = LCB_LCBRMod.GamePath + "/BepInEx/plugins/LCBR/" + dirs[^1];
            string localizefolder = LCB_LCBRMod.GamePath + "/BepInEx/plugins/LCBR/Localize";
            string biedllfilename = LCB_LCBRMod.GamePath + "/BepInEx/plugins/LCBR/LimbusCompanyBusRUS_BIE.dll";
            string dllfilename = LCB_LCBRMod.GamePath + "/BepInEx/plugins/LCBR/LimbusCompanyBusRUS.dll";
            if (File.Exists(dllfilename))
                File.Delete(filename);
                File.Delete(dllfilename);
            if (www.result != UnityWebRequest.Result.Success){
                LCB_LCBRMod.LogWarning("Не удаётся полключиться к GitHub!" + www.error);
            }else{
                if (Version.Parse(LCB_LCBRMod.VERSION) < Version.Parse(latestReleaseTag.Remove(0, 1)))
                {
                    if (!File.Exists(filename))
                    {
                        DownloadFileAsync(download_uri, filename);
                    }
                    UpdateCall = UpdateDel;
                }
            }
            if (File.Exists(biedllfilename) && File.Exists(filename)){
                Directory.Delete(localizefolder, true);
                Application.Quit();
                File.Move(biedllfilename, dllfilename);
                ExtractArchive(filename, LCB_LCBRMod.GamePath + "/BepInEx/plugins/LCBR/");
            }

        }
        public static void ExtractArchive(string archivePath, string extractPath)
        {
            try
            {
                if (File.Exists(archivePath))
                {
                    ZipFile.ExtractToDirectory(archivePath, extractPath);
                    LCB_LCBRMod.LogWarning("Archive is successfully unzipped.");
                }
                else
                {
                    LCB_LCBRMod.LogWarning("Archive is not founded: " + archivePath);
                }
            }
            catch (Exception ex)
            {
                LCB_LCBRMod.LogWarning("Error while unzipping: " + ex.Message);
            }
        }
        static void UpdateDel()
        {
            LCB_LCBRMod.OpenGamePath();
            Application.Quit();
        }
        static void DownloadFileAsync(string uri, string filePath)
        {
            try
            {
                LCB_LCBRMod.LogWarning("Download " + uri + " to " + filePath);
                using HttpClient client = new();
                using HttpResponseMessage response = client.GetAsync(uri).GetAwaiter().GetResult();
                using HttpContent content = response.Content;
                using FileStream fileStream = new(filePath, FileMode.Create);
                content.CopyToAsync(fileStream).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                if (ex is HttpRequestException httpException && httpException.StatusCode == HttpStatusCode.NotFound)
                    LCB_LCBRMod.LogWarning($"{uri} 404 NotFound,No Resource");
                else
                    LCB_LCBRMod.LogWarning($"{uri} Error!!!" + ex.ToString());
            }
        }
        public static void CheckReadmeUpdate()
        {
            UnityWebRequest www = UnityWebRequest.Get("");
            www.timeout = 1;
            www.SendWebRequest();
            string FilePath = LCB_LCBRMod.ModPath + "/Localize/Readme/Readme.json";
            var LastWriteTime = new FileInfo(FilePath).LastWriteTime;
            while (!www.isDone)
            {
                Thread.Sleep(100);
            }
            if (www.result == UnityWebRequest.Result.Success && LastWriteTime < DateTime.Parse(www.downloadHandler.text))
            {
                UnityWebRequest www2 = UnityWebRequest.Get("");
                www2.SendWebRequest();
                while (!www2.isDone)
                {
                    Thread.Sleep(100);
                }
                File.WriteAllText(FilePath, www2.downloadHandler.text);
                LCBR_ReadmeManager.InitReadmeList();
            }
        }
        public static string Updatelog;
        public static Action UpdateCall;
        public enum URI
        {
            GitHub,
            Mirror_OneDrive
        }
    }
}