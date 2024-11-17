using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopLine : MonoBehaviour
{
    bool drop_enable;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
       drop_enable = player.drop_enable;
    }

    void OnTriggerStay2D(Collider2D other) {
       // 탑 라인 충돌 로직
       Debug.Log("탑 라인과 충돌");
       if (player.drop_enable == true){  //태그가 동일할 경우에 (같은 과일일경우)
          GameManager.instance.SetGameOver();
       } 
    }
    
    
}