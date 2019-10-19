using UnityEngine;
using UnityEngine.EventSystems;

public enum ToolState { WAIT, DRAG ,MOVE, ROTATE , OK}

public class ToolsManager : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler ,IPointerDownHandler , IPointerUpHandler
{

    public GameObject tool;
    private LineRenderer line;
    private BoxCollider2D boxCol;
    private Vector2 EndPos;
    Vector2 start_pos;
    Vector2 end_pos;

    public GameObject currentSelectTool;  //현재 클릭된 도구. 

    private GameObject currentCreateTool; //현재 생성된 도구

    private Canvas currentCreateToolCanvas; // 현재 생성된 도구의 캔버스  컴포넌트

    private ToolState toolState;

    #region 싱글톤

    public static ToolsManager Instacne { get; set; }

    #endregion

    private void Awake()
    {
        if( Instacne == null)
        {
            Instacne = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    private void Start()
    {
        //line = GetComponent<LineRenderer>();
        //boxCol = GetComponent<BoxCollider2D>();

    }


    public void SelectThisTool(GameObject tool )
    {
        this.tool = tool;
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        start_pos = Camera.main.ScreenToWorldPoint(eventData.position);

        if (currentSelectTool != null)
        {
            if (currentCreateTool != null) Destroy(currentCreateTool);
            currentCreateTool =  Instantiate(currentSelectTool, start_pos, Quaternion.identity);
            currentCreateTool.GetComponent<BoxCollider2D>().enabled = false;
            currentCreateTool.GetComponent<EdgeCollider2D>().enabled = false;
            currentCreateTool.GetComponentInChildren<Canvas>().enabled = false;

            //슬로우모션
            Time.timeScale = 0.01f;
            //currentCreateToolCanvas.enabled = false;

        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        //2차워 벡터로 받아들인다.
        end_pos = Camera.main.ScreenToWorldPoint(eventData.position);
        //currentCreateTool.transform.position = pos;
        RotateTool(start_pos, end_pos);
    }

    //놓앗을때. 
    public void OnPointerUp(PointerEventData eventData)
    {
        //currentCreateToolCanvas.enabled = true;
        ////ROTATE로 전환 시킨다.
        //toolState = ToolState.ROTATE;

        //콜라이더를 킨다
        currentCreateTool.GetComponent<EdgeCollider2D>().enabled = true;
        currentCreateTool.GetComponent<BoxCollider2D>().enabled = true;

        //슬로우모션을 푼다
        Time.timeScale = 1;


    }
    public void OnBeginDrag(PointerEventData eventData)
    {


    }

 





    public void OnEndDrag(PointerEventData eventData)
    {
   

    }


    public void DrawLine_Start(Vector2 start_pos)
    {
        boxCol.enabled = false;
        line.SetPosition(0, start_pos);

    }

    public void RotateTool(Vector2 starPos, Vector2 endPos)
    {
        float radian = Mathf.Atan2(end_pos.y - start_pos.y, end_pos.x - start_pos.x);

        float angle = (360 * radian) / (2 * Mathf.PI);

        currentCreateTool.transform.eulerAngles = new Vector3(0, 0, angle-90);
        
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
