using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingTool : MonoBehaviour  
{
    public ToolState toolState;
    public Vector2 startPos;

    public Image rotateImage;

    public Button OkButton;
    public Button RemoveButton;

    public Transform pivot;
    public Transform canvas; 

    private Collider2D[] collider2Ds;



    private void Awake()
    {
        collider2Ds = GetComponentsInChildren<Collider2D>();
        foreach (var coll in collider2Ds)
        {
            coll.enabled = false;
        }

        if(pivot == null)
        {
            pivot = transform.FindChild("Pivot").transform;
            
        }

        if (canvas == null)
        {
            canvas = gameObject.transform.FindChild("Canvas");
        }

    }

    public void ClcikOkButton()
    {
        //OK버튼 클릭시 상태전환 및 활성화, 스크립트활성화..?
        toolState = ToolState.OK;
        ToolManager2.instance.currentControlTool = null;
        foreach (var coll in collider2Ds)
        {
            coll.enabled = true;
        }
        //타임 스케일을 돌린다
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

        void Update()
    {
        if (toolState == ToolState.OK) return;

        //드래그중이면 슬로우모션.
        Time.timeScale = 0.1f;
        //그게 아닐시.
        if(toolState == ToolState.WAIT)
        {

        }

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (toolState == ToolState.MOVE)
        {
            this.transform.position = pos;
        }
        else if(toolState == ToolState.ROTATE)
        {
            float radian = Mathf.Atan2(pos.y - startPos.y, pos.x - startPos.x);

            float angle = (360 * radian) / (2 * Mathf.PI);

            pivot.transform.eulerAngles = new Vector3(0, 0, angle - 90);

            

        }

    }
}
