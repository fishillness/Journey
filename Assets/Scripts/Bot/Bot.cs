using UnityEngine;
using UnityEngine.AI;

namespace Journey
{
    public class Bot : MonoBehaviour
    {

        [SerializeField] private Player player;
        [SerializeField] private Transform[] patrolPoint;

        private NavMeshAgent agent;
        private int currentPatrolPointIndex;
        private bool isFollowingPlayer = false;

        private float deviationDistanceToPoint = 0.1f;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;

            agent.SetDestination(patrolPoint[currentPatrolPointIndex].position);
        }

        private void Update()
        {
            Patrolling();
        }

        private void Patrolling()
        {
            if (!agent.pathPending && agent.remainingDistance < deviationDistanceToPoint)
            {
                currentPatrolPointIndex++;

                if (currentPatrolPointIndex >= patrolPoint.Length)
                    currentPatrolPointIndex = 0;

                agent.SetDestination(patrolPoint[currentPatrolPointIndex].position);
            }
        }
    }
}