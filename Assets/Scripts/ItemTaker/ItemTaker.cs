using UnityEngine;
using UnityEngine.Events;

namespace Journey
{
    public class ItemTaker : TriggerColliderInteracted, IScriptableObjectProperty
    {
        public static event UnityAction<string> OnTriedTakeItem;

        [SerializeField] private InventoryManager inventoryManager;
        [SerializeField] private ItemTakerInfo itemTakerInfo;

        [SerializeField] private ItemInfo item;
        [SerializeField] private string warningText;
           
        private void Awake()
        {
            ApplyProperty(itemTakerInfo);
        }

        protected override void ActionUponInteraction()
        {
            bool isThereItem = inventoryManager.CheckItem(item);

            if (isThereItem)
            {
                inventoryManager.RemoveObject(item);
                //пока 4то удаление двери, в будущем желательно анммаци9 с открьтием двери
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
        }
    }
}
