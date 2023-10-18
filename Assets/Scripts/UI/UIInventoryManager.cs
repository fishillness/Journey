using System.Collections.Generic;
using UnityEngine;

namespace Journey
{
    public class UIInventoryManager : MonoBehaviour
    {
        [SerializeField] private InventoryManager inventory;
        [SerializeField] private List<UIItem> items;

        private void Start()
        {
            InventoryManager.OnUpdateInventory += UpdateInventory;
        }

        private void OnDestroy()
        {
            InventoryManager.OnUpdateInventory -= UpdateInventory;
        }

        private void UpdateInventory(List<ItemInfo> itemInfos)
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].SetInfo(itemInfos[i]);
            }
        }
    }
}

