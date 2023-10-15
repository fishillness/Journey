using UnityEngine;

namespace Journey
{
    public class Ñreature : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;

        private new Rigidbody2D rigidbody;
        private AnimatorController animatorController;
        private Vector2 direction;
        private Vector2 nextPosition;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animatorController = GetComponentInChildren<AnimatorController>();
        }

        private void FixedUpdate()
        {
            Move();
        }


        public void SetDirection(float horizontal, float vertical)
        {
            direction = new Vector2(horizontal, vertical);
            direction = Vector2.ClampMagnitude(direction, 1);
        }

        public void Move()
        {
            nextPosition = rigidbody.position + direction * speed * Time.fixedDeltaTime;
            animatorController.SetDirection(direction);
            rigidbody.MovePosition(nextPosition);
        }


    }
}
