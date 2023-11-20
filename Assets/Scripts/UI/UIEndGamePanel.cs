using UnityEngine;

namespace Journey
{
    public class UIEndGamePanel : MonoBehaviour
    {
        [SerializeField] private GameObject confirmationPanel;
        [SerializeField] private GameObject endGamePanel;
        [SerializeField] private GameObject nextButton;

        private void Start()
        {
            confirmationPanel.SetActive(false);
            endGamePanel.SetActive(false);

            //�������� �� ������� ������ confirmationPanel  = OpenConfirmationPanel();
        }

        private void OpenConfirmationPanel()
        {
            confirmationPanel.SetActive(true);
        }

        public void YesButton()
        {
            confirmationPanel.SetActive(false);
            endGamePanel.SetActive(true);
        }

        public void NoButton()
        {
            confirmationPanel.SetActive(false);
        }

        public void NextButton()
        {
            //����� ���� �����9, ���� �� ����
        }

        public void ReplayButton()
        {
            //���������� �����9
        }

        public void MenuButton()
        {
            //�������� ����
        }
    }
}
