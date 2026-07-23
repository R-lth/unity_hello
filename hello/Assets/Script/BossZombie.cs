using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class BossZombie : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform playerTransform;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Attack")]
    [SerializeField] private float attackRange = 3f;
    [SerializeField] private float attackCooldown = 1.5f;

    private NavMeshAgent agent;
    private Animator animator;

    private float attackTimer;

    private static readonly int SpeedHash = Animator.StringToHash("MoveSpeed");
    private static readonly int AttackHash = Animator.StringToHash("Attack");

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        if (playerTransform == null)
        {
            GameObject player = GameObject.FindWithTag("Player");

            if (player != null)
            {
                playerTransform = player.transform;
            }
        }

        agent.speed = moveSpeed;
    }

    private void Update()
    {
        if (playerTransform == null) { return; }

        attackTimer += Time.deltaTime;

        float distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance <= attackRange)
        {
            Attack();
        }
        else
        {
            Chase();
        }

        UpdateAnimation();
    }

    private void Chase()
    {
        agent.isStopped = false;
        agent.speed = moveSpeed;
        agent.SetDestination(playerTransform.position);
    }

    private void Attack()
    {
        agent.isStopped = true;

        Vector3 direction = playerTransform.position - transform.position;
        direction.y = 0f;

        if (direction.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }

        // 공격 쿨타임
        if (attackTimer >= attackCooldown)
        {
            attackTimer = 0f;
            animator.SetTrigger(AttackHash);
        }
    }

    private void UpdateAnimation()
    {
        // Blend Tree 제어

        float speed = 0f;

        if (!agent.isStopped && agent.speed > 0f)
        {
            speed = agent.velocity.magnitude / agent.speed;
        }

        speed = Mathf.Clamp01(speed);

        animator.SetFloat(SpeedHash, speed, 0.1f, Time.deltaTime);
    }
}
