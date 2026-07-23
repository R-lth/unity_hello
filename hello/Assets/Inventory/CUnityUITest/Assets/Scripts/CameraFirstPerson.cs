using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFirstPerson : MonoBehaviour
{
    public Camera playerCamera;  // player / joint / camera

    public bool cameraCanMove = true;
    public float fov = 60f;
    public bool invertCamera = false;    
    public float mouseSensitivity = 4f;
    public float maxLookAngle = 50f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    //float movespin = 90.0f;
    float movespeed = 2.0f;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
     
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // camera 
        yaw = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity * 2f;
        
        if (!invertCamera)  pitch -= mouseSensitivity * Input.GetAxis("Mouse Y");
        else                pitch += mouseSensitivity * Input.GetAxis("Mouse Y");        
        pitch = Mathf.Clamp(pitch, -maxLookAngle, maxLookAngle); // Clamp pitch between lookAngle

        transform.localEulerAngles = new Vector3(0, yaw, 0);        // 마우스로 좌우 회전
        playerCamera.transform.localEulerAngles = new Vector3(pitch, 0, 0);

        // player move
        Move();
    }

    void Move()
    {
        //if (Input.GetKey(KeyCode.RightArrow)) { transform.Rotate(new Vector3(0, movespin, 0) * Time.deltaTime); }
        //if (Input.GetKey(KeyCode.LeftArrow)) { transform.Rotate(new Vector3(0, -movespin, 0) * Time.deltaTime); }
        //if (Input.GetKey(KeyCode.RightArrow)) { transform.Translate(transform.right * movespeed * Time.deltaTime, Space.World); }
        //if (Input.GetKey(KeyCode.LeftArrow)) { transform.Translate(transform.right * -movespeed * Time.deltaTime, Space.World); }
        //if (Input.GetKey(KeyCode.UpArrow)) { transform.Translate(transform.forward * movespeed * Time.deltaTime, Space.World); }
        //if (Input.GetKey(KeyCode.DownArrow)) { transform.Translate(transform.forward * -movespeed * Time.deltaTime, Space.World); }

        // Rigidbody 이동
        Vector3 pos = transform.position;
        if (Input.GetKey(KeyCode.RightArrow)) { pos = rb.position + transform.right * movespeed * Time.deltaTime; }
        if (Input.GetKey(KeyCode.LeftArrow)) { pos = rb.position + transform.right * -movespeed * Time.deltaTime; }
        if (Input.GetKey(KeyCode.UpArrow)) { pos = rb.position + transform.forward * movespeed * Time.deltaTime; }
        if (Input.GetKey(KeyCode.DownArrow)) { pos = rb.position + transform.forward * -movespeed * Time.deltaTime; }
        rb.MovePosition(pos);
    }
}
