using UnityEngine;
using UnityEngine.Events;

namespace Journey
{
    public class Item : MonoBehaviour, IDependency<SoundPlayer>
    {
        public static event UnityAction<Item, ItemInfo> OnPickUp;

        [SerializeField] private ItemInfo itemInfo;

        private SoundPlayer soundPlayer;
        private Item item;

        public ItemInfo ItemInfo => itemInfo;

        public void Construct(SoundPlayer obj) => soundPlayer = obj;

        private void Start()
        {
            InventoryManager.OnAddObject += DestroyObject;
            item = gameObject.GetComponent<Item>();
        }

        private void OnDestroy()
        {
            InventoryManager.OnAddObject -= DestroyObject;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player != null)
            {
                OnPickUp?.Invoke(item, itemInfo);
            }
        }

        private void DestroyObject(Item item, ItemInfo itemInfo)
        {
            if (item == this.item && itemInfo == this.itemInfo)
            {
                if (soundPlayer != null && itemInfo.IsPlaySoundAfterPickedUp == true)
                {
                    soundPlayer.Play(itemInfo.SoundType);
                }

                Destroy(gameObject);
            }
        }
    }
}
