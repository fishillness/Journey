using UnityEngine;
using UnityEngine.Events;

namespace Journey
{
    public class Destructible : MonoBehaviour
    {
        public event UnityAction OnDeath;

        [SerializeField] private int hitPoints;

        private int currentHitPoints;

        public int HitPoints => currentHitPoints;

        protected virtual void Start()
        {
            currentHitPoints = hitPoints;
        }

        public void ApplyDamage(int damage)
        {
            currentHitPoints -= damage;

            if (currentHitPoints <= 0)
                Death();
        }

        protected virtual void Death()
        {
            Destroy(gameObject);
            OnDeath?.Invoke();
        }

    }

}