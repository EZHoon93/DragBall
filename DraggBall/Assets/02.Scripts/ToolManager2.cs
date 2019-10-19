using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager2 : MonoBehaviour
{
    public List<SettingTool> tools  = new List<SettingTool>();
    public SettingTool currentControlTool = null; 
    public static ToolManager2 instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<ToolManager2>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }

    private static ToolManager2 m_instance; // 싱글톤이 할당될 static 변수

    private void Awake()
    {
        // 씬에 싱글톤 오브젝트가 된 다른 GameManager 오브젝트가 있다면
        if (instance != this)
        {
            // 자신을 파괴
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GameManager.Instance.reStart += DestroyTools;

    }

    //생성된 모든 도구들을 없앤다. 
    private void DestroyTools()
    {
        foreach(var tool in GameObject.FindGameObjectsWithTag("Tool") ){
            Destroy(tool);
        }
    }
}
