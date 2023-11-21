using UnityEngine;

namespace Journey
{
    public class LevelInfo : MonoBehaviour
    {
        [SerializeField] private string levelName;
        [SerializeField] private string sceneName;

        public string LevelName => levelName;
        public string SceneName => sceneName;
    }
}
