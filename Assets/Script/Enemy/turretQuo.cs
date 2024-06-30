using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretQuo : MonoBehaviour
{
    //
    public GameObject target;
    [SerializeField]private GameObject ShootObject;

    [SerializeField] GameObject shootPos;

    Quaternion lookRotation;

    [SerializeField] float timeloop;

    public float shotIntervalSpeed;

    //生成したオブジェクトをアタッチした空オブジェクトの子として追加する。
    [SerializeField]private GameObject parentObject;

    //モデルからアニメーターを取得
    [SerializeField] private GameObject charaModel;
    private void Start()
    {
        target = GameObject.Find("playablePlayer");
        parentObject = GameObject.Find("Parent_EnemyATKObjects");
        shotIntervalSpeed = 2.5f;
    }
    private void FixedUpdate()
    {
        lookRotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);

        //lookRotation.z = 0;
        //lookRotation.x = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.3f);

        //Vector3 p = new Vector3(0f, 0f, 0.08f);

        //transform.Translate(p);

        if (timeloop <= shotIntervalSpeed)
        {
            timeloop += 1.0f * Time.deltaTime; //発射区間の設定
        }
        else if(timeloop >= shotIntervalSpeed)
        {
            //モデルからアニメーターを取得しその中の攻撃アニメを再生。アニメーションの中でイベントトリガーを使用し攻撃を行う。
            charaModel.GetComponent<Animator>().SetTrigger("PaintAttack");
            //EnemyAttackShoot();
            timeloop = 0.0f;
        }


    }

    void EnemyAttackShoot()
    {
        Vector3 pos = shootPos.transform.position;

        Instantiate(ShootObject, pos, transform.rotation,parentObject.transform);


    }
}
