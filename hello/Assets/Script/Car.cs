using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.InputSystem;

public class Car : MonoBehaviour
{
    [SerializeField]
    float speed = 2f;

    Rigidbody rb;
    Vector3 dir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        gameObject.transform.position = Vector3.zero;
        gameObject.transform.rotation = Quaternion.identity;
        //gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnMove(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();

        // 2. 받아온 2D 입력값을 3D 공간의 방향(X축과 Z축)으로 재조립합니다.
        dir = new Vector3(inputVector.x, 0f, inputVector.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (dir.sqrMagnitude > 0) { dir.Normalize(); } // 대각선 움직임 처리

        Vector3 move = dir * Time.deltaTime * speed;
        rb.MovePosition(rb.position + move);
    }
}
