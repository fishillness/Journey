using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Journey
{
    public class Bot : Creature, IDependency<Player>
    {
        [SerializeField] private Transform[] patrolPoint;
        [SerializeField] private float timeWhenIsStillVisible = 5;
        //[SerializeField] private float visibilityDistance = 1.5f;

        private Player player;
        private NavMeshAgent agent;
        private BotTriggerCollider triggerCollider;
        private int currentPatrolPointIndex;
        [Header("DEBUG")]
        [SerializeField] private bool isFollowingPlayer = false;
        private float deviationDistanceToPoint = 0.1f;

        public void Construct(Player obj) => player = obj;

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

        private new void FixedUpdate()
        {
            ChooseBehaviour();
        }

        private void ChooseBehaviour()
        {
            TrySeePlayer();

            if (!isFollowingPlayer)
                Move(); //Patrolling

            if (isFollowingPlayer)
                FollowingPlayer();

            CalculateDirection();
            UpdateAnimator(direction);
            MoveTriggerCollider();
        }
        
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
            if (!isFollowingPlayer)
            {
                direction = new Vector2(patrolPoint[currentPatrolPointIndex].position.x - transform.position.x,
                    patrolPoint[currentPatrolPointIndex].position.y - transform.position.y);
            }
            else
            {
                direction = new Vector2(player.transform.position.x - transform.position.x,
                    player.transform.position.y - transform.position.y);
            }
            
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
                    StartCoroutine(Wait());
                }
            }
        }

        private void FollowingPlayer()
        {
            agent.SetDestination(player.transform.position);
        }

        private IEnumerator Wait()
        {
            yield return new WaitForSeconds(timeWhenIsStillVisible);
            isFollowingPlayer = false;
        }
    }
}