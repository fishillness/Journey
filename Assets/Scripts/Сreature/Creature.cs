using UnityEngine;

namespace Journey
{
    public class Creature : Destructible
    {
        [SerializeField] private float speed = 2f;

        private new Rigidbody2D rigidbody;
        private AnimatorController animatorController;
        private Vector2 nextPosition;

        protected Vector2 direction;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animatorController = GetComponentInChildren<AnimatorController>();
        }

        private void FixedUpdate()
        {
            Move();
            UpdateAnimator(direction);
        }


        public virtual void SetDirection(float horizontal, float vertical)
        {
            direction = new Vector2(horizontal, vertical);
            direction = Vector2.ClampMagnitude(direction, 1);
        }

        protected virtual void Move()
        {
            nextPosition = rigidbody.position + direction * speed * Time.fixedDeltaTime;
            //animatorController.SetDirection(direction);
            rigidbody.MovePosition(nextPosition);
        }

        protected void UpdateAnimator(Vector2 direction)
        {
            animatorController.SetDirection(direction);
        }
    }
}
