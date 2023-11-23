using UnityEngine;

namespace Journey
{
    [CreateAssetMenu]
    public class LevelListInfo : ScriptableObject
    {
        [SerializeField] private LevelInfo[] levels;

        public LevelInfo[] Levels => levels;
    }
}
