using UnityEngine;

namespace Journey
{
    public class TriggerColliderInteracted : TriggerCollider
    {
        protected virtual void Start()
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
                ActionUponInteraction();
            }
        }

        protected virtual void ActionUponInteraction() {}
    }
}


