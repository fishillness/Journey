using UnityEngine;

namespace Journey
{
    [CreateAssetMenu]
    public class ProjectileInfo : ScriptableObject
    {
        [SerializeField] private float speed;
        [SerializeField] private float lifeTime;
        [SerializeField] private int damage;

        [Header("Sound")]
        [SerializeField] private bool isPlaySoundAfterAppearance;
        [SerializeField] private SoundType soundType;

        public float Speed => speed;
        public float LifeTime => lifeTime;
        public int Damage => damage;
        public bool IsPlaySoundAfterAppearance => isPlaySoundAfterAppearance;
        public SoundType SoundType => soundType;
    }
}
