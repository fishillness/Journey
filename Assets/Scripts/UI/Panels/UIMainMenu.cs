using UnityEngine;

namespace Journey
{
    public class UIMainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private GameObject levelsPanel;
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private GameObject controlPanel;
        [SerializeField] private GameObject confirmationPanel;

        [SerializeField] private GameObject continueButton;

        private LevelList levelList;

        private bool isThereSaves;

        private void Start()
        {
            levelList = GameObject.FindAnyObjectByType<LevelList>();
            OpenPanel(menuPanel);
            confirmationPanel.SetActive(false);

            isThereSaves = (LevelUtil.FindSavedByLevel("Level 1") != 0);
            continueButton.SetActive(isThereSaves);
        }

        public void MenuButton()
        {
            OpenPanel(menuPanel);
        }

        public void NewGameButton()
        {
            if (isThereSaves)
            {
                confirmationPanel.SetActive(true);
            }
            else
            {
                OpenPanel(levelsPanel);
            }
        }

        public void OkButton()
        {
            Saves.DeleteInfoAboutLevels(levelList.LevelsListInfo);
            confirmationPanel.SetActive(false);
            OpenPanel(levelsPanel);
        }
        public void CancelButton()
        {
            confirmationPanel.SetActive(false);
        }

        public void ContinueButton()
        {
            OpenPanel(levelsPanel);
        }

        public void SettingsButton()
        {
            OpenPanel(settingsPanel);
        }

        public void ControlButton()
        {
            OpenPanel(controlPanel);
        }

        public void QuitButton()
        {
            Application.Quit();
        }

        private void OpenPanel(GameObject panel)
        {
            menuPanel.SetActive(false);
            levelsPanel.SetActive(false);
            settingsPanel.SetActive(false);
            controlPanel.SetActive(false);

            panel.SetActive(true);
        }
    }
}

