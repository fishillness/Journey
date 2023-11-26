using UnityEngine;

namespace Journey
{
    public class LevelList : MonoBehaviour
    {
        [SerializeField] private LevelListInfo levelsListInfo;

        public LevelListInfo LevelsListInfo => levelsListInfo;
    }
}

