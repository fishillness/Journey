using UnityEngine;


namespace Journey
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorController : MonoBehaviour
    {
        public static readonly string[] staticDirections = { "Static N", "Static NW", "Static W", "Static SW", "Static S", "Static SE", "Static E", "Static NE" };
        public static readonly string[] runDirections = { "Run N", "Run NW", "Run W", "Run SW", "Run S", "Run SE", "Run E", "Run NE" };

        private Animator animator;
        private int lastDirection;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void SetDirection(Vector2 direction)
        {
            string[] directionArray = null;

            if (direction.magnitude < .01f)
                directionArray = staticDirections;
            else
            {
                directionArray = runDirections;
                lastDirection = DirectionToIndex(direction, 8);
            }

            animator.Play(directionArray[lastDirection]);
        }
        public static int DirectionToIndex(Vector2 dir, int sliceCount)
        {
            Vector2 normDir = dir.normalized;
            float step = 360f / sliceCount;
            float halfstep = step / 2;
            float angle = Vector2.SignedAngle(Vector2.up, normDir);
            angle += halfstep;
            if (angle < 0)
            {
                angle += 360;
            }
            float stepCount = angle / step;

            return Mathf.FloorToInt(stepCount);
        }
    }
}