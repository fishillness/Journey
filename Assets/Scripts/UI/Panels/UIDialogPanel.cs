using UnityEngine;
using UnityEngine.Events;

namespace Journey
{
    public class UIDialogPanel : MonoBehaviour
    {
        public static event UnityAction OnTakeItem;

        [SerializeField] private GameObject dialogPanel;
        [SerializeField] private GameObject itemButton;

        private bool isItemTaked;


        private void Start()
        {
            dialogPanel.SetActive(false);
            NP�.OnInteracted += DialogStart;
        }

        private void OnDestroy()
        {
            NP�.OnInteracted -= DialogStart;
        }

        private void DialogStart(ItemInfo itemInfo, bool isThereItem)
        {
            if (isItemTaked) return;

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
            isItemTaked = true;
            dialogPanel.SetActive(false);
        }

        public void CloseButton()
        {
            dialogPanel.SetActive(false);
        }

    }
}
