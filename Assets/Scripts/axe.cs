using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axe : MonoBehaviour
{
    public Hp_Potion potion;
    public PlayerState ps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Potion"))
        {   
            
            ps.Heal(potion.GetHpPotion());
            potion.Destoryed();

        }
    }
}

