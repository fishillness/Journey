using UnityEngine;

namespace Journey
{
    public static class LevelUtil
    {   
        public static int DetermineLevelIndex(LevelList levelList, string sceneName)
        {
            for (int i = 0; i < levelList.LevelsListInfo.Levels.Length; i++)
            {
                if (levelList.LevelsListInfo.Levels[i].SceneName == sceneName)
                {
                    return i;
                }
            }

            return -1;
        }

        public static float FindSavedPlayerRecordTimeByLevel(string levelName)
        {
            return Saves.LoadInt(levelName, 0);
        }

        public static LevelInfo GetLevelInfoBySceneName(LevelList levelList, string sceneName)
        {
            for (int i = 0; i < levelList.LevelsListInfo.Levels.Length; i++)
            {
                if (levelList.LevelsListInfo.Levels[i].SceneName == sceneName)
                    return levelList.LevelsListInfo.Levels[i];
                
            }
            return null;
        }
    }
}

