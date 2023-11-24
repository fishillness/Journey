using UnityEngine;
using UnityEngine.Events;

namespace Journey
{
    public class ItemTaker : TriggerColliderInteracted
    {
        public static event UnityAction<string> OnTriedTakeItem;

        [SerializeField] private InventoryManager inventoryManager;

        [SerializeField] private ItemInfo item;
        [SerializeField] private string warningText = "You need a key.";


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
                //вьвод сообщени9 о необходимости найти клю4
                OnTriedTakeItem?.Invoke(warningText);
            }
        }

    }
}
