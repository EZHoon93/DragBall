using UnityEngine;
using UnityEditor;

public class YourClassAsset
{
    [MenuItem("Assets/Create/StageData")]
    public static void CreateAsset()
    {
        ScriptableObjectUtility.CreateAsset<StageData>();
    }
}