// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class PlayerHP: MonoBehaviour
// {
//     private float MaxHP = 1000f;
//     private float CurHP = 1000f;
//     private float Attack;
//     [SerializeField]
//     private Slider HPSlider;
//     // Start is called before the first frame update
//     void Start()
//     {
//         HPSlider.value = CurHP/MaxHP;
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         handleHP();

//         if(CurHP==0)
//         {
//             Destroy(gameObject);
//             Application.Quit();
//         }
       
//     }

//     public float GetCurHP()
//     {

//         return CurHP;
//     }
//     public void SetCurHP(float HP)
//     {
//         CurHP = HP;
//     }
//     public float GetMaxHP()
//     {
//         return MaxHP;
//     }

//     public float Damage(float Attack)
//     {

//         return CurHP -= Attack;
//     }
//     private void handleHP()
//     {
//         HPSlider.value = CurHP/MaxHP;
//     }
    
// }
