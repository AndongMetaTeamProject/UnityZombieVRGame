using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus;

public class ZombieState : MonoBehaviour
{ 
    public GameObject particlePrefab; 
    
    public float MaxHP = 100f;
    public float CurHP = 100f;
   
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        CurHP -= 10f;
        Vector3 collisionPoint = collision.contacts[0].point;
        GameObject particle = Instantiate(particlePrefab, collisionPoint, Quaternion.identity);
        //GetComponent<ParticleSystem>().Play();
            
        Destroy(particle, 1f);
    
    
    
        if(CurHP <= 0)
        {
            Destroy(gameObject);
        }
       
    }



    
}

