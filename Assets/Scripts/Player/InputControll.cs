using UnityEngine;

namespace Journey
{
    public class InputControll : MonoBehaviour
    {
        [SerializeField] private Ñreature ñreature;

        private float verticalAxis;
        private float horizontalAxis;

        private void Update()
        {
            UpdateAxis();
            UpdateDirection();
        }

        private void UpdateAxis()
        {
            verticalAxis = Input.GetAxis("Vertical");
            horizontalAxis = Input.GetAxis("Horizontal");
        }

        private void UpdateDirection()
        {
            ñreature.SetDirection(horizontalAxis, verticalAxis);
        }
    }
}

