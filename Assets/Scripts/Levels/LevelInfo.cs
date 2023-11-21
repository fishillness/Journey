using UnityEngine;

namespace Journey
{
    [CreateAssetMenu]
    public class LevelInfo : ScriptableObject
    {
        [SerializeField] private string levelName;
        [SerializeField] private string sceneName;

        public string LevelName => levelName;
        public string SceneName => sceneName;
    }
}
