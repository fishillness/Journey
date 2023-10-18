using UnityEngine;
using UnityEngine.UI;

namespace Journey
{
    public class UIItem : MonoBehaviour
    {
        [SerializeField] private Image icon;

        private void Start()
        {
            icon.enabled = false;
        }

        public void SetInfo(ItemInfo itemInfo)
        {
            if (itemInfo.Icon == null)
            {
                icon.enabled = false;
                icon.sprite = null;
            }
            else
            {
                icon.enabled = true;
                icon.sprite = itemInfo.Icon;
            }
        }
    }
}