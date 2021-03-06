using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    NavMeshAgent agent;
    [SerializeField] Transform enemyPoint;
    [SerializeField] float wanderRadius;

    [SerializeField] Animator animator;

    public void StopMoving()
    {
        agent.isStopped = true;
    }

    public void ContinueMoving()
    {

        agent.isStopped = false;
    }

    private void Awake()
    {
       
        agent = GetComponent<NavMeshAgent>();
    }

    Vector3 GetRandomPoint(Vector3 center, float maxDistance)
    {
        // Get Random Point inside Sphere which position is center, radius is maxDistance
        Vector3 randomPos = Random.insideUnitSphere * maxDistance + center;

        NavMeshHit hit; // NavMesh Sampling Info Container

        // from randomPos find a nearest point on NavMesh surface in range of maxDistance
        NavMesh.SamplePosition(randomPos, out hit, maxDistance, NavMesh.AllAreas);

        return hit.position;
    }
    private void Start()
    {
        InvokeRepeating("Move", 1f, 5f);
    }

    void Move()
    {
        
        if(NavMesh.SamplePosition(GetRandomPoint(enemyPoint.position, wanderRadius), out NavMeshHit randomPosition, 0.1f, NavMesh.AllAreas))
        {
            agent.SetDestination(randomPosition.position);
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.color = new Color(Gizmos.color.r, Gizmos.color.g, Gizmos.color.b, 0.2f);
        Gizmos.DrawSphere(enemyPoint.position, wanderRadius);
    }

    private void Update()
    {
        if(!agent.isStopped)
        {
            if (agent.remainingDistance <= agent.stoppingDistance )
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    animator.SetBool("Walking", false);
                    animator.SetBool("Idle", true);
                }
            }
            else
            {
                animator.SetBool("Idle", false);
                animator.SetBool("Walking", true);
            }
        }
        else
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Walking", true);
        }
        
    }
}
