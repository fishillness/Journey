using UnityEngine;
using UnityEngine.Events;

namespace Journey
{
    public class ItemTaker : TriggerColliderInteracted, IScriptableObjectProperty
    {
        public static event UnityAction<string> OnTriedTakeItem;

        [SerializeField] protected InventoryManager inventoryManager;
        [SerializeField] protected SoundPlayer soundPlayer;
        [SerializeField] protected ItemTakerInfo itemTakerInfo;

        protected ItemInfo item;
        private string warningText;
        protected bool isPlaySoundAfterRemoveItem;
        protected SoundType soundType;

        private void Awake()
        {
            if (itemTakerInfo)
                ApplyProperty(itemTakerInfo);
        }

        protected override void ActionUponInteraction()
        {
            bool isThereItem = inventoryManager.CheckItem(item);

            if (isThereItem)
            {
                inventoryManager.RemoveObject(item);

                if (soundPlayer != null && isPlaySoundAfterRemoveItem == true)
                {
                    soundPlayer.Play(soundType);
                }

                Destroy(gameObject);
            }
            else
            {
                OnTriedTakeItem?.Invoke(warningText);
            }
        }
        public void ApplyProperty(ScriptableObject property)
        {
            if (property == null) return;

            if (property is ItemTakerInfo == false)
                return;

            itemTakerInfo = property as ItemTakerInfo;
            item = itemTakerInfo.Item;
            warningText = itemTakerInfo.WarningText;
            isPlaySoundAfterRemoveItem = itemTakerInfo.IsPlaySoundAfterRemoveItem;
            soundType = itemTakerInfo.SoundType;
        }
    }
}
