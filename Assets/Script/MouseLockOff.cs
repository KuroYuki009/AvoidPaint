using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLockOff : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
