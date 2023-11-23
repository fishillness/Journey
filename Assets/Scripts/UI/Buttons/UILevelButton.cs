using UnityEngine;
using UnityEngine.UI;

namespace Journey
{
    public class UILevelButton : MonoBehaviour, IScriptableObjectProperty
    {
        [SerializeField] private Text levelName;
        [SerializeField] private LevelInfo levelInfo;

        private void Start()
        {
            ApplyProperty(levelInfo);
        }

        public void StartButton()
        {
            SceneLoader.LoadScene(levelInfo.SceneName);
        }

        public void ApplyProperty(ScriptableObject property)
        {
            if (property == null) return;

            if (property is LevelInfo == false)
                return;

            levelInfo = property as LevelInfo;
            levelName.text = levelInfo.LevelName;
        }
    }
}
