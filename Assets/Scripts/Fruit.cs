using System.Collections;
using System.Collections.Generic;
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
            Debug.Log("충돌함.");
            Destroy(collision.gameObject);
        }
    }
}

