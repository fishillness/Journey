using UnityEngine;
using UnityEngine.UI;

namespace Journey
{
    public class UIWarningPanel : MonoBehaviour
    {
        [SerializeField] private GameObject warningPanel;
        [SerializeField] private Text warningText;

        private void Start()
        {
            ItemTaker.OnTriedTakeItem += OpenPanel;
            warningPanel.SetActive(false);
        }

        private void OnDestroy()
        {
            ItemTaker.OnTriedTakeItem -= OpenPanel;
        }

        private void OpenPanel(string warningText)
        {
            this.warningText.text = warningText;
            warningPanel.SetActive(true);
        }

        public void CloseButton()
        {
            warningPanel.SetActive(false);
        }

    }
}

