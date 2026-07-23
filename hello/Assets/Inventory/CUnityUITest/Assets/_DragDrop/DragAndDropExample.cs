//드래그할 대상에 추가할 스크립트

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDropExample : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    public Image data;
    public DragAndDropContainer dragAndDropContainer;

    bool isDragging = false;

    // 드래그 오브젝트에서 발생
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (data.sprite == null)
        {
            return;
        }

        // Activate Container
        dragAndDropContainer.gameObject.SetActive(true);
        // Set Data 
        dragAndDropContainer.image.sprite = data.sprite;
        isDragging = true;
    }
    // 드래그 오브젝트에서 발생
    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            dragAndDropContainer.transform.position = eventData.position;
        }
    }
    // 드래그 오브젝트에서 발생
    public void OnEndDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            if (dragAndDropContainer.image.sprite != null)
            {
                // set data from dropped object  
                data.sprite = dragAndDropContainer.image.sprite;
            }
            else
            {
                // Clear Data
                data.sprite = null;
            }
        }

        isDragging = false;
        // Reset Contatiner
        dragAndDropContainer.image.sprite = null;
        dragAndDropContainer.gameObject.SetActive(false);
    }

    // 드롭 오브젝트에서 발생
    public void OnDrop(PointerEventData eventData)
    {
        if (dragAndDropContainer.image.sprite != null)
        {
            // keep data instance for swap 
            Sprite tempSprite = data.sprite;

            // set data from drag object on Container
            data.sprite = dragAndDropContainer.image.sprite;

            // put data from drop object to Container.  
            dragAndDropContainer.image.sprite = tempSprite;
        }
    }
}