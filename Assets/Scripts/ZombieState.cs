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
    
        if(collision.gameObject.CompareTag("Player"))
        {
            Player.Damage(Attack);
            
        }
        if(collision.gameObject.CompareTag("Weapon"))
        {
            CurHP -= 10f;
        }
        
       
    
        if(CurHP <= 0)
        {
            Destroy(gameObject);
           
            KC.IncreaseScore();
            
          
        }
       
    }

    public float GetCurHP()
    {
        return CurHP;
    }

    public void SetCurHP(float HP)
    {
        CurHP = HP;

    }

    public float GetMaxHP()
    {
        return MaxHP;
    }



    
}

