using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCube : MonoBehaviour
{
     public Transform target; // 따라갈 대상(Transform)
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         OVRInput.Controller controller = OVRInput.Controller.RTouch; // Oculus 오른쪽 컨트롤러 인덱스
        // 컨트롤러의 위치와 회전 가져오기
            Vector3 controllerPosition = OVRInput.GetLocalControllerPosition(controller);
            Quaternion controllerRotation = OVRInput.GetLocalControllerRotation(controller);
         if (OVRInput.Get(OVRInput.Button.One, controller))
        {
            // 컨트롤러의 위치와 회전을 큐브에 적용하기
            transform.position = controllerPosition;
            transform.rotation = controllerRotation;
        }
    }
}
