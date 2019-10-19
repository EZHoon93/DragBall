using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringItem : MonoBehaviour , IItem
{
    private SpriteRenderer spriteRenderer;
    
    public Sprite _downSprite;
    public Sprite _upSprite;

    public GameObject test;
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    public void Use(GameObject target)
    {
        Rigidbody2D rigidbody2D =  target.GetComponent<Rigidbody2D>();

        rigidbody2D.velocity = Vector2.zero;
        rigidbody2D.AddForce(this.transform.up * 300);
        spriteRenderer.sprite = _upSprite;
        StartCoroutine(ResetSpring());
        Debug.Log("z");
    }

    IEnumerator ResetSpring()
    {
        yield return new WaitForSeconds(1.0f);
        spriteRenderer.sprite = _downSprite;

    }
}
