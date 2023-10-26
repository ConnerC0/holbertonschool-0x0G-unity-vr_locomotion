using UnityEngine;
using UnityEngine.AI;

public class ZombieAINavigation : MonoBehaviour
{
    public Transform player;
    public float aggroRange = 10f;
    public float attackRange = 3f;
    public int damage = 1;
    public float attackCooldown = 1f;

    private NavMeshAgent agent;
    private PlayerHealth playerHealth;
    private float attackTimer;
    public StatTracker statTracker;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= aggroRange)
        {
            agent.SetDestination(player.position);
        }

        if (distanceToPlayer <= attackRange)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackCooldown)
            {
                playerHealth.TakeDamage(damage);
                attackTimer = 0f;
            }
        }
        else
        {
            attackTimer = 0f;
        }
    }

    private void OnDestroy()
    {
        if (statTracker != null)
        {
            statTracker.IncrementZombieKill();
        }
    }
}
