using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class SelectTool : MonoBehaviour , IBeginDragHandler, IEndDragHandler, IDragHandler,IPointerDownHandler
{
    public SettingTool tool;

    private new Collider2D[] collider2D;



    public void OnBeginDrag(PointerEventData eventData)
    {
        //ToolsManager.Instacne.currentSelectTool = tool;
        if (ToolManager2.instance.currentControlTool != null)
        {
            Debug.Log("존재");
            return;
        }
        //선택된 툴 클릭시 툴을 마우스위치 생성.
        Vector2 pos = Camera.main.ScreenToWorldPoint(eventData.position);
        //매니저에 생성한 도구 갯수 추가. 추후 없애기위함.
        //ToolManager2.instance.tools.Add(tool);
        ToolManager2.instance.currentControlTool = Instantiate(tool, pos, Quaternion.identity);
        //count --
        //이동모드로 전환
        //createTool.toolState = ToolState.MOVE;
        ToolManager2.instance.currentControlTool.toolState = ToolState.MOVE;
        
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    //드래그 끝날시.
    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 pos = Camera.main.WorldToScreenPoint(ToolManager2.instance.currentControlTool.transform.position);
        if(pos.y <= 200)
        {
            Destroy(ToolManager2.instance.currentControlTool.gameObject);
            ToolManager2.instance.currentControlTool = null;
            return;
        }

        ToolManager2.instance.currentControlTool.toolState = ToolState.WAIT;

        //createTool.toolState = ToolState.WAIT;

        //createTool.tr
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       
        
    }
}
