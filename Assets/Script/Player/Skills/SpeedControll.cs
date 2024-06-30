using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControll : MonoBehaviour
{
    //SpeedController
    public float mouseScroll = 0.0f;
    float maxSpeed = 2.0f;
    float minSpeed = -2.0f;
    Vector3 cameraForward;
    Vector3 moveForward;
    void Start()
    {
        
    }

    
    void Update()
    {
        //ホイールボタンを押すとホイール値をリセットする。
        if (Input.GetButtonDown("Fire3"))
        {
            mouseScroll = 0.0f;
        }

        mouseScroll +=(10.0f * Input.GetAxis("MouseScrollWheel"));
        //
        mouseScroll = Mathf.Clamp(mouseScroll, minSpeed, maxSpeed);
    }
}
