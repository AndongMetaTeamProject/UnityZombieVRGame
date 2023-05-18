using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel : MonoBehaviour
{
    public float speed = 5;  //복셀이 날아갈 속도 구하기
    public float destroyTime = 3.0f;  //복셀을 제거할 시간
    float currentTime; //경과 시간

    void OnEnable()  //오브젝트가 활성화 될 때 호출되는 콜백 함수
    {
        currentTime = 0;
        Vector3 direction = Random.insideUnitSphere;  //랜덤한 방향을 찾는다
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = direction * speed;   //랜덤한 방향으로 날아가는 속도를 준다
    }

    void Update()
    {
        currentTime += Time.deltaTime;  //시간을 누적

        if (currentTime > destroyTime)   //3초가 지났다면
        {
            gameObject.SetActive(false);  //Voxel을 비활성화
            VoxelMaker.voxelPool.Add(gameObject);   //오브젝트 풀에 다시 넣어준다
        }
    }
}
