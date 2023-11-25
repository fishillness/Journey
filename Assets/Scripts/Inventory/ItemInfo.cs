using UnityEngine;

namespace Journey
{

    [CreateAssetMenu]
    public class ItemInfo : ScriptableObject
    {
        [SerializeField] private string nameItem;
        [SerializeField] private int id;
        [SerializeField] private string description;

        [SerializeField] private Sprite icon;
        [SerializeField] private GameObject prefab;

        [Header("Sound")]
        [SerializeField] private bool isPlaySoundAfterPickedUp;
        [SerializeField] private SoundType soundType;

        public string NameItem => nameItem;
        public int Id => id;
        public string Description => description;
        public Sprite Icon => icon;
        public GameObject Prefab => prefab;
        public bool IsPlaySoundAfterPickedUp => isPlaySoundAfterPickedUp;
        public SoundType SoundType => soundType;
    }
}
