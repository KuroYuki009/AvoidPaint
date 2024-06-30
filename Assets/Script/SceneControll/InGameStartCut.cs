using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameStartCut : MonoBehaviour
{
    Animator animator;
    float delay;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if(delay <= 1.0f)
        {
            delay += 1 * Time.deltaTime;
        }
        else
        {
            animator.SetTrigger("CutIN");
            this.enabled = false;
        }
    }
}
