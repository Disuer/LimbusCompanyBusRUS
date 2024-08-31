using HarmonyLib;
using Il2CppSystem.Text;
using MainUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimbusLocalizeRUS
{
    internal class LCBR_Personality_MegaList
    {
        /*
        [HarmonyPatch(typeof(PersonalityStoryPersonalityStorySlot), nameof(PersonalityStoryPersonalityStorySlot.SetData))]
        [HarmonyPostfix]
        private static void StoryName(PersonalityStoryPersonalityStorySlot __instance)
        {
            
            String story = __instance._storyTitleText.text;
            if (__instance._storyTitleText.text.EndsWith("История"))
            {
                __instance._storyTitleText.text = __instance._storyTitleText.text.Replace("  ", " ");
                string[] parts = story.Split(',');
                string faction = parts[0];
                string sinner = parts[1];
                string storyword = "История";
                if (faction.StartsWith("Та"))
                {
                    faction = "Та, кто держит";
                    sinner = " Фауст";
                }
                else if (faction.StartsWith("Тот"))
                {
                    faction = "Тот, кому суждено держать";
                    sinner = " Синклер";
                }

                __instance._storyTitleText.text = $"{faction}: {storyword} {SinnerStory(sinner)}";
            }
        }
        [HarmonyPatch(typeof(StoryTheaterUIPopup), nameof(StoryTheaterUIPopup.OpenStoryEnterPopup))]
        [HarmonyPostfix]
        private static void DescriptionChange(StoryTheaterUIPopup __instance)
        {
            __instance._storyEnterPopup._descText.GetComponentInChildren<UtilityUI.TextMeshProLanguageSetter>(true).enabled = false;
            __instance._storyEnterPopup._descText.text = __instance._storyEnterPopup._descText.text.Replace("войти в\n", "прочесть историю, ");
            String story = __instance._storyEnterPopup._descText.text;
            if (story.EndsWith("История?"))
            {
                story = story.Replace("  ", " ");
                string[] parts = story.Split(',');
                string faction = parts[1];
                string sinner = parts[2];
                if (faction.StartsWith(" Та"))
                {
                    faction = " Та, кто держит";
                    sinner = " Фауст";
                }
                else if (faction.StartsWith(" Тот"))
                {
                    faction = " Тот, кому суждено держать";
                    sinner = " Синклер";
                }

                __instance._storyEnterPopup._descText.text = $"Желаете ли прочесть историю из жизни {SinnerStory(sinner)} как{Personality_MegaList_Gendered(Personality_MegaList(faction), SinnerStory(sinner))}?";
            }
        }
        public static string Personality_MegaList(string identity)
        {
            // Fixer
            if (identity.Contains("ассоциации"))
            {
                identity = identity.Replace("Южная", "Южной").Replace("секция", "секции").Replace("Директор", "директора").Replace("6-ая", "корректировщика 6-ой").Replace("5-ая", "корректировщика 5-ой").Replace("4-ая", "корректировщика 4-ой").Replace("3-ья", "корректировщика 3-ьей").Replace("2-ая", "корректировщика 2-ой").Replace("1-ая", "корректировщика 1-ой");
                return identity;
            }
            else if (identity.Contains("Корректировщик") || identity.Contains("Корректировщица") || identity.Contains("Представитель"))
            {
                identity = identity.Replace("Корректировщик", "корректировщика").Replace("Корректировщица", "корректировщицы").Replace("Представитель", "представителя");
                return identity;
            }
            // Syndicate
            else if (identity.Contains("пальца"))
            {
                identity = identity.Replace("Младший брат", "Младшего брата").Replace("Младшая сестра", "Младшей сестры").Replace("Пуантилист", "Пуантилиста").Replace("студент", "студента").Replace("студентака", "студентки");
                return identity;
            }
            else if (identity.Contains("Босс") || identity.Contains("Шеф ") || identity.Contains("Наставник"))
            {
                identity = identity.Replace("Босс", "босса").Replace("Шеф ", "шефа ").Replace("Наставник", "наставника");
                return identity;
            }
            else if (identity.Contains("Курокумо") || identity.Contains("Сальсу"))
            {
                identity = identity.Replace("Вакасю", "вакасю").Replace("Вакагасира", "вакагасира").Replace("Сальсу", "сальсу");
                return identity;
            }
            // Wing
            else if (identity.Contains("Агент") || identity.Contains("Сотрудник"))
            {
                identity = identity.Replace("Агент", "агента").Replace("Сотрудник", "сотрудника");
                return identity;
            }
            else if (identity.Contains("стаи"))
            {
                identity = identity.Replace("Кролик", "Кролика").Replace("Олень", "Оленя").Replace("Носорог", "Носорога");
                return identity;
            }
            else if (identity.Contains('G'))
            {
                identity = identity.Replace("Командир дивизии", "командира дивизии").Replace("Помощник первого класса", "помощника первого класса");
                return identity;
            }
            else if (identity.Contains("молот") || identity.Contains("держит") || identity.Contains("держать"))
            {
                identity = identity.Replace("Большой молот", "Большого молота").Replace("Средний молот", "Среднего молота").Replace("Малый молот", "Малого молота").Replace("Та", "Той").Replace("Тот", "Того");
                return identity;
            }
            else if (identity.StartsWith(" ЭГО"))
            {
                identity = identity.Replace("ЭГО", "носителя ЭГО");
                return identity;
            }
            else if (identity.Contains("Пережиток"))
            {
                identity = identity.Replace("Пережиток", "бывшего агента");
                return identity;
            }
            //Other
            else if (identity.Contains("Ассистентка"))
            {
                identity = identity.Replace("Ассистентка", "ассистентки");
                return identity;
            }
            else if (identity.Contains("БуР"))
            {
                identity = identity.Replace("Шеф-повар", "шеф-повара").Replace("Су-шеф", "су-шефа");
                return identity;
            }
            else if (identity.Contains("Пекода") || identity.Contains("Двух крюков"))
            {
                identity = identity.Replace("Капитан", "капитана").Replace("Старший помощник", "старшего помощника").Replace("Гарпунщик", "гарпунщика");
                return identity;
            }
            else if (identity.Contains("перевала") || identity.Contains("рода"))
            {
                identity = identity.Replace("Старший дворецкий", "старшего дворецкого").Replace("Лакей", "лакея").Replace("Наследник", "наследника").Replace("Служанка", "служанки").Replace("Экономка", "экономки");
                return identity;
            }
            else if (identity.StartsWith(" Расцветшее"))
            {
                identity = identity.Replace("Расцветшее", "человека, пробудившего Расцветшее");
                return identity;
            }
            return identity;
        }
        public static string SinnerStory(string sinnerName)
        {
            if (sinnerName == " И Сан")
                return "И Сана";
            else if (sinnerName == " Фауст")
                return "Фауст";
            else if (sinnerName == " Дон Кихот")
                return "Дон Кихот";
            else if (sinnerName == " Рёшу")
                return "Рёшу";
            else if (sinnerName == " Мерсо")
                return "Мерсо";
            else if (sinnerName == " Хон Лу")
                return "Хон Лу";
            else if (sinnerName == " Хитклиф")
                return "Хитклифа";
            else if (sinnerName == " Измаил")
                return "Измаил";
            else if (sinnerName == " Родя")
                return "Роди";
            else if (sinnerName == " Синклер")
                return "Синклера";
            else if (sinnerName == " Отис")
                return "Отис";
            else if (sinnerName == " Грегор")
                return "Грегора";
            else
                return "[ДАННЫЕ УДАЛЕНЫ]";
        }
        public static string Personality_MegaList_Gendered(string identity, string sinner)
        {
            if (sinner == "Фауст" || sinner == "Дон Кихот" || sinner == "Рёшу" || sinner == "Измаил" || sinner == "Роди" || sinner == "Отис")
                identity = identity.Replace("корректировщика", "корректировщицы").Replace("представителя", "представительницы").Replace("носителя", "носительницы");
            return identity;
        }
        */
        [HarmonyPatch(typeof(PersonalityStoryPersonalityStorySlot), nameof(PersonalityStoryPersonalityStorySlot.SetData))]
        [HarmonyPostfix]
        public static void StoryName(PersonalityStoryPersonalityStorySlot __instance)
        {
            if (__instance._storyTitleText.text.Contains("История"))
            {
                LCB_LCBRMod.LogInfo("sosat");
            }
        }
    }
}
