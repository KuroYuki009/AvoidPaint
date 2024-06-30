using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Button : MonoBehaviour
{
    [SerializeField] Animator cutInAnimator;
    public void ClickForStart()
    {
        InGameManager.globalScore = 0;
        InGameManager.globalSuvivalTime = 0;

        cutInAnimator.SetTrigger("CutOUT_LoadInGame");
    }
}
