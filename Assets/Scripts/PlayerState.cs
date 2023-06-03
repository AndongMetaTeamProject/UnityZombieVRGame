using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    private float MaxHP = 1000f;
    private float CurHP = 1000f;
    private float Attack;
    
    [SerializeField]
    private Slider HPSlider;
  
    public ZombieState ZS;
    public Hp_Potion HpPotion;
    // Start is called before the first frame update

    public AudioClip drink;
    public AudioClip attack_zombie;

    AudioSource audiosource;

    void Start()
    {
        HPSlider.value = CurHP/MaxHP;
        
    }

    // Update is called once per frame
    void Update()
    {
        handleHP();

        if(CurHP==0)
        {
            Destroy(gameObject);
            Application.Quit();
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

    public float Damage(float Attack)
    {

        return CurHP -= Attack;
    }
    private void handleHP()
    {
        HPSlider.value = CurHP/MaxHP;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Potion"))
        {
            audioSource.clip = drink; //물약 먹는 사운드
            audioSource.Play();
            
            CurHP += HpPotion.GetHpPotion();
          
        }
       
        //좀비가 플레이어 OnCollisionEnter되면 
        if(collision.gameObject.CompareTag("Zombie"))
        {
            audioSource.clip = attack_zombie; //좀비랑 부딪힐 때 사운드
            audioSource.Play();
            
            CurHP -= ZS.GetAttack();
        }

    }
}
