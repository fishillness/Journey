using UnityEngine;
using UnityEngine.SceneManagement;

namespace Journey
{
    public static class SceneLoader
    {
        public const string MainMenuSceneTitle = "Main Menu";

        public static void LoadMainMenu()
        {
            SceneManager.LoadScene(MainMenuSceneTitle);
        }

        public static void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public static void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public static void LoadNexLevel(LevelList levelList)
        {
            if (!IsLastLevel(levelList))
            {
                SceneManager.LoadScene(levelList.LevelsListInfo.Levels[LevelUtil.DetermineLevelIndex(levelList, SceneManager.GetActiveScene().name) + 1].SceneName);
            }
            else
                Debug.Log("This is a last level");
        }

        public static bool IsLastLevel(LevelList levelList)
        {
            return !(LevelUtil.DetermineLevelIndex(levelList, SceneManager.GetActiveScene().name) < levelList.LevelsListInfo.Levels.Length - 1);
        }

        public static string GetActiveScene()
        {
            return SceneManager.GetActiveScene().name;
        }
    }
}

