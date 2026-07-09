using UnityEngine;
using UnityEngine.AI; // NavMesh 기능을 사용하기 위해 반드시 필요합니다.

public class MobSpawn : MonoBehaviour
{
    public Transform spawnPos;       // 스폰 중심 기준점 
    public GameObject[] monsters;    // 좀비 프리팹 배열

    [SerializeField] 
    float spawnRadius = 3f;

    float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 3f)
        {
            System.Random random = new System.Random();
            Vector3 finalSpawnPos = GetRandomNavMeshPosition();
            Instantiate(monsters[random.Next(0, monsters.Length)], finalSpawnPos, spawnPos.rotation);

            timer = 0f;
        }
    }

    // AI 길 위에서만 좌표를 찾아주는 함수
    Vector3 GetRandomNavMeshPosition()
    {
        NavMeshHit hit;
        Vector3 randomDir = Random.insideUnitSphere * spawnRadius;

        if (NavMesh.SamplePosition(randomDir, out hit, spawnRadius, NavMesh.AllAreas))
        {
            return hit.position;
        }

        // 운이 없다면
        return spawnPos.position;
    }
}




