using UnityEngine;

namespace Journey
{
    public class UIInstructionPanel : MonoBehaviour, IDependency<LevelList>
    {
        [SerializeField] private GameObject instructionPanel;

        private LevelList levelList;
        public void Construct(LevelList obj) => levelList = obj;

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
