using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary> 화면에 마우스 드래그로 사각형 선택 영역 표시하기 </summary>

public class ScreenDragSelection : MonoBehaviour
{
    private Vector2 mPosCur;        // 실시간(현재 프레임) 마우스 좌표
    private Vector2 mPosBegin;      // 드래그 시작 지점 마우스 좌표
    private Vector2 mPosMin;        // Rect의 최소 지점 좌표
    private Vector2 mPosMax;        // Rect의 최대 지점 좌표
    private bool showSelection = false;

    Rect drag_rect;

    public GameObject unit;

    private void Start()
    {
        print(Screen.height);
    }

    private void Update()
    {
        showSelection = Input.GetMouseButton(0);
        if (Input.GetMouseButtonUp(0)) {

            SelectUnit();

            showSelection = false;
        }
        if (!showSelection) return;

        mPosCur = Input.mousePosition;          //현재위치
        mPosCur.y = Screen.height - mPosCur.y;  //Y 좌표(상하) 반전
        if (Input.GetMouseButtonDown(0))
        {
            mPosBegin = mPosCur;
            showSelection = true;
        }
        mPosMin = Vector2.Min(mPosCur, mPosBegin);
        mPosMax = Vector2.Max(mPosCur, mPosBegin);
    }

    private void OnGUI()
    {
        if (!showSelection) return;
        drag_rect = new Rect();
        drag_rect.min = mPosMin;
        drag_rect.max = mPosMax;

        GUI.Box(drag_rect, "");
    }

    public RectTransform canvasRect;

    void SelectUnit()
    {
        //unit_list check

        Vector3 screenPos = Camera.main.WorldToScreenPoint(unit.transform.position);
        //Vector2 canvasPos = RectTransformUtility.WorldToScreenPoint(Camera.main, unit.transform.position);

        //print(drag_rect.y + "    " + screenPos.y);

        screenPos.y = Screen.height - screenPos.y;

        if ( drag_rect.Contains(screenPos) )
        {
            print("select unit ");  //check unit select
        }

    }
}

//Camera.main.WorldToScreenPoint
//      Transforms position from world space into screen space.
//      The bottom-left of the screen is (0,0)