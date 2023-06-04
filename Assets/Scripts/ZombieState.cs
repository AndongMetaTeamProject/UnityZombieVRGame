using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus;

public class ZombieState : MonoBehaviour
{ 
    public GameObject particlePrefab; 
    
    private float MaxHP = 100f;
    private float CurHP = 100f;
    private float Attack = 100f;
    public PlayerState Player;
    public KillCount KC;
    public GameObject HpPotion;

    public AudioClip smash;
    public AudioClip zombie_dead;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        Vector3 collisionPoint = collision.contacts[0].point;
        GameObject particle = Instantiate(particlePrefab, collisionPoint, Quaternion.identity);
        //GetComponent<ParticleSystem>().Play();
            
        Destroy(particle, 1f);

        
        //좀비가 무기와 OnCollisionEnter되면 맞는 사운드 
        if(collision.gameObject.CompareTag("Weapon"))
        {
            audioSource.clip = smash;
            audioSource.Play();

            CurHP -= 10f;
        }
       
       
        //좀비 hp가 0이되면 죽을떄 사운드 
        if(CurHP <= 0)
        {
            audioSource.clip = zombie_dead;
            audioSource.Play();

            Destroy(gameObject);
           
            KC.IncreaseScore();
            SpawnItem();
          
        }

       
    }

    public float GetCurHP()
    {
        return CurHP;
    }

    public float GetAttack()
    {
        return Attack;
    }

    public void SetCurHP(float HP)
    {
        CurHP = HP;

    }

    public float GetMaxHP()
    {
        return MaxHP;
    }

    void SpawnItem()
    {
        if (HpPotion != null)
        {
            Vector3 spawnPosition = transform.position; // 좀비가 죽은 위치에 아이템 생성
            Instantiate(HpPotion, spawnPosition, Quaternion.identity);
        }
    }


    
}

