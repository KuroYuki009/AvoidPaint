using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrayonSpown : MonoBehaviour
{
    // これはプレイヤーにつけているスクリプトです!!!!!!!!!!!!!!!!


    public GameObject CrayonObject;// スポーンさせるクレヨンをぶちこむ
    public float CrayonSpownCount;// クレヨンのスポーン間隔を決める


    void Start()
    {
        StartCoroutine(CrayonSpown());
    }

    void Update()
    {
        
    }

    IEnumerator CrayonSpown()
    {
        while (true)
        {
            // プレハブの位置をランダムで設定
            float x = Random.Range(-0.6f, 0.6f);
            float z = Random.Range(-0.5f, 0.5f);
            Vector3 pos = new Vector3(x, 0, z);

            // プレハブを生成
            Instantiate(CrayonObject, pos, Quaternion.identity);

            // ここでクレヨンのスポーン間隔を決めてる
            yield return new WaitForSeconds(CrayonSpownCount);
        }
    }

    
}
