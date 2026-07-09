using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.InputSystem;

public class Car : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 2f;
    [SerializeField]
    float rotateSpeed = 2f;

    Rigidbody rb;
    float turn = 0f;
    Vector3 keyboardMove;
    Vector2 mouseDelta;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        gameObject.transform.position = Vector3.zero;
        gameObject.transform.rotation = Quaternion.identity;

        turn = transform.eulerAngles.y;
    }

    private void OnMove(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();
        keyboardMove = new Vector3(inputVector.x, 0f, inputVector.y);
    }

    private void OnLook(InputValue value)
    {
        mouseDelta = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        // 키보드 WASD
        if (keyboardMove.sqrMagnitude > 0) { keyboardMove.Normalize(); } // 대각선 움직임 처리

        Vector3 move = keyboardMove * Time.fixedDeltaTime * moveSpeed;
        Vector3 worldMove = rb.rotation * move; // 키보드 입력은 오브젝트의 회전 값이 반영되지 않은 절대적인 월드 기준 방향이기 때문에, 플레이어의 회전 방향에 맞게 월드 방향을 바라보게 해야 함
        rb.MovePosition(rb.position + worldMove); // rb.MovePosition()는 월드 좌표를 입력 받는 함수

        // 마우스 회전
        turn += mouseDelta.x * Time.fixedDeltaTime * rotateSpeed; 
        Quaternion rotate = Quaternion.Euler(0f, turn, 0f); 
        rb.MoveRotation(rotate);
    }
}
