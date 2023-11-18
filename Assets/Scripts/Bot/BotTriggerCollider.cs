using UnityEngine;

namespace Journey
{
    public class BotTriggerCollider : MonoBehaviour
    {
        [SerializeField] private float visibilityDistance = 0.5f;

        [Header("DEBUG")]
        [SerializeField] private bool isPlayerEnter;

        public bool IsPlayerEnter => isPlayerEnter;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                isPlayerEnter = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                isPlayerEnter = false;
            }
        }

        public void Move(Vector3 botPosition, Vector2 direction)
        {
            float lenghtVector = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y);
            float coefficient = visibilityDistance / lenghtVector;
            Vector2 newDir = direction * coefficient;

            transform.position = (Vector2)botPosition + newDir;
        }
    }
}