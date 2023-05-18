using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int randomInt = UnityEngine.Random.Range(0, 4);

        switch(randomInt)
        {
            case 0:
                transform.Translate(0, 0, 0.01f);
                transform.Rotate(0, 0, 0.01f);
                break;
            case 1:
                transform.Translate(0, 0, -0.01f);
                transform.Rotate(0, 0, -0.01f);
                break;
            case 2:
                transform.Translate(0.01f, 0, 0);
                transform.Rotate(0.01f, 0, 0);
                break;
            case 3:
                transform.Translate(-0.01f, 0, 0);
                transform.Rotate(-0.01f, 0, 0);
                break;
        }

      
        
    }
}
