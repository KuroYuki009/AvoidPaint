using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintAttackConvert : MonoBehaviour
{
    //アニメーションイベントを取得し、アタッチしてあるスクリプトにsendMessageを行う。

    [SerializeField]turretQuo turretQuoSc;


    void Convert_EnemyAttackShoot()
    {
        turretQuoSc.SendMessage("EnemyAttackShoot");
    }
}
