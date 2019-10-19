using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StateRotate : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

    private SettingTool _settingTool;
    public ToolState toolSate;

    private void Awake()
    {
        _settingTool = GetComponentInParent<SettingTool>();
        toolSate = GetComponentInParent<SettingTool>().toolState;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("State Rotate Down");
        _settingTool.toolState = ToolState.ROTATE;
        _settingTool.startPos = Camera.main.ScreenToWorldPoint(eventData.position);

    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("State Rotate Drag");

    }
    public void OnPointerUp(PointerEventData eventData)
    {
        _settingTool.toolState = ToolState.WAIT;

    }
}
