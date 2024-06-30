using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomBurst : MonoBehaviour
{
    [SerializeField] private EnemyAttackPoint enemyATKDate;
    bool hitbool;
    float hittime;
    void Start()
    {
        Destroy(gameObject, 2);// 発生させたエフェクトが再生し終えたら消す
    }

    void Update()
    {
        if(hittime <= 0.3f)
        {
            hittime += 1.0f * Time.deltaTime;
        }else
        {
            hitbool = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && hitbool == false)
        {
            
            other.gameObject.GetComponent<PlayerStatus>().Damege(enemyATKDate.EnemyAts[3].atkPoint);
            other.gameObject.GetComponent<PlayerStatus>().OnInvisible(enemyATKDate.EnemyAts[3].hitsInvisible);
            hitbool = true;
        }
        
    }


}
