using UnityEngine;
using UnityEngine.AI;

namespace Journey
{
    public class Bot : Creature
    {
        [SerializeField] private Player player;
        [SerializeField] private Transform[] patrolPoint;
        [SerializeField] private float visibilityDistance;

        private NavMeshAgent agent;
        private int currentPatrolPointIndex;
        private bool isFollowingPlayer = false;

        private float deviationDistanceToPoint = 0.1f;

        protected override void Start()
        {
            base.Start();
            player = GameObject.FindObjectOfType<Player>();

            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;

            agent.SetDestination(patrolPoint[currentPatrolPointIndex].position);
        }

        private void FixedUpdate()
        {
            Move();

            UpdateAnimator(CalculateDirection());
        }

        /*
        private void ChooseBehaviour()
        {

        }
        */

        protected override void Move() //Patrolling
        {
            if (!agent.pathPending && agent.remainingDistance < deviationDistanceToPoint)
            {
                currentPatrolPointIndex++;

                if (currentPatrolPointIndex >= patrolPoint.Length)
                    currentPatrolPointIndex = 0;

                agent.SetDestination(patrolPoint[currentPatrolPointIndex].position);
            }
        }



        private Vector2 CalculateDirection()
        {
            Vector2 direction = new Vector2(patrolPoint[currentPatrolPointIndex].position.x - transform.position.x,
                patrolPoint[currentPatrolPointIndex].position.y - transform.position.y);
            direction = Vector2.ClampMagnitude(direction, 1);

            return direction;
            //animatorController.SetDirection(direction);
        }


    }
}
