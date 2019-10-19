using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Stage : MonoBehaviour , IPointerClickHandler
{
    public StageData stageData;

    public Image lockImage;
    public Image scoreImage;
    public Text text;



    public void OnPointerClick(PointerEventData eventData)
    {
        PlayerInfo.currentLevel = stageData.level;
        PlayerInfo.currentStage = stageData.stage;

        
        SceneManager.LoadScene("GameScene");
        Debug.Log("스테이지 생성");
    }
}
