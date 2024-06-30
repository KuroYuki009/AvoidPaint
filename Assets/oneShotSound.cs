using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneShotSound : MonoBehaviour
{
    [SerializeField]AudioClip use_SE;
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(use_SE);
    }
}
