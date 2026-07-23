using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//3d 오브젝트 드래그 이동 //콜라이더 필요함

public class Drag : MonoBehaviour
{
    float distance = 10;

    void OnMouseDrag()
    {
        print("Drag!!");
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }
}
