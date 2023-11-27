using UnityEngine;
using UnityEngine.Events;

namespace Journey
{
    public class NPS : ItemTaker
    {
        public static event UnityAction<ItemInfo, bool> OnInteracted;

        private void Start()
        {
            UIDialogPanel.OnTakeItem += TakeItem;
        }

        private void OnDestroy()
        {
            UIDialogPanel.OnTakeItem -= TakeItem;
        }

        protected override void ActionUponInteraction()
        {
            Debug.Log("NPS  Pressed E");

            bool isThereItem = inventoryManager.CheckItem(item);
            OnInteracted?.Invoke(item, isThereItem);
        }

        private void TakeItem()
        {
            inventoryManager.RemoveObject(item);

            if (soundPlayer != null && isPlaySoundAfterRemoveItem == true)
            {
                soundPlayer.Play(soundType);
            }

            if (itemTakerInfo.ExchangeItemInfo != null && itemTakerInfo.ExchangeItemPrefab != null)
                inventoryManager.AddObject(itemTakerInfo.ExchangeItemPrefab, itemTakerInfo.ExchangeItemInfo);
        }
    }
}
