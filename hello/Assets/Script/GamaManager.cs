using UnityEngine;

// AI와 함께 하는 유니티 수업
// ChatGPT로 간단한 GameManager 코드 생성하기

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("중복된 GameManager가 발견되어 파괴되었습니다.");
            Destroy(gameObject);
        }
    }
}