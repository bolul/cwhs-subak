using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        int MyId = gameObject.GetInstanceID();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {   
        string MyTag = gameObject.tag;
        if (collision.gameObject.CompareTag(MyTag)){
            if (collision.gameObject.GetInstanceID() < gameObject.GetInstanceID()){
            Debug.Log("충돌함.");
            Destroy(collision.gameObject);
            }
            
        }

        
    }
}

