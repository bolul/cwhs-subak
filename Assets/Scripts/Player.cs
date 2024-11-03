using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.TextCore.Text;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject spawnObject; 
    [SerializeField] List<GameObject> spawnObjectList = new List<GameObject>();
    public int maxIndex = 3;
    GameObject spawned;

    private bool drop_enable = true; //수박 떨구기 가능여부 변수

    [SerializeField] private float drop_cooltime = 1f;  //수박 떨구는 쿨타임

    void Start()
    {

    }

    void Update()
    {
        //마우스 좌표 움직임 파트
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //마우스 좌표 변수 선언
        float toX = Mathf.Clamp(mousePos.x, -3.8f, 4);  //마우스좌표 제한시킨 변수 선언
        transform.position = new Vector3(toX, 4, 0); //플레이어 움직임

        //마우스 클릭 파트 (수박 떨구기)
        if (Input.GetMouseButtonDown(0) && drop_enable == true)  //마우스 클릭 and 가능여부가 참
        {  
            int spawnIdx = Random.Range(0, 3);
            spawnObject = spawnObjectList[spawnIdx];

            spawned = Instantiate(spawnObject, new Vector3(toX, 4, 0), Quaternion.identity);  //플레이어 위치에 새로운 개체 생성
            drop_enable = false; //가능여부를 거짓으로
            StartCoroutine(Cooldown());  //이뮬래이터 쿨타임 시작하기
        }
        else if (Input.GetMouseButtonUp(0)) //마우스를 놓음
        {
            spawned.GetComponent<Rigidbody2D>().gravityScale = 3;  //중력을 3으로 조정
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(drop_cooltime); //쿨타임 기다린 후 기다린 후 
        drop_enable = true;  // 가능여부 참으로 전환
    }

    
    public void MakeFruit(float xPos,float yPos, int Idx){
            int spawnIdx = Idx;
            spawnObject = spawnObjectList[spawnIdx];

            spawned = Instantiate(spawnObject, new Vector3(xPos, yPos, 0), Quaternion.identity);  //플레이어 위치에 새로운 개체 생성
    }

}
