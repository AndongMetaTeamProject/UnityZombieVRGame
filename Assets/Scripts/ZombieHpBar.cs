using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHpBar : MonoBehaviour
{
    private Camera mainCamera;

    public GameObject monsterHead; // 몬스터의 머리 부분 (또는 헤드 포지션 참조) 오브젝트에 대한 참조
    public GameObject hpBar; // 몬스터의 HP 바 오브젝트에 대한 참조
    public Vector3 offset; // 몬스터 머리 위에 HP 바가 위치할 때 사용할 추가 위치 오프셋
    public ZombieState zs;
    [SerializeField]
    private Slider HPSlider;
    void Start()
    {
        mainCamera = Camera.main;
        
        HPSlider.value = zs.GetCurHP()/zs.GetMaxHP();
    }

    void Update()
    {
         // GetComponentInParent<LookAtCamera>();을 통한 몬스터 (부모 오브젝트)로부터 머리 오브젝트를 찾을 수도 있습니다.
        hpBar.transform.position = monsterHead.transform.position + offset;
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward, mainCamera.transform.rotation * Vector3.up);
        handleHP();
        
       
    }

    private void handleHP()
    {
        HPSlider.value = zs.GetCurHP()/zs.GetMaxHP();
    }
}