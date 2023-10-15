using UnityEngine;

namespace Journey
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private float speed;

        private Vector3 target;
        private float zPosition;

        private void Awake()
        {
            zPosition = transform.position.z;
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

