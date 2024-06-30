using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBom : MonoBehaviour
{
    
    public ParticleSystem Burst;// 爆発のエフェクトを入れる

    void Start()
    {
        StartCoroutine(BomBurst());
    }

    IEnumerator BomBurst()
    {
        yield return new WaitForSeconds(2f);// 2秒後に下の処理を開始

        ParticleSystem BomParticle = Instantiate(Burst);// まず爆発のエフェクトを生成する

        BomParticle.transform.position = this.transform.position;// 爆発エフェクトが爆弾の位置に生成されるようにする

        Burst.Play();// ほんで爆発エフェクト再生開始

        Destroy(gameObject);// 再生開始と同時に爆弾を消去
    }
}
