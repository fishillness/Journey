using UnityEngine;

namespace Journey
{
    public class UIInstructionPanel : MonoBehaviour
    {
        [SerializeField] private GameObject instructionPanel;
        [SerializeField] private LevelList levelList;

        private void Start()
        {
            ClosePanel();

            if (levelList.LevelsListInfo.Levels[0].SceneName == SceneLoader.GetActiveScene())
            {
                OpenPanel();
            }
        }

        public void OpenPanel()
        {
            instructionPanel.SetActive(true);
        }

        public void ClosePanel()
        {
            instructionPanel.SetActive(false);
        }
    }
}
