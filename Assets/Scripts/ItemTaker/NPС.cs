using UnityEngine;
using UnityEngine.Events;

namespace Journey
{
    public class NPÑ : ItemTaker
    {
        public static event UnityAction<ItemInfo, bool> OnInteracted;

        protected override void Start()
        {
            base.Start();
            UIDialogPanel.OnTakeItem += TakeItem;
        }

        private void OnDestroy()
        {
            UIDialogPanel.OnTakeItem -= TakeItem;
        }

        protected override void ActionUponInteraction()
        {
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
