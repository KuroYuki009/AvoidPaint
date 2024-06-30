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
        //攻撃名
        //public string name;
        //スピード(float値)
        public float speed;
        //与えるダメージ値
        public int atkPoint;
        //当たった際の無敵時間の発生
        public bool hitsInvisible;
    }
}
