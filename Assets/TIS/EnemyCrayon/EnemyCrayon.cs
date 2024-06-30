using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrayon : MonoBehaviour
{
    public Transform CrayonTransfome;// 自分のTransfomeを取る。

    Transform PlayerTransfome;// 追跡目標
    public float TrackingSpeed;// 追跡速度

    public float TrackingCount;// 追跡秒数
    public float DestroyCount;// 追跡終了後からの削除時間
    bool TrackingFlag = true;// 追跡フラグ

    //-------
    
    
    void Start()
    {
        PlayerTransfome = GameObject.FindGameObjectWithTag("Player").transform;// 追跡目標をTagで指定してます
        StartCoroutine(Tracking());
    }

    void Update()
    {
        TrackingCount -= Time.deltaTime;// 追跡秒数を1秒づつ減らしていく

        if (TrackingCount <= 0)// 追跡秒数が0秒以下になったら
        {
            TrackingFlag = false;
            //Debug.Log("とまったぁぁぁ！！");
            transform.Translate(Vector3.forward * Time.deltaTime * TrackingSpeed);
            Destroy(gameObject, DestroyCount);
        }

    }

    IEnumerator Tracking()
    {
        while (TrackingFlag)
        {
            CrayonTransfome.LookAt(PlayerTransfome);// プレイヤーの方向に向くようにしている

            // MoveTowardsで目標座標を指定し、そこに向けてこのオブジェクトを動かしている
            transform.position = Vector3.MoveTowards
                (transform.position, new Vector3(PlayerTransfome.position.x, PlayerTransfome.position.y, PlayerTransfome.position.z), TrackingSpeed * Time.deltaTime);

            yield return new WaitForSeconds(0);
        }
    }


}
