using UnityEngine;

namespace Journey
{

    public class Projectile : MonoBehaviour, IScriptableObjectProperty
    {
        [SerializeField] private ProjectileInfo projectileInfo;
        
        [Header("If there is no ProjectileInfo")]
        [SerializeField] private float speed;
        [SerializeField] private float lifeTime;
        [SerializeField] private int damage;

        [SerializeField] private bool isPlaySoundAfterAppearance;
        [SerializeField] private SoundType soundType;

        protected Destructible parent;
        private SoundPlayer soundPlayer;
        private float Timer;

        private float stepLength;
        private Vector2 step;

        private void Start()
        {
            soundPlayer = GameObject.FindObjectOfType<SoundPlayer>();

            if (projectileInfo)
                ApplyProperty(projectileInfo);

            if (soundPlayer != null && isPlaySoundAfterAppearance == true)
                soundPlayer.Play(soundType);
        }

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
                //Destructible dest = hit.collider.transform.root.GetComponent<Destructible>();
                Destructible dest = hit.collider.transform.GetComponentInParent<Destructible>();

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

        public void ApplyProperty(ScriptableObject property)
        {
            if (property == null) return;

            if (property is ProjectileInfo == false)
                return;

            projectileInfo = property as ProjectileInfo;
            speed = projectileInfo.Speed;
            lifeTime = projectileInfo.LifeTime;
            damage = projectileInfo.Damage;
            isPlaySoundAfterAppearance = projectileInfo.IsPlaySoundAfterAppearance;
            soundType = projectileInfo.SoundType;
        }
    }
}