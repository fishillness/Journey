using UnityEngine;
using UnityEngine.Events;

namespace Journey
{
    public class InputControll : MonoBehaviour
    {
        public static event UnityAction OnPressedInteractKey;
        public static event UnityAction OnPressedPause;

        [SerializeField] private Player player;

        private float verticalAxis;
        private float horizontalAxis;

        private void Update()
        {
            UpdateAxis();
            UpdateDirection();
            CheckKeyDowm();
        }

        private void UpdateAxis()
        {
            verticalAxis = Input.GetAxis("Vertical");
            horizontalAxis = Input.GetAxis("Horizontal");
        }

        private void UpdateDirection()
        {
            player.SetDirection(horizontalAxis, verticalAxis);
        }

        private void CheckKeyDowm()
        {
            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                player.Fire();
            }

            if (Input.GetKeyDown(KeyCode.E) == true)
            {
                OnPressedInteractKey?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Escape) == true)
            {
                OnPressedPause?.Invoke();
            }
        }

    }
}

