using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintAttackConvert : MonoBehaviour
{
    //�A�j���[�V�����C�x���g���擾���A�A�^�b�`���Ă���X�N���v�g��sendMessage���s���B

    [SerializeField]turretQuo turretQuoSc;


    void Convert_EnemyAttackShoot()
    {
        turretQuoSc.SendMessage("EnemyAttackShoot");
    }
}
