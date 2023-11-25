using UnityEngine;
using UnityEngine.Events;

namespace Journey
{
    public class Portal : TriggerColliderInteracted
    {
        public static event UnityAction OnCompletedLevel;
        [SerializeField] private SoundPlayer soundPlayer;
        [SerializeField] private SoundType soundType;

        protected override void ActionUponInteraction()
        {
            if (soundPlayer)
            {
                soundPlayer.Play(soundType);
            }

            OnCompletedLevel?.Invoke();
        }
    }
}
