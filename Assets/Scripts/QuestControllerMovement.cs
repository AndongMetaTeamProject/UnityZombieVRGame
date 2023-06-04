// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;


// public class QuestControllerMovement : MonoBehaviour
// {
//     private InputDevice targetDevice; // 퀘스트 컨트롤러 InputDevice
//     public float movementSpeed = 3f; // 이동 속도

//     private void Start()
//     {
//         // 퀘스트 컨트롤러 InputDevice 가져오기
//         InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, new List<InputDevice>());
//         List<InputDevice> devices = new List<InputDevice>();
//         InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Right, devices);
//         if (devices.Count > 0)
//         {
//             targetDevice = devices[0];
//         }
//     }

//     private void Update()
//     {
//         if (targetDevice != null)
//         {
//             // 컨트롤러의 조이스틱 입력 값 받아오기
//             Vector2 joystickValue = Vector2.zero;
//             if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out joystickValue))
//             {
//                 // 움직임 벡터 계산
//                 Vector3 movementVector = new Vector3(joystickValue.x, 0f, joystickValue.y) * movementSpeed * Time.deltaTime;

//                 // xrrig의 Transform 컴포넌트 가져오기
//                 Transform xrRigTransform = FindObjectOfType<XRRig>().transform;

//                 // 움직임 적용
//                 xrRigTransform.Translate(movementVector, Space.Self);
//             }
//         }
//     }
// }