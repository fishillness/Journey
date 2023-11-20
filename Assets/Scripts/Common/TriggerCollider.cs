using UnityEngine;

namespace Journey
{
    public class TriggerCollider : MonoBehaviour
    {
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
    }
}
