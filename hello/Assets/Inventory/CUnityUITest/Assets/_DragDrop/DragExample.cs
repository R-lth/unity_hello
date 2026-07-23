using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// 오브젝트 드래그 이동, 2D, 충돌필요 없음

public class DragExample : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("DragStart");
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Draging");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("DragEnd");
    }

    //EventTrigger 컴포넌트를 등록하고 사용하기
    public void Drag()
    {
        Debug.Log("Drag");
    }
}
