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
    
    private bool drop_enable = true;
    
    [SerializeField] private float drop_cooltime = 1f;
    void Start()
    {
        
        
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX = Mathf.Clamp(mousePos.x, -3.8f ,4);  //마우스좌표
        transform.position = new Vector3(toX, 4, 0); //플레이어 움직임

        if (Input.GetMouseButtonDown(0) && drop_enable == true) {  //마우스 버튼 누름
		spawned = Instantiate(spawnObject, new Vector3(toX, 4, 0), Quaternion.identity);
        drop_enable = false;
        StartCoroutine(Cooldown());  //
	} else if (Input.GetMouseButtonUp(0)) {
		spawned.GetComponent<Rigidbody2D>().gravityScale = 3;
	}
    }

    IEnumerator Cooldown(){
        yield return new WaitForSeconds(drop_cooltime);
        drop_enable = true;
    }
}
