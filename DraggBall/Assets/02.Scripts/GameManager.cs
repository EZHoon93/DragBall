using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    private BallCtrl[] ballCtrl;
    private List<BallCtrl> balls;

    public event Action reStart; // 사망시 발동할 이벤트


    public int ballCount { get; set; }

    private GameMenuUI gameMenuUI;

    private GameObject currentStage;

    private void Awake()
    {
        if( Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }


       gameMenuUI = FindObjectOfType<GameMenuUI>();
    }

    private void Start()
    {
        //시작시 스테이지 프리팹생성
        //다시하기 로 생성.
        CreateStagePrefab(false);
    }

    //스테이지를 생성, false->다시하기, true->다음레벨, 
    //LINQ로 폴더에 다음스테이지없으면 -> 레벨증가, 스테이지1초기화, 다시 false로 시작
    private void CreateStagePrefab(bool isNext)
    {
        if (isNext) PlayerInfo.currentStage++;
        

        if (currentStage != null) { Destroy(currentStage); }

        //현재 유저가 선택한 데이터를 기반으로 데이터를 갖고온다.
        var stageData = Resources.LoadAll<StageData>("StageData/" + PlayerInfo.currentLevel)
                    .Where(s => s.stage == PlayerInfo.currentStage)
                    .Any(stage => currentStage = Instantiate(stage.stagePrefab));

        //다음 스테이지가 없을시 레벨을 증가, 스테이지 1
        if (!stageData)
        {
            PlayerInfo.currentLevel++;
            PlayerInfo.currentStage = 1;
            CreateStagePrefab(false);
        }
        

    }

    public void ClickGameStartButton()
    {
        ballCtrl = FindObjectsOfType<BallCtrl>();
        ballCount = 0;
        foreach (BallCtrl ball in ballCtrl)
        {
            ballCount++;
            ball.GameStart();
        }
        
    }

    //게임 클리어시.
    public void GameClear()
    {
        //점수 
        gameMenuUI.GameClear();
    }

    //다시하기.밑  다음 스테이지 ->GameMenuUI에서
    public void GameReset(bool isNext)
    {
        //Next -> true 다음스테이지 , false 다시 하기
        
        if( reStart != null) { reStart(); }

        

        //Next -> true 다음스테이지 , false 다시 하기
        CreateStagePrefab(isNext);
    }



    

}
