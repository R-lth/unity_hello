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

    //void Update()
    //{
    //    if (playerTransform != null)
    //    {
    //        agent.SetDestination(playerTransform.position);
    //    }

    //    // 플레이어와의 거리 계산
    //    float distance = Vector3.Distance(transform.position, playerTransform.position);

    //    if (distance <= attackRange)
    //    {
    //        // 가까워지면 정지하고 걷기(혹은 대기) 모드로
    //        agent.isStopped = true; // agent.speed = 0f 대신 사용하는 유니티 권장 기능입니다.
    //        animator.SetBool("IsRun", false);
    //    }
    //    else
    //    {
    //        // 멀어지면 다시 추적 및 달리기
    //        agent.isStopped = false;
    //        agent.speed = runSpeed;
    //        agent.SetDestination(playerTransform.position);
    //        animator.SetBool("IsRun", true);
    //    }
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (!other.CompareTag("Player")) { return; }
    //    agent.speed = 0f;
    //    animator.SetBool("IsRun", false);
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (!other.CompareTag("Player")) { return; }
    //    agent.speed = 5f;
    //    animator.SetBool("IsRun", true);
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (!collision.gameObject.CompareTag("Player")) { return; }

    //    agent.speed = 0f;
    //    animator.SetBool("IsRun", false);

    //    Debug.Log("Walk");
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (!collision.gameObject.CompareTag("Player")) { return; }

    //    agent.speed = 5f;
    //    animator.SetBool("IsRun", true);

    //    Debug.Log("Run");
    //}
}
