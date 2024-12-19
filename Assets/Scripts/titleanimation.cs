using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleanimation : MonoBehaviour
{
    public float speed = 6.0f; // 왕복 속도 (값이 클수록 빠름)
    public float scaleRange = 0.1f; // 크기 변화 범위 (10% = 0.1)

    private Vector3 initialScale; // 오브젝트의 초기 크기

    void Start(){
        initialScale = transform.localScale;
    }
    void Update()
    {
        if (gameObject.name == "건담만들기"){
        // -maxAngle ~ maxAngle 사이의 값을 계산
            float angle = Mathf.Sin(Time.time * speed);

        // Z축 기준으로 회전 각도 설정
            transform.rotation = Quaternion.Euler(0, 0, angle*10);
        } else if (gameObject.name == "게임시작"){
            float scaleFactor = Mathf.Sin(Time.time * speed) * scaleRange;

        // 초기 크기에 변화를 더해 크기 적용
            transform.localScale = initialScale * (1 + scaleFactor/2);
        }

    }
}
