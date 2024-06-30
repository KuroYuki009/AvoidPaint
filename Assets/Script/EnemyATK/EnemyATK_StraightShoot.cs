using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyATK_StraightShoot : MonoBehaviour
{
    [SerializeField]private EnemyAttackPoint enemyATKDate;

    //public GameObject target;
    public float shootSpeed;
    float localshootSpeed;
    Quaternion lookRotation;

    //経過時間
    float timescaleDelay;
    void Start()
    {
        shootSpeed = enemyATKDate.EnemyAts[1].speed;
        //lookRotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);
    }

    private void FixedUpdate()
    {
        //プレイヤーの位置を一度だけ取得し、その方向へ移動する。
        lookRotation.z = 0;
        lookRotation.x = 0;
        
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);
        
        Vector3 p = new Vector3(0f, 0f, shootSpeed);

        transform.Translate(p);

        //一定時間すると攻撃が消滅する
        /*timescaleDelay += (1.0f * Time.fixedDeltaTime);
        if (timescaleDelay >= 5.0f) Destroy(gameObject);*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<PlayerStatus>() && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStatus>().Damege(enemyATKDate.EnemyAts[1].atkPoint);
            collision.gameObject.GetComponent<PlayerStatus>().OnInvisible(enemyATKDate.EnemyAts[1].hitsInvisible);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "StageWall") Destroy(gameObject);
    }
}
