using UnityEngine;
using UnityEngine.AI;

public class enemyFollow : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target; // Player or object to follow

    [Header("Navigation Settings")]
    public float followRange = 15f; // Detection radius
    public float stopDistance = 2f; // Minimum distance to stop moving

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (target == null && GameObject.FindGameObjectWithTag("Player") != null)
        {
            target = FindAnyObjectByType<Player_health>().transform;
        }
    }

    void Update()
    {
        if (target == null) return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= followRange)
        {
            // Follow target until within stop distance
            if (distance > stopDistance)
            {
                agent.isStopped = false;
                agent.SetDestination(target.position);
            }
            else
            {
                // Stop when close enough
                agent.isStopped = true;
            }
        }
        else
        {
            // Idle if out of range
            agent.isStopped = true;
        }
    }
}
