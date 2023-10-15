using UnityEngine;

namespace Journey
{
    public class Player : Ñreature
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private float refireTime;

        private float refireTimer;
        private Destructible parent;

        public bool CanFire => refireTimer <= 0;

        protected override void Start()
        {
            base.Start();
            parent = gameObject.GetComponent<Destructible>();
        }

        private void Update()
        {
            UpdateRefireTimer();
        }

        private void UpdateRefireTimer()
        {
            if (refireTimer > 0)
                refireTimer -= Time.deltaTime;
        }
        public void Fire()
        {
            if (refireTimer > 0) return;

            Projectile projectile = Instantiate(projectilePrefab).GetComponent<Projectile>();
            projectile.transform.position = transform.position;
            projectile.transform.up = direction;
            projectile.SetParent(parent);

            refireTimer = refireTime;

        }
    }
}
