using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageData : ScriptableObject 
{
    public int level;
    public int stage;

    public int score;
    public bool open = false;
    [SerializeField]
    public GameObject stagePrefab;

}
