using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClcikManger : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    DrawObject drawObject;

   

    // Start is called before the first frame update
    Vector2 start_pos;
    Vector2 end_pos;

    private void Awake()
    {
        drawObject = FindObjectOfType<DrawObject>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        start_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Debug.Log("드래그 시작" + eventData.worldPosition);
        drawObject.DrawLine_Start(start_pos);
        //start_pos = eventData.position;

    }

    public void OnDrag(PointerEventData data)
    {

        end_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log("드래그 " + data.position);
        drawObject.DrawLine_End(start_pos, end_pos);

    }





    public void OnEndDrag(PointerEventData eventData)
    {
        drawObject.CreateLine();
        //Debug.Log("드래그 끝");

    }
}

