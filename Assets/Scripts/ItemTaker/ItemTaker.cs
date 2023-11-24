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
                //���� 4�� �������� �����, � ������� ���������� �������9 � ��������� �����
                Destroy(gameObject);
            }
            else
            {
                //����� ��������9 � ������������� ����� ���4
                OnTriedTakeItem?.Invoke(warningText);
            }
        }

    }
}
