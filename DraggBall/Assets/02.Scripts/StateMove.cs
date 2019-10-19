using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StateMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
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
        //Debug.Log("State Move Down");
        _settingTool.toolState = ToolState.MOVE;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("State Move Drag");

    }
    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("State Move Up");
        _settingTool.toolState = ToolState.WAIT;

    }
}
