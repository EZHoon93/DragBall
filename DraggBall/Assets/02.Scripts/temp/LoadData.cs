using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;

public class LoadData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //해당 스테이지에 있는 데이터 들을 갖고온다.
        var stageData = Resources.LoadAll<StageData>("StageData/").OrderBy(s =>s.stage);

        foreach(var stage in stageData)
        {
            Debug.Log(stage.stage);
        }
        
        
    }
    private void OnEnable()
    {
        Debug.Log(this.transform.right);
    }

    public void clickTest()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
    }

    
}
