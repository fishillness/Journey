using UnityEngine;

namespace Journey
{
    public class UIMainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject MenuPanel;
        [SerializeField] private GameObject LevelsPanel;
        [SerializeField] private GameObject SettingsPanel;
        [SerializeField] private GameObject ControlPanel;


        private void Start()
        {
            OpenPanel(MenuPanel);

        }

        public void MenuButton()
        {
            OpenPanel(MenuPanel);
        }

        public void LevelsButton()
        {
            OpenPanel(LevelsPanel);
        }

        public void SettingsButton()
        {
            OpenPanel(SettingsPanel);
        }

        public void ControlButton()
        {
            OpenPanel(ControlPanel);
        }

        public void QuitButton()
        {
            Application.Quit();
        }

        private void OpenPanel(GameObject panel)
        {
            MenuPanel.SetActive(false);
            LevelsPanel.SetActive(false);
            SettingsPanel.SetActive(false);
            ControlPanel.SetActive(false);

            panel.SetActive(true);
        }

    }
}

