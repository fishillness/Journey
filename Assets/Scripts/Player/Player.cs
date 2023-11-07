using UnityEngine;

namespace Journey
{
    public class Player : Creature
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private float refireTime;

        private float refireTimer;
        private Destructible parent;

        public bool CanFire => refireTimer <= 0;

        protected Vector2 lastDirection;

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
            projectile.transform.up = lastDirection;
            projectile.SetParent(parent);

            refireTimer = refireTime;

        }

        public override void SetDirection(float horizontal, float vertical)
        {
            if (new Vector2(horizontal, vertical).magnitude > 0.1f)
                lastDirection = direction;

            base.SetDirection(horizontal, vertical);
        }
    }
}
