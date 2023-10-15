using UnityEngine;

namespace Journey
{

    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float lifeTime;
        [SerializeField] private int damage;

        protected Destructible parent;
        private float Timer;

        private float stepLength;
        private Vector2 step;

        private void Update()
        {
            Move();
            CheckHit();
            UpdateLifeTimer();
        }

        private void Move()
        {
            stepLength = Time.deltaTime * speed;
            step = transform.up * stepLength;
            transform.position += new Vector3(step.x, step.y, 0);
        }

        private void CheckHit()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, stepLength);
            if (hit)
            {
                Destructible dest = hit.collider.transform.root.GetComponent<Destructible>();

                if (dest != parent)
                {
                    if (dest != null)
                        dest.ApplyDamage(damage);

                    DestroyProjectile();
                }
            }
        }

        private void DestroyProjectile()
        {
            Destroy(gameObject);
        }

        private void UpdateLifeTimer()
        {
            Timer += Time.deltaTime;

            if (Timer > lifeTime)
                DestroyProjectile();
        }

        public void SetParent(Destructible parent)
        {
            this.parent = parent;
        }
    }
}