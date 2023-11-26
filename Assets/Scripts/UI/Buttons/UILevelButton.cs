using UnityEngine;
using UnityEngine.UI;

namespace Journey
{
    public class UILevelButton : MonoBehaviour, IScriptableObjectProperty
    {
        [SerializeField] private Text levelName;
        [SerializeField] private LevelInfo levelInfo;
        [SerializeField] private GameObject block;

        private Button button;

        public LevelInfo LevelInfo => levelInfo;

        private void Start()
        {
            button = GetComponent<Button>();
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

        public void SetInteractable()
        {
            block.SetActive(false);
            button.interactable = true;
        }

        public void SetNonInteractable()
        {
            block.SetActive(true);
            button.interactable = false;  
        }
    }
}
