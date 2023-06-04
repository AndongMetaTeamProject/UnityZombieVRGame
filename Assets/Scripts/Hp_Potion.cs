using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp_Potion : MonoBehaviour
{
    private float recoveryAmount = 200f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float GetHpPotion()
    {
        return recoveryAmount;
    }

    private void OnCollisionEnter(Collision collision)
    {      
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

   
}
