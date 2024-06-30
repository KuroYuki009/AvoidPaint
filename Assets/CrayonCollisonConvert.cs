using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrayonCollisonConvert : MonoBehaviour
{
    //単純にこのmodel部位のコライダーに当たるとDamageを与え、ゲームオブジェクトを破壊する。

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
