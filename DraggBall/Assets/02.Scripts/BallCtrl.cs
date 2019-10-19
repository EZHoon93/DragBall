using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCtrl : MonoBehaviour
{
    private Rigidbody2D ballRigid;

    private void Awake()
    {
        ballRigid = GetComponent<Rigidbody2D>();

    }

    private void OnEnable()
    {
        ballRigid.bodyType = RigidbodyType2D.Kinematic;
         
    }

   public void GameStart()
    {
        ballRigid.bodyType = RigidbodyType2D.Dynamic;
        ballRigid.AddForce(Vector2.down * 10);
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        IItem item = collision.GetComponent<IItem>();

        if(item != null)
        {
            item.Use(this.gameObject);
        }

    }

    private void Update()
    {
        //rigidbody2D.velocity += Physics2D.gravity * Time.timeScale * 
        //              Time.deltaTime;
        

    }
}
