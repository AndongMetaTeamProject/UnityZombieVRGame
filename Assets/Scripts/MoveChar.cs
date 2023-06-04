using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR. Interaction.Toolkit;

public class MoveChar : MonoBehaviour
{
    // Start is called before the first frame update
    public XRController controller = null;
    private CharacterController character;
    private GameObject _camera;
    float speed = 3f;
    private void Awake ()
    {
        character = GetComponent<CharacterController>();
        _camera = GetComponent<XRRig> () . cameraGameObject;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CommonInput();
    }

    private void CommonInput ()
    {      
        if (controller. inputDevice. TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
        {


            var inputVector = new Vector3 (position.x, Physics.gravity.y, z: position.y);
            var inputDirection = transform. TransformDirection (inputVector);
            var lookDirection = new Vector3 (x: 0, _camera.transform.eulerAngles.y, z: 0);
            var newDirection = Quaternion. Euler (lookDirection) * inputDirection;
            character.Move (motion: newDirection * Time. deltaTime * speed);

        }
    }   
}





