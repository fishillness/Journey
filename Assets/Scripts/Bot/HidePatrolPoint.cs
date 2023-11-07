using UnityEngine;

namespace Journey
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class HidePatrolPoint : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = false;
        }
    }
}
