using UnityEngine;

namespace Journey
{
    public class ItemTaker : TriggerColliderInteracted
    {
        [SerializeField] private ItemInfo item;
        [SerializeField] private InventoryManager inventoryManager;

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
            }
        }

    }
}
