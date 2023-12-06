using UnityEngine;

namespace Journey
{
    public class CameraFollow : MonoBehaviour, IDependency<Player>
    {
        [SerializeField] private float speed;

        private Player player;
        private Vector3 target;
        private float zPosition;

        public void Construct(Player obj) => player = obj;

        private void Awake()
        {
            zPosition = transform.position.z;
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, zPosition);
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            target = new Vector3(player.transform.position.x, player.transform.position.y, zPosition);
            transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
        }
    }
}

