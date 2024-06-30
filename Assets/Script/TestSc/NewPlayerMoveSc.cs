using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMoveSc : MonoBehaviour
{
    Rigidbody plyerRb;

    Vector3 controllInput = Vector3.zero;
    float jumpInput;
    void Start()
    {
        plyerRb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        controllInput = new Vector3(Input.GetAxis("Horizontal"),0.0f, Input.GetAxis("Vertical"));
        
    }

    void FixedUpdate()
    {
        Debug.Log(controllInput);
        plyerRb.AddForce(-controllInput.x , 0.0f, -controllInput.z, ForceMode.Impulse);
    }
}
