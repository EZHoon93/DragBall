using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;



    

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(0, target.position.y, -10);
    }
}
