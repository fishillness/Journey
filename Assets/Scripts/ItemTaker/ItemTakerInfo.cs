using UnityEngine;

namespace Journey
{
    [CreateAssetMenu]
    public class ItemTakerInfo : ScriptableObject
    {
        [SerializeField] private string nameObject;
        [SerializeField] private ItemInfo item;
        [SerializeField] private string warningText = "You need a ... .";
        [Header("Sound")]
        [SerializeField] private bool isPlaySoundAfterRemoveItem;
        [SerializeField] private SoundType soundType;

        public string Name => nameObject;
        public ItemInfo Item => item;
        public string WarningText => warningText;

        //Sound
        public bool IsPlaySoundAfterRemoveItem => isPlaySoundAfterRemoveItem;
        public SoundType SoundType => soundType;
    }
}
