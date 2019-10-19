using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject StartButton;  //게임 시작 버튼
    public GameObject StopButton;   //게임 중지 버튼
    public GameObject MenuContent;  //중지 버튼시 메뉴 

    public GameObject GameEnd;  //게임 끝날시. 

    public Text succesText; //게임 클리어시 메시지
    public Text failedText; //게임 실패시 메시지



    private void start()
    {
    }

    private void Start()
    {
        ReGame();
        GameManager.Instance.reStart += ReGame;

    }

    //초기화.
    private void ReGame()
    {
        StartButton.SetActive(true);
        StopButton.SetActive(false);
        MenuContent.SetActive(false);
        GameEnd.SetActive(false);
        Debug.Log("DS");
    }

    /// <summary>
    /// 게임 끝날시, 다음,다시하기,홈
    /// </summary>
    //다음 스테이지
    public void ClickNextStage()
    {
        GameManager.Instance.GameReset(true);

    }

    //다시하기
    public void ClickRetryGame()
    {
        
        GameManager.Instance.GameReset(false);
    }
    //홈으로 돌아가기
    public void ClickHome()
    {

    }

    /// <summary>
    /// 게임 메뉴 부분, 시작,중지,설정
    /// </summary>
    //게임 스타트 버튼
    public void ClickGameStartButton()
    {
        StartButton.SetActive(false);
        StopButton.SetActive(true);
        GameManager.Instance.ClickGameStartButton();
    }

    //게임 일시 정지 버튼
    public void ClickGameStopButton()
    {
        MenuContent.SetActive(true);
    }

    //게임 계속 하기 버튼
    public void ClickResumeButton()
    {
        MenuContent.SetActive(false);
        GameEnd.SetActive(false);


    }



    //게임 클리어 및 실패.
    public void GameClear()
    {
        GameEnd.SetActive(true);
        succesText.gameObject.SetActive(true);
        failedText.gameObject.SetActive(false);

    }

    public void GameFailed()
    {
        GameEnd.SetActive(true);
        succesText.gameObject.SetActive(false);
        failedText.gameObject.SetActive(true);
    }

  
}
