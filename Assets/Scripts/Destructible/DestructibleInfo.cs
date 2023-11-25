using UnityEngine;

namespace Journey
{
    [CreateAssetMenu]
    public class DestructibleInfo : ScriptableObject
    {
        [SerializeField] private string nameObject;
        [SerializeField] private int hitPoints;
        [SerializeField] private bool isPlaySoundAfterDeath;
        [SerializeField] private SoundType soundType;

        public string Name => nameObject;
        public int HitPoints => hitPoints;
        public bool IsPlaySoundAfterDeath => isPlaySoundAfterDeath;
        public SoundType SoundType => soundType;   
    }
}