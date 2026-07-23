using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Splines;

public class Zombie : MonoBehaviour
{
    [SerializeField] private float attackRange = 3f; 

    private Transform playerTransform;
    private NavMeshAgent agent;
    private Animator animator;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            playerTransform = player.transform;
        }

        animator.SetBool("IsRun", true);
    }

    void Update()
    {
        if (playerTransform == null) return;

        float distance = Vector3.Distance(transform.position, playerTransform.position);

        // 현재 실제 거리와 IsRun 상태를 실시간 출력합니다.
        Debug.Log($"거리: {distance:F2} | IsRun: {animator.GetBool("IsRun")}");

        if (distance <= attackRange)
        {
            agent.speed = 1;
            animator.SetBool("IsRun", false);
        }
        else
        {
            agent.speed = 5;
            agent.SetDestination(playerTransform.position);
            animator.SetBool("IsRun", true);
        }
    }
}
