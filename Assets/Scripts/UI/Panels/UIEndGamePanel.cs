using UnityEngine;

namespace Journey
{
    public class UIEndGamePanel : MonoBehaviour, IDependency<LevelList>
    {
        [SerializeField] private GameObject confirmationPanel;
        [SerializeField] private GameObject endGamePanel;
        [SerializeField] private GameObject nextButton;

        private LevelList levelList;

        public void Construct(LevelList obj) => levelList = obj;

        private void Start()
        {
            //LevelList levelList = GameObject.FindObjectOfType<LevelList>();

            confirmationPanel.SetActive(false);
            endGamePanel.SetActive(false);

            if (SceneLoader.IsLastLevel(levelList))
                nextButton.SetActive(false);

            Portal.OnCompletedLevel += OpenConfirmationPanel;
        }

        private void OnDestroy()
        {
            Portal.OnCompletedLevel -= OpenConfirmationPanel;
        }

        private void OpenConfirmationPanel()
        {
            confirmationPanel.SetActive(true);
        }

        public void YesButton()
        {
            LevelInfo levelInfo = LevelUtil.GetLevelInfoBySceneName(levelList, SceneLoader.GetActiveScene());
            Saves.SaveInt(levelInfo.LevelName, 1);

            confirmationPanel.SetActive(false);
            endGamePanel.SetActive(true);
        }

        public void NoButton()
        {
            confirmationPanel.SetActive(false);
        }

        public void NextButton()
        {
            SceneLoader.LoadNexLevel(levelList);
        }

        public void ReplayButton()
        {
            SceneLoader.Restart();
        }

        public void MenuButton()
        {
            SceneLoader.LoadMainMenu();
        }
    }
}
