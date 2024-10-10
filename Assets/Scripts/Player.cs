using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject spawnObject;
    GameObject spawned;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX = Mathf.Clamp(mousePos.x, -4 ,4);  //마우스좌표
        transform.position = new Vector3(toX, 4, 0); //플레이어 움직임

        if (Input.GetMouseButtonDown(0)) {  //마우스 버튼 누름
		spawned = Instantiate(spawnObject, new Vector3(toX, 4, 0), Quaternion.identity);  //
	} else if (Input.GetMouseButtonUp(0)) {
		spawned.GetComponent<Rigidbody2D>().gravityScale = 3;
	}
    }

}
