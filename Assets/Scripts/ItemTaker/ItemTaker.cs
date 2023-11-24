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
                //���� 4�� �������� �����, � ������� ���������� �������9 � ��������� �����
                Destroy(gameObject);
            }
            else
            {
                //����� ��������9 � ������������� ����� ���4
            }
        }

    }
}
