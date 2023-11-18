using UnityEngine;
using UnityEngine.AI;

namespace Journey
{
    public class Bot : Creature
    {
        [SerializeField] private Player player;
        [SerializeField] private Transform[] patrolPoint;
        //[SerializeField] private float visibilityDistance = 1.5f;

        private NavMeshAgent agent;
        private BotTriggerCollider triggerCollider;
        private int currentPatrolPointIndex;
        [Header("DEBUG")]
        [SerializeField] private bool isFollowingPlayer = false;

        private float deviationDistanceToPoint = 0.1f;

        protected override void Start()
        {
            base.Start();
            player = GameObject.FindObjectOfType<Player>();
            triggerCollider = GetComponentInChildren<BotTriggerCollider>();

            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;

            agent.SetDestination(patrolPoint[currentPatrolPointIndex].position);
        }

        private void FixedUpdate()
        {
            Move(); //Patrolling

            CalculateDirection();
            UpdateAnimator(direction);

            MoveTriggerCollider();

            TrySeePlayer();
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

        private void CalculateDirection()
        {
            direction = new Vector2(patrolPoint[currentPatrolPointIndex].position.x - transform.position.x,
                patrolPoint[currentPatrolPointIndex].position.y - transform.position.y);
            direction = Vector2.ClampMagnitude(direction, 1);
        }

        private void MoveTriggerCollider()
        {
            triggerCollider.Move(transform.position, direction);
        }

        private void TrySeePlayer()
        {
            if (!triggerCollider.IsPlayerEnter) return;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position);

            if (hit.collider)
            {
                if (hit.collider.CompareTag("Player"))
                {
                    isFollowingPlayer = true;
                }
                else
                {
                    isFollowingPlayer = false;
                }
            }
        }
    }
}
