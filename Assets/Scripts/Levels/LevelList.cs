using UnityEngine;

namespace Journey
{
    public class LevelList : MonoBehaviour
    {
        [SerializeField] private LevelInfo[] levels;

        public LevelInfo[] Levels => levels;
    }
}

