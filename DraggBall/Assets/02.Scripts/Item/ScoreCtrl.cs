using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCtrl : MonoBehaviour , IItem
{
    public void Use(GameObject target)
    {
        Debug.Log("점수 증가 ");
        this.gameObject.SetActive(false);
    }
}
