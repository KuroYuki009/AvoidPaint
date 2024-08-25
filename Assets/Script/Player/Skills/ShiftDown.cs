using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftDown : MonoBehaviour
{
    NewPlayerMove newPlayrMove;
    [SerializeField] float addSpeedValue;
    float localMoveSpeed;

    void Start()
    {
        newPlayrMove = GetComponent<NewPlayerMove>();
        float f = newPlayrMove.moveSpeed;
        localMoveSpeed = f;
        addSpeedValue = 0.3f;
        
    }

    
    void Update()
    {
        if(Input.GetButton("LeftShift"))
        {
            newPlayrMove.moveSpeed = addSpeedValue;
        }
        else if(Input.GetButtonUp("LeftShift"))
        {
            newPlayrMove.moveSpeed = localMoveSpeed;
        }
    }
}
