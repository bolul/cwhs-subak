using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {   //과일 충돌 로직!
        string MyTag = gameObject.tag;  //게임오브젝트 태그 불러옴
        if (collision.gameObject.CompareTag(MyTag)){  //태그가 동일할 경우에 (같은 과일일경우)
            if (int.Parse(MyTag) >= 2) return;          //여기 중요함!!!!!!!!!!!!!!!!!!!!!!! 최댓값!
             
            if (collision.gameObject.GetInstanceID() < gameObject.GetInstanceID()){ //하나만 실행되게!!
            Debug.Log("충돌함.");
            ContactPoint2D contact = collision.contacts[0]; //콘택트 변수
            Vector2 pos = contact.point; //충돌지점을 가져온다!!
            GameObject.Find("Player").GetComponent<Player>().UpgradeFruit(pos.x, pos.y, int.Parse(gameObject.tag) + 1);
            }
            Destroy(collision.gameObject);
        }

        
    }
}

