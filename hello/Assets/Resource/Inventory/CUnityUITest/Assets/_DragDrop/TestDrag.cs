using System.Collections;
using System.Collections.Generic;

using UnityEngine;

// 2D Object / Sprite 생성 후 Box Collider 추가해야 한다.

// 2D Object 없다면
//      창 > 패키지 관리자 >  Unity 레지스트리 선택
//      2D Sprite를 검색하고 '2D Sprite'라는 패키지를 선택

public class TestDrag : MonoBehaviour 
{
    public LineRenderer line;

    float camera_distance = 10; //Camera.main z위치
    
    private Vector3 mousePos;
    public Vector3 startPos;
    public Vector3 endPos;

    public int index_max = 2;
    public int index_cur = 0;
    
    public Vector3[] indexPos =  new Vector3[10];

    void OnMouseDrag() {
        print("OnMouseDrag");
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera_distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;

        if (line == null) return;        
        int indexnext = index_cur + 1; if (indexnext >= index_max) indexnext = index_max-1;
        indexPos[indexnext] = objPosition;

        line.SetPosition(0, startPos);
        line.SetPosition(1, objPosition);

        //for (int i = 0; i < index_max; i++) {
        //    line.SetPosition(i, indexPos[i]);
        //}

    }

    void OnMouseDown() {
        print("OnMouseDown");

        if (line == null) createLine();
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        startPos = Camera.main.ScreenToWorldPoint(mousePosition); startPos.z = 0;
        line.SetPosition(index_cur, startPos);
    }

    void OnMouseUp() { print("OnMouseUp"); }
    void OnMouseEnter() { print("OnMouseEnter");    }
    void OnMouseExit()  { print("OnMouseExit");    }



    // Following method creates line runtime using Line Renderer component
    
    private void createLine() {
        //line = new GameObject("Line").AddComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Diffuse"));
        line.positionCount = 10;
        line.startWidth = 0.1f;
        line.startColor = Color.white;
        line.useWorldSpace = true;
    }
}

/*
    OnMouseEnter
    OnMouseExit
    OnMouseUp
    OnMouseDown
*/

/*

//드래그하는 오브젝트에는 다음의 세 가지 인터페이스를 구현한다.  
//      드래그가 시작할 때, 드래그 중일 때, 드래그가 종료되면 발생하는 인터페이스이다.  

    using UnityEngine;
    using UnityEngine.EventSystems;

    public class DragExample : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("Start");
            //throw new System.NotImplementedException();
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("Draging");
            //throw new System.NotImplementedException();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("EndDrag");
            // throw new System.NotImplementedException();
        }
    }

//드롭이 발생하는 오브젝트에는 다음의 인터페이스를 구현한다. 

    using UnityEngine;
    using UnityEngine.EventSystems;

    public class DropExample : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("Drop")
            // throw new System.NotImplementedException();
        }
    }
 
// DragAndDropExample full script --------------------------

    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;

    public class DragAndDropExample : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler,IDropHandler
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
            else
            {
                dragAndDropContainer.image.sprite = null;
            }
        }
    }

//DragAndDropContainer --------------------------------------

    using UnityEngine;
    using UnityEngine.UI;

    public class DragAndDropContainer : MonoBehaviour
    {
        public Image image;
        // public MyData data;
    
        // Start is called before the first frame update
        void Start()
        {
            gameObject.SetActive(false);
        }
    }
 
※ 컨테이너를 만들고, 컨테이너의 이미지의 Raycast Target 속성을 해제(√ 해제)한다. 
  이는 컨테이너의 이미지에 의해 슬롯이 가려져 마우스 이벤트를 막게 되는 결과를 만든다. 
  Raycast Target 속성을 해제하지 않으면, Drop 이벤트가 발생하지 않는다. 
*/