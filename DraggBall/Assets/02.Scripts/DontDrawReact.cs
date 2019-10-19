using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDrawReact : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.name);
    }
}
