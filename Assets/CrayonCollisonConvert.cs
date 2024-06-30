using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrayonCollisonConvert : MonoBehaviour
{
    //�P���ɂ���model���ʂ̃R���C�_�[�ɓ������Damage��^���A�Q�[���I�u�W�F�N�g��j�󂷂�B

    Collider headbodyCollider;
    [SerializeField] GameObject enemycrayonObj;

    [SerializeField] private EnemyAttackPoint enemyATKDate;
    void Start()
    {
        headbodyCollider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStatus>().Damege(enemyATKDate.EnemyAts[2].atkPoint);
            collision.gameObject.GetComponent<PlayerStatus>().OnInvisible(enemyATKDate.EnemyAts[2].hitsInvisible);
            Destroy(enemycrayonObj);
        }
        
    }
}
