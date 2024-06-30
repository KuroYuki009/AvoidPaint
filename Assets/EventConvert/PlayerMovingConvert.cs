using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingConvert : MonoBehaviour
{
    [SerializeField]private Animator animator;
    Rigidbody playerRb;
    //SpeedControll���擾���A�}�E�X�X�N���[���l���擾����B
    [SerializeField] private SpeedControll speedcontroller;
    int scrollPoint;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        scrollPoint = (int)speedcontroller.mouseScroll;

        if (playerRb.velocity.magnitude <= 0.1f)
        {
            animator.SetBool("Idol", true);

            animator.SetBool("WalkAnima", false);

            animator.SetBool("RunAnima", false);
        }
        else if ((scrollPoint == 0 || scrollPoint == -1 || scrollPoint == -2) && playerRb.velocity.magnitude >= 0.1f)
        {
            animator.SetBool("WalkAnima", true);

            animator.SetBool("RunAnima", false);

            animator.SetBool("Idol", false);
        }
        else if ((scrollPoint == 1 || scrollPoint == 2) && playerRb.velocity.magnitude >= 0.1f)
        {
            animator.SetBool("RunAnima",true);

            animator.SetBool("WalkAnima", false);

            animator.SetBool("Idol", false);
        }
    }

    void AnimaWalk()
    {
        //animator.SetTrigger("WalkAnima");
    }
    void AnimaRun()
    {
        //animator.SetTrigger("RunAnima");
    }

}
