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
    {   
        string MyTag = gameObject.tag;
        if (collision.gameObject.CompareTag(MyTag)){
            if (int.Parse(MyTag) >= 2) return;
             
            if (collision.gameObject.GetInstanceID() < gameObject.GetInstanceID()){
            Debug.Log("충돌함.");
            ContactPoint2D contact = collision.contacts[0];
            Vector2 pos = contact.point;
            GameObject.Find("Player").GetComponent<Player>().MakeFruit(pos.x, pos.y, int.Parse(gameObject.tag) + 1);
            }
            Destroy(collision.gameObject);
        }

        
    }
}

