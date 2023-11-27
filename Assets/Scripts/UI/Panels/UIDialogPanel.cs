using UnityEngine;
using UnityEngine.Events;

namespace Journey
{
    public class UIDialogPanel : MonoBehaviour
    {
        public static event UnityAction OnTakeItem;

        [SerializeField] private GameObject dialogPanel;
        [SerializeField] private GameObject itemButton;

        private void Start()
        {
            dialogPanel.SetActive(false);
            NPÑ.OnInteracted += DialogStart;
        }

        private void OnDestroy()
        {
            NPÑ.OnInteracted -= DialogStart;
        }

        private void DialogStart(ItemInfo itemInfo, bool isThereItem)
        {
            dialogPanel.SetActive(true);

            if (isThereItem)
            {
                itemButton.SetActive(true);
            }
            else
            {
                itemButton.SetActive(false);
            }
        }

        public void ItemButton()
        {
            OnTakeItem?.Invoke();
            dialogPanel.SetActive(false);
        }

        public void CloseButton()
        {
            dialogPanel.SetActive(false);
        }

    }
}
