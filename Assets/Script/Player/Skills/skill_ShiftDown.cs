using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_ShiftDown : MonoBehaviour
{
    NewPlayerMove newPlayrMove;
    [SerializeField] float addSpeedValue;
    float localMoveSpeed;
    void Start()
    {
        newPlayrMove = GetComponent<NewPlayerMove>();
        localMoveSpeed = newPlayrMove.moveSpeed;
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
