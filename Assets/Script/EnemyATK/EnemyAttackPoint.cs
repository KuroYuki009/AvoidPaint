using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy_ATKDate")]
public class EnemyAttackPoint : ScriptableObject
{
    public List<EnemyATK> EnemyAts;

    [System.Serializable]
    public class EnemyATK
    {
        //�U����
        //public string name;
        //�X�s�[�h(float�l)
        public float speed;
        //�^����_���[�W�l
        public int atkPoint;
        //���������ۂ̖��G���Ԃ̔���
        public bool hitsInvisible;
    }
}
