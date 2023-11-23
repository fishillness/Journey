using UnityEngine;

namespace Journey
{
    public static class LevelUtil
    {   
        public static int DetermineLevelIndex(LevelList levelList, string sceneName)
        {
            for (int i = 0; i < levelList.Levels.Length; i++)
            {
                if (levelList.Levels[i].SceneName == sceneName)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
