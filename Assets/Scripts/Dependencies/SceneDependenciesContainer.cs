using UnityEngine;

namespace Journey
{
    public class SceneDependenciesContainer : Dependency
    {
        [SerializeField] private Player player;
        [SerializeField] private InputControll inputControll;
        [SerializeField] private CameraFollow cameraFollow;
        [SerializeField] private InventoryManager inventoryManager;
        [SerializeField] private SoundPlayer soundPlayer;
        [SerializeField] private MusicPlayer musicPlayer;

        private void Awake()
        {
            FindAllObjectToBind();
        }

        protected override void BindAll(MonoBehaviour monoBehaviourInScene)
        {
            Bind<Player>(player, monoBehaviourInScene);
            Bind<InputControll>(inputControll, monoBehaviourInScene);
            Bind<CameraFollow>(cameraFollow, monoBehaviourInScene);
            Bind<InventoryManager>(inventoryManager, monoBehaviourInScene);
            Bind<SoundPlayer>(soundPlayer, monoBehaviourInScene);
            Bind<MusicPlayer>(musicPlayer, monoBehaviourInScene);
        }
    }
}
