using UnityEngine;

namespace Journey
{
    public class UIPausePanel : MonoBehaviour
    {
        [SerializeField] private GameObject pausePanel;
        [SerializeField] private UIInstructionPanel instructionPanel;
        [SerializeField] private Pauser pauser;

        private void Start()
        {
            pausePanel.SetActive(false);
            Pauser.PauseStateChange += ChangePausePanelActive;
        }

        private void OnDestroy()
        {
            Pauser.PauseStateChange -= ChangePausePanelActive;
        }

        private void ChangePausePanelActive(bool isPause)
        {
            if (isPause)
                pausePanel.SetActive(true);
            else
                pausePanel.SetActive(false);
        }

        public void ReplayButton()
        {
            pauser.UnPause();
            SceneLoader.Restart();
        }

        public void InstractionButton()
        {
            instructionPanel.OpenPanel();
        }

        public void MenuButton()
        {
            pauser.UnPause();
            SceneLoader.LoadMainMenu();
        }
    }
}
