using UnityEngine.Events;

namespace Journey
{
    public class Portal : TriggerCollider
    {
        public static event UnityAction OnCompletedLevel;

        private void Start()
        {
            InputControll.OnPressedInteractKey += OnPressedInteractKey;
        }

        private void OnDestroy()
        {
            InputControll.OnPressedInteractKey -= OnPressedInteractKey;
        }

        private void OnPressedInteractKey()
        {
            if (IsPlayerEnter)
            {
                OnCompletedLevel?.Invoke();
            }
        }
    }
}
