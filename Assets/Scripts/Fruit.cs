using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


public class Fruit : MonoBehaviour
{

    private float deathTime;
    private bool isFinished;
    Color color;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y >= 2 && gameObject.transform.position.y < 4)
        {
            deathTime += Time.deltaTime;
        }
        else 
        {
            deathTime = 0;
            spriteRenderer.color = color;
        }
        if (deathTime > 2)
           {
               spriteRenderer.color = new Color(0.9f,0.2f,0.2f);
           }

           if (deathTime > 5)
           {
               GameManager.instance.SetGameOver();
           }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {   //과일 충돌 로직!
        string MyTag = gameObject.tag;  //게임오브젝트 태그 불러옴
        if (collision.gameObject.CompareTag(MyTag)){  //태그가 동일할 경우에 (같은 과일일경우)
            int fruitIdx = int.Parse(MyTag);
            if (fruitIdx >= 10) return;          // 태그가 최대 이상이면 종료 (합체 x)
             
            if (collision.gameObject.GetInstanceID() < gameObject.GetInstanceID()){ //하나만 실행되게
                GameManager.instance.IncreaseScore(fruitIdx);
                ContactPoint2D contact = collision.contacts[0]; //콘택트 변수
                Vector2 pos = contact.point; //충돌지점을 가져온다!!
                GameObject.Find("Player").GetComponent<Player>().UpgradeFruit(pos.x, pos.y, int.Parse(gameObject.tag) + 1);
            }
            Destroy(collision.gameObject);
        }
    }
}

