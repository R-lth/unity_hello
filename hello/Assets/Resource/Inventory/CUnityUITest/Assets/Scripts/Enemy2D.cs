using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2D : MonoBehaviour
{
    public int rotateSpeed;
    public Transform target;

    void Start()
    {
        rotateSpeed = 90;
    }
     
    void Update()
    {
        if (target != null)
        {
            Vector2 direction = new Vector2(
                transform.position.x - target.position.x,
                transform.position.y - target.position.y
            );

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //print(angle);
            Quaternion angleAxis = Quaternion.AngleAxis(angle+90, Vector3.forward);  //Y축이 앞
            Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, rotateSpeed * Time.deltaTime);
            transform.rotation = rotation;
        }
    }
}
