using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDragTarget : MonoBehaviour
{
    public TestDrag     drag;
    public LineRenderer line;
    public int index;

    void Start()
    {        
    }

    void Update()
    {
        
    }

    void OnMouseEnter() {
        //Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(mousePosition); mousePos.z = 0;        
        //line.SetPosition(index, mousePos);
        
    }
    void OnMouseDown() {
        print("OnMouseDown");
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 startPos = Camera.main.ScreenToWorldPoint(mousePosition); startPos.z = 0;
        line.SetPosition(index, startPos);
    }
}
