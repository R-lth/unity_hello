using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDropContainer : MonoBehaviour
{
    public Image image;         //Raycast Target 체크 끄기

    // public MyData data;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }
}
