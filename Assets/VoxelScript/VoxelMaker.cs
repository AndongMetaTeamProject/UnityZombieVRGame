using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMaker : MonoBehaviour
{
    public GameObject voxelFactory;  //복셀 공장
    public int voxelPoolSize = 20;   //오브젝트 풀의 크기
    public static List<GameObject> voxelPool = new List<GameObject>();   //오브젝트 풀
    public float createTime = 0.1f;   //생성 시간
    float currentTime = 0;  //경과 시간
    public Transform crosshair;   //  크로스헤어(조준점) 변수
    public ParticleSystem particleSystem;

    void Start()
    {
        for (int i = 0; i < voxelPoolSize; i++)   //오브젝트 풀에 비활성화 된 복셀을 담는다
        {
            GameObject voxel = Instantiate(voxelFactory);   //복셀 공장에서 복셀 생성
            voxel.SetActive(false);   //복셀 비활성화하기
            voxelPool.Add(voxel);   //복셀을 오브젝트 풀에 담는다
        }
    }

    void Update()
    {
        ARAVRInput.DrawCrosshair(crosshair);  //크로스헤어(조준점) 그리기
        if (ARAVRInput.Get(ARAVRInput.Button.One))  //VR 컨트롤러의 발사 버튼을 누르면
        {
            currentTime += Time.deltaTime;  //일정시간 마다 복셀을 만든다
            if (currentTime > createTime)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  //pc 일 때 마우스
                //컨트롤러가 향하는 방향으로 시선 만들기
                //Ray ray = new Ray(ARAVRInput.RHandPosition, ARAVRInput.RHandDirection);
                RaycastHit hitInfo = new RaycastHit();
                if (Physics.Raycast(ray, out hitInfo))   //시선이 바닥 위에 위치해 있다면
                {
                    if (voxelPool.Count > 0)
                    {
                        currentTime = 0;   //복셀을 생성했을 때만 경과 시간을 초기화 해준다
                        GameObject voxel = voxelPool[0];   //오브젝트 풀에서 복셀 하나를 가져온다
                        voxel.SetActive(true);   //복셀을 활성화한다
                        voxel.transform.position = hitInfo.point;   //복셀을 배치한다
                        voxelPool.RemoveAt(0);   //오브젝트 풀에서 복셀을 제거한다
                    }
                }
            }
        }
        /*
        if (ARAVRInput.Get(ARAVRInput.Button.Two))  //VR 컨트롤러의 발사 버튼을 누르면
        {
            currentTime += Time.deltaTime;  //일정시간 마다 복셀을 만든다
            if (currentTime > createTime)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  //pc 일 때 마우스
                //컨트롤러가 향하는 방향으로 시선 만들기
                //Ray ray = new Ray(ARAVRInput.RHandPosition, ARAVRInput.RHandDirection);
                RaycastHit hitInfo = new RaycastHit();
                if (Physics.Raycast(ray, out hitInfo))   //시선이 바닥 위에 위치해 있다면
                {
                    particleSystem.Play();
                }
            }
        }
        */
    }
}
