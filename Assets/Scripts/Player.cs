using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.TextCore.Text;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject spawnObject; 
    [SerializeField] List<GameObject> spawnObjectList = new List<GameObject>();
    [SerializeField] private float drop_cooltime = 2f;  //수박 떨구는 쿨타임
    GameObject spawned;
    GameObject upgradedSpawned;
    Rigidbody2D rb;
    CircleCollider2D cc;
    public int maxIndex = 3;
    public bool drop_enable = true; //수박 떨구기 가능여부 변수


    void Start()
    {
        int spawnIdx = Random.Range(0, 4);
        MakeFruit(0, 4, spawnIdx);
        // 제일 처음 과일을 생성해 논다.
    }

    void Update()
    {
        //마우스 좌표 움직임 파트
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //마우스 좌표 변수 선언
        float toX = Mathf.Clamp(mousePos.x, -2.8f, 2.8f);  //마우스좌표 제한시킨 변수 선언
        transform.position = new Vector3(toX, 4, 0); //플레이어 움직임
        if (drop_enable == true)
        {
            spawned.transform.position = transform.position;
        }
        

        //마우스 클릭 파트 (수박 떨구기)
        if (Input.GetMouseButtonDown(0) && drop_enable == true)  //마우스 클릭 and 가능여부가 참
        {  
            // drop_enable = false; //가능여부를 거짓으로
            // StartCoroutine(Cooldown());  //이뮬래이터 쿨타임 시작하기
        }
        else if (Input.GetMouseButtonUp(0) && drop_enable == true) //마우스를 놓음
        {
            drop_enable = false;

            StartCoroutine(SpawnCooldown());
            //이뮬래이터 쿨타임 시작하기
        }
    }

    IEnumerator SpawnCooldown()
    {
        rb = spawned.GetComponent<Rigidbody2D>();
        rb.gravityScale = 3.5f;
        cc = spawned.GetComponent<CircleCollider2D>();
        cc.isTrigger = false;

        yield return new WaitForSeconds(drop_cooltime); //쿨타임 기다린 후 기다린 후 
        int spawnIdx = Random.Range(0, 3);
        MakeFruit(transform.position.x, transform.position.y, spawnIdx);
        drop_enable = true;  // 가능여부 참으로 전환
    }

    
    public void UpgradeFruit(float xPos,float yPos, int Idx){
            int spawnIdx = Idx;
            spawnObject = spawnObjectList[spawnIdx];

            upgradedSpawned = Instantiate(spawnObject, new Vector3(xPos, yPos, 0), Quaternion.identity);  //플레이어 위치에 새로운 개체 생성
            rb = upgradedSpawned.GetComponent<Rigidbody2D>();
            rb.gravityScale = 1.5f;
            cc = upgradedSpawned.GetComponent<CircleCollider2D>();
            cc.isTrigger = false;
    }
    public void MakeFruit(float xPos,float yPos, int Idx){
            int spawnIdx = Idx;
            spawnObject = spawnObjectList[spawnIdx];

            spawned = Instantiate(spawnObject, new Vector3(xPos, yPos, 0), Quaternion.identity);  //플레이어 위치에 새로운 개체 생성
    }

}
