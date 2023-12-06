using UnityEngine;
using UnityEngine.Events;

namespace Journey
{
    public class Portal : TriggerColliderInteracted, IDependency<SoundPlayer>
    {
        public static event UnityAction OnCompletedLevel;

        [SerializeField] private SoundType soundType;

        private SoundPlayer soundPlayer;

        public void Construct(SoundPlayer obj) => soundPlayer = obj;

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
