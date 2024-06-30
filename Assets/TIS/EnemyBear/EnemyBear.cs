using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBear : MonoBehaviour
{
    public GameObject FiringPoint;// 爆弾の発射場所
                                  // 
    public GameObject Bom;// 爆弾

    public float speed;// 投げる強さ

    public float throwSpeed;// 投げる感覚
    private void Start()
    {
        Application.targetFrameRate = 60;
        StartCoroutine(BomShoot());
    }


    IEnumerator BomShoot()
    {
        

        while (true)
        {
            // 弾を発射する場所を取得
            Vector3 bulletPosition = FiringPoint.transform.position;

            // 上で取得した場所に、"bullet"のPrefabを出現させる
            GameObject newBom = Instantiate(Bom, bulletPosition, transform.rotation);

            // 出現させた爆弾のforward(z軸方向)
            Vector3 front = newBom.transform.forward;

            // 出現させた爆弾のup(y軸方向)
            Vector3 top = newBom.transform.up;

            // 爆弾の発射方向にnewBallのy方向(ローカル座標)を入れ、爆弾のrigidbodyに衝撃力を加える
            newBom.GetComponent<Rigidbody>().AddForce(top * speed, ForceMode.Impulse);

            // 爆弾の発射方向にnewBallのz方向(ローカル座標)を入れ、爆弾のrigidbodyに衝撃力を加える
            newBom.GetComponent<Rigidbody>().AddForce(front * speed,  ForceMode.Impulse);

            // 爆弾を投げる感覚
            yield return new WaitForSeconds(throwSpeed);

            
        }


    }

}
