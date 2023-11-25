using UnityEngine;
using UnityEngine.Events;

namespace Journey
{
    public class Destructible : MonoBehaviour, IScriptableObjectProperty
    {
        public event UnityAction OnDeath;

        [SerializeField] private int hitPoints;
        [SerializeField] private DestructibleInfo destInfo;
        [SerializeField] private SoundPlayer soundPlayer;

        private int currentHitPoints;
        private bool isPlaySoundAfterDeath;
        private SoundType soundType;

        public int HitPoints => currentHitPoints;

        protected virtual void Start()
        {
            currentHitPoints = hitPoints;

            if (destInfo)
                ApplyProperty(destInfo);
        }

        public void ApplyDamage(int damage)
        {
            currentHitPoints -= damage;

            if (currentHitPoints <= 0)
                Death();
        }

        protected virtual void Death()
        {
            if (soundPlayer != null && isPlaySoundAfterDeath == true)
            {
                soundPlayer.Play(soundType);
            } 

            Destroy(gameObject);
            OnDeath?.Invoke();
        }

        public void ApplyProperty(ScriptableObject property)
        {
            if (property == null) return;

            if (property is DestructibleInfo == false)
                return;

            destInfo = property as DestructibleInfo;
            hitPoints = destInfo.HitPoints;
            isPlaySoundAfterDeath = destInfo.IsPlaySoundAfterDeath;
            soundType = destInfo.SoundType;
        }
    }

}