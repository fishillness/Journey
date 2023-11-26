using UnityEngine;

namespace Journey
{
    public static class Saves
    {
        public static void SaveInt(string title, int value)
        {
            PlayerPrefs.SetInt(title, value);
        }

        public static void SaveFloat(string title, float value)
        {
            PlayerPrefs.SetFloat(title, value);
        }

        public static int LoadInt(string title, int defaultValue)
        {
            return PlayerPrefs.GetInt(title, defaultValue);
        }

        public static float LoadFloat(string title, float defaultValue)
        {
            return PlayerPrefs.GetFloat(title, defaultValue);
        }

        public static void DeleteAllSaves()
        {
            PlayerPrefs.DeleteAll();
        }

        public static void DeleteInfoAboutLevels(LevelListInfo levelListInfo)
        {
            for (int i = 0; i < levelListInfo.Levels.Length; i++)
            {
                PlayerPrefs.DeleteKey(levelListInfo.Levels[i].LevelName);
            }
        }
    }
}
