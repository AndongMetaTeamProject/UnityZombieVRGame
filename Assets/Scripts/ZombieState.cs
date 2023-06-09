using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus;

public class ZombieState : MonoBehaviour
{ 
    public GameObject particlePrefab; 
    
    private float MaxHP = 100f;
    private float CurHP = 100f;
    private float Attack = 30f;
    public PlayerState Player;
    public KillCount KC;
    public GameObject HpPotion;

   

    private AudioSource audioSource; // 첫 번째 오디오 소스


    public AudioClip smash;
    public AudioClip zombie_dead;


    private Rigidbody rb;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
      
        rb = GetComponent<Rigidbody>();
       
      
    
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        Vector3 collisionPoint = collision.contacts[0].point;
       
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        
        //좀비가 무기와 OnCollisionEnter되면 맞는 사운드 
        if(collision.gameObject.CompareTag("Weapon"))
        {
             GameObject particle = Instantiate(particlePrefab, collisionPoint, Quaternion.identity);
            //GetComponent<ParticleSystem>().Play();
            
            Destroy(particle, 1f);
            audioSource.clip = smash;
            audioSource.Play();

            CurHP -= 34f;
        }
       
       
        //좀비 hp가 0이되면 죽을떄 사운드 
        if(CurHP <= 0)
        {
            audioSource.clip =  zombie_dead;
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

