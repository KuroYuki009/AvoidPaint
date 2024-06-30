using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTurn : MonoBehaviour
{
    public GameObject target;

    Quaternion lookRotation;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        lookRotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);

        lookRotation.z = 0;
        lookRotation.x = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.3f);
    }
}
