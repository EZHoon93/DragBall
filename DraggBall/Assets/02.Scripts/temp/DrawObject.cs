using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawObject : MonoBehaviour
{
    private LineRenderer line;

    private BoxCollider2D boxCol;

    private Vector2 EndPos;

    public GameObject[] brush;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        boxCol = GetComponent<BoxCollider2D>();

    }

    public void DrawLine_Start(Vector2 start_pos)
    {
        boxCol.enabled = false;
        line.SetPosition(0, start_pos);

    }

    public void DrawLine_End(Vector2 start_pos, Vector2 end_pos)
    {
        float distance = Vector2.Distance(start_pos, end_pos);
        if (distance < 1)
        {
            EndPos = end_pos;
        }
        else
        {
            end_pos = EndPos;
        }

        //  Debug.Log("startPos : " + start_pos + "end Pos : " + end_pos);
        
        boxCol.transform.position = start_pos + (end_pos - start_pos) / 2;
        float radian = Mathf.Atan2(end_pos.y - start_pos.y, end_pos.x - start_pos.x);

        float angle = (360 * radian) / (2 * Mathf.PI);

        //float _radian = (myQuat.eulerAngles.z * 2 * Mathf.PI) / 360;

        //boxCol.size = new Vector2(Mathf.Abs(start_pos.x - end_pos.x), Mathf.Abs(start_pos.y - end_pos.y));

        float box_Size = Mathf.Abs(start_pos.x - end_pos.x) > Mathf.Abs(start_pos.y - end_pos.y) ? Mathf.Abs(start_pos.x - end_pos.x) : Mathf.Abs(start_pos.y - end_pos.y);

        boxCol.size = new Vector2(box_Size, 0.3f);
        boxCol.transform.eulerAngles = new Vector3(0, 0, angle);
        line.SetPosition(1, end_pos);
        Time.timeScale = 0.00f;
    }

    public void CreateLine()
    {
        boxCol.enabled = true;
        Time.timeScale = 1f;

    }

    public void Delete_Line()
    {
        boxCol.transform.position = Vector3.zero;
        boxCol.size = new Vector2(0.0f, 0.0f);
        boxCol.transform.eulerAngles = new Vector3(0, 0, 0);
        line.SetPosition(0, Vector2.zero);
        line.SetPosition(1, Vector2.zero);

    }


}
