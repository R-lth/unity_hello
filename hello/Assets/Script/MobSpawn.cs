using UnityEngine;
using UnityEngine.AI; // NavMesh 기능을 사용하기 위해 반드시 필요합니다.

public class MobSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject[] monsters;    // 좀비 프리팹 배열

    GameObject Player;
    float timer = 0f;

    void Start() 
    {
        Player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 3f)
        {
            System.Random random = new System.Random();
            Vector3 finalSpawnPos = GetRandomNavMeshPosition();
            Vector3 toPlayer = Player.transform.position - finalSpawnPos; 
            toPlayer.y = 0f;
            Quaternion look = Quaternion.LookRotation(toPlayer);

            Instantiate(monsters[random.Next(0, monsters.Length)], finalSpawnPos, look);

            timer = 0f;
        }
    }

    // AI 길 위에서만 좌표를 찾아주는 함수
    //Vector3 GetRandomNavMeshPosition()
    //{
    //    NavMeshHit hit;
    //    Vector3 randomDir = Player.transform.position + Random.insideUnitSphere * spawnRadius;

    //    if (NavMesh.SamplePosition(randomDir, out hit, spawnRadius, NavMesh.AllAreas))
    //    {
    //        return hit.position;
    //    }

    //    // 운이 없다면
    //    return Player.transform.position;
    //}
    Vector3 GetRandomNavMeshPosition()
    {
        if (Player == null) { return Vector3.zero; }

        NavMeshHit hit;

        Vector3 randomDirection = Random.onUnitSphere;
        randomDirection.y = 0f;
        randomDirection.Normalize(); 

        // 거리 랜덤
        float randomDistance = Random.Range(3f, 10f);


        Vector3 targetPos = Player.transform.position + (randomDirection * randomDistance);

        // 무작위 거리 좌표 근처에서 가장 가까운 AI 길(NavMesh)을 찾습니다.
        if (NavMesh.SamplePosition(targetPos, out hit, 3.0f, NavMesh.AllAreas))
        {
            return hit.position;
        }

        return Vector3.zero;
    }

}




