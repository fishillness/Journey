using UnityEngine.Events;

namespace Journey
{
    public class Portal : TriggerColliderInteracted
    {
        public static event UnityAction OnCompletedLevel;

        protected override void ActionUponInteraction()
        {
            OnCompletedLevel?.Invoke();
        }
    }
}
