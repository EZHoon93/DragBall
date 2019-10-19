using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorItem : MonoBehaviour, IItem
{
    public Sprite mid;
    public Sprite top;


    public SpriteRenderer midsSprite;
    public SpriteRenderer topSprite;

    private int ballCount ;

    private void Start()
    {
        ballCount = 0;
        //GameManager.Instance.reStart += resetBallCount;
    }

    
    public void Use(GameObject target)
    {
        //공이 아닐시 리턴
        if (!target.CompareTag("Player")) return;

        //공일시 이미지 변경
        midsSprite.sprite = mid;
        topSprite.sprite = top;
        //볼 페이드 아웃
        StartCoroutine(FadeOutBall(target.GetComponent<SpriteRenderer>(), 0.05f));

        ballCount++;
        //들어온갯수 = 초깃값 갯수 같다면 . 클리어
        if (ballCount == GameManager.Instance.ballCount) GameManager.Instance.GameClear();
        


    }



    IEnumerator FadeOutBall(SpriteRenderer spriteRenderer, float amount)
    {
        Color color = spriteRenderer.color;

        while (color.a > 0.0f)
        {
            color.a -= amount;
            spriteRenderer.color = color;
            yield return new WaitForSeconds(amount);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<SpriteRenderer>().enabled = false;
            collision.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            collision.transform.position = this.transform.position;
        }
    }


}
