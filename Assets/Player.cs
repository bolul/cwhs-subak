using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 오브젝트가 생성될 Y위치
    private static readonly float INIT_Y_POS = 4;

// 만들어준 프리팹 오브젝트를 담을 공간
    public GameObject mainObject;

    private void Start() {
	//오브젝트 생성
	    Instantiate(mainObject, new Vector3(0, INIT_Y_POS, 0), Quaternion.identity);
}
}
