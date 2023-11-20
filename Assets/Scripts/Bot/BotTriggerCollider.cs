using UnityEngine;

namespace Journey
{
    public class BotTriggerCollider : TriggerCollider
    {
        [SerializeField] private float visibilityDistance = 0.5f;

        public void Move(Vector3 botPosition, Vector2 direction)
        {
            float lenghtVector = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y);
            float coefficient = visibilityDistance / lenghtVector;
            Vector2 newDir = direction * coefficient;

            transform.position = (Vector2)botPosition + newDir;
        }
    }
}