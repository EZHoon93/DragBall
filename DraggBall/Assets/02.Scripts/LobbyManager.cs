using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class LobbyManager : MonoBehaviour
{

    public GameObject mainHome;
    public GameObject levels;
    public GameObject stages;


    public GameObject stageContent;

    public Stage buttonPrefab; //동적 생성을위한 버튼 프리팹


    private List<GameObject> arrayUI = new List<GameObject>();
    Stack<GameObject> stackUI = new Stack<GameObject>();


    private void Start()
    {
        arrayUI.Add(mainHome);
        arrayUI.Add(levels);
        arrayUI.Add(stages);
    }

    //모든 UI를 끈다.
    private void SetOffUI()
    {
        foreach(GameObject obj in arrayUI)
        {
            obj.SetActive(false);
        }
    }
    //메인 -> 레벨메뉴 로 가는 버튼클릭시 
    public void ClickMainPlayButton()
    {
        //뒤로가기버튼을 위해.
        stackUI.Push(mainHome);
        //모든UI를끈다
        SetOffUI();
        //선택된UI만 킨다.
        levels.SetActive(true);
    }
    
    //뒤로 가기 버튼
    public void ClickBackButton()
    {
        if (stackUI.Count == 0) return;
        //모든 UI를 끈다.
        SetOffUI();
        stackUI.Pop().SetActive(true);
    }

    //클릭한 레벨의 스테이지데이터를 갖고온다.
    public void clickTest()
    {
        //뒤로가기버튼을 위해.
        stackUI.Push(levels);
        //모든UI를끈다
        SetOffUI();
        //선택된UI만 킨다.
        stages.gameObject.SetActive(true);

        //레벨버튼의 있는 레벨데이터를 갖고온다
        int level = EventSystem.current.currentSelectedGameObject.GetComponent<LevelData>().level;
        //스테이지 정보를 업데이트해서 갖고온다.
        StageListUpdate(level);
    }

    //받아온 레벨정보의 폴더에있는 스테이지들을 동적 버튼으로 생성한다.
    private void StageListUpdate(int _level)
    {
    
        foreach(Stage obj in GameObject.FindObjectsOfType<Stage>())
        {
            Destroy(obj.gameObject);
        }

        stageContent.GetComponent<RectTransform>().sizeDelta = Vector2.zero;

        var stageData = Resources.LoadAll<StageData>("StageData/" + _level).OrderBy(s => s.stage);
        foreach (var stage in stageData)
        {
            //버튼 생성후 자식으로 이동.
            Stage stageButton =  Instantiate(buttonPrefab);
            stageButton.transform.SetParent(stageContent.transform, false);
            //stageButton.GetComponent<Stage>().stageData = stage;
            //스테이지 데이터의 데이타를 갖고온다
            stageButton.stageData = stage;

            //락이미지.
            if (stage.open)
            {
                stageButton.lockImage.enabled = false;
            }
            else
            {
                stageButton.lockImage.enabled = true;
            }

            switch (stage.score)
            {
                case 0:
                    stageButton.scoreImage.fillAmount = 0f;
                    break;
                case 1:
                    stageButton.scoreImage.fillAmount = 0.2f;
                    break;
                case 2:
                    stageButton.scoreImage.fillAmount = 0.5f;
                    break;
                case 3:
                    stageButton.scoreImage.fillAmount = 1f;
                    break;

            }

            
            //stageButton.GetComponent
            //stageContent.GetComponent<GridLayoutGroup>().constraintCount = ++rowCount;
            //stageContent.GetComponent<RectTransform>().sizeDelta += new Vector2(0, 20);
        }
    }
    




}
