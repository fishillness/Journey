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
            return Saves.LoadFloat(levelName, 0);
        }

        public static LevelInfo GetLevelInfoBySceneName(LevelList levelList, string sceneName)
        {
            Debug.Log(levelList);
            /*
            for (int i = 0; i < levelList.LevelsListInfo.Levels.Length; i++)
            {
                Debug.Log($"levelList.LevelsListInfo.Levels[{i}].SceneName = {levelList.LevelsListInfo.Levels[i].SceneName}");
                
                if (levelList.LevelsListInfo.Levels[i].SceneName == sceneName)
                    return levelList.LevelsListInfo.Levels[i];
                
            }*/
            return null;
        }
    }
}

