using UnityEngine;

namespace Journey
{
    [CreateAssetMenu]
    public class ItemTakerInfo : ScriptableObject
    {
        [SerializeField] private string nameObject;
        [SerializeField] private ItemInfo item;
        [SerializeField] private string warningText = "You need a ... .";

        public string Name => nameObject;
        public ItemInfo Item => item;
        public string WarningText => warningText;

    }
}
