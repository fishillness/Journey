using UnityEngine;
using UnityEngine.UI;

namespace Journey
{
    public class UILevelButton : MonoBehaviour
    {
        [SerializeField] private Text levelName;
        [SerializeField] private LevelInfo levelInfo;

        private void Start()
        {
            levelName.text = levelInfo.LevelName;
        }

        public void StartButton()
        {
            SceneLoader.LoadScene(levelInfo.SceneName);
        }
    }
}
