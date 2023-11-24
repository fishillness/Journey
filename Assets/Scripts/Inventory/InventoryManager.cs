using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Journey
{
    public class InventoryManager : MonoBehaviour
    {
        public static event UnityAction<Item, ItemInfo> OnAddObject;
        public static event UnityAction<List<ItemInfo>> OnUpdateInventory;

        private List<ItemInfo> itemInfos;
        private int maxCount = 3;

        private void Start()
        {
            itemInfos = new List<ItemInfo>();

            for (int i = 0; i < maxCount; i++)
            {
                itemInfos.Add(new ItemInfo());
            }

            Item.OnPickUp += AddObject;
        }

        private void OnDestroy()
        {
            Item.OnPickUp += AddObject;
        }

        public void AddObject(Item item, ItemInfo itemInfo)
        {
            if (itemInfos[itemInfos.Count - 1].Id != 0) return; 

            for (int i = 0; i < itemInfos.Count; i++)
            {
                if (itemInfos[i].Id == 0)
                {
                    itemInfos[i] = itemInfo;
                    OnAddObject?.Invoke(item, itemInfo);
                    break;
                }
            }

            OnUpdateInventory?.Invoke(itemInfos);
        }

        public void RemoveObject(ItemInfo itemInfo)
        {
            var isRemove = itemInfos.Remove(itemInfo);

            if (isRemove == true)
                itemInfos.Add(new ItemInfo());

            OnUpdateInventory?.Invoke(itemInfos);
        }

        public bool CheckItem(ItemInfo itemInfo)
        {
            if (!itemInfos.Contains(itemInfo))
                return false;

            for (int i = 0; i < itemInfos.Count - 1; i++)
            {
                if (itemInfos[i] == itemInfo)
                    return true;
            }

            return false;
        }

    }
}