using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ULTController : MonoBehaviour
{
    //public int ULT_Count;// ULTカウント
    //オブジェクト
    public GameObject ULT_object;
    MeshRenderer ultObj_MR;
    //ultSW。使用後はtureになる。
    bool ultSW = true;
    public SphereCollider ULT_Collider;// ULTの当たり判定
    //private int ULT_Time = 10;// ULTのサイズ
    float timeTimeScale = 0.0f;

    //一度で消した個数
    int deleteValue;

    //インゲームマネージャー
    [SerializeField]InGameManager ingamemanagersd;

    //エネミースポナーからdifficalを元に戻すようにする。
    [SerializeField] EnemySpawnSc enemyspawnnd;

    [SerializeField]PlayerStatus playerstatus;

    void Start()
    {
        ultObj_MR = ULT_object.GetComponent<MeshRenderer>();
        ultObj_MR.enabled = false;
    }

    void Update()
    {
        if (timeTimeScale <= 3.0f && ultSW == false)// 時間を加算し、それに合わせてオブジェクトのサイズを大きくする。
        {
            timeTimeScale += 1 * Time.deltaTime;
            ULT_object.gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        }
        else if (timeTimeScale >= 1.0f && ultSW == false)
        {
            ULT_object.gameObject.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
            ultObj_MR.enabled = false;

            //消した個数に応じた時間追加。1つ消すごとに1秒追加。
            ingamemanagersd.GameTimeCount += (0.5f * deleteValue);

            //集計用の変数に追加。
            ingamemanagersd.inGameDeleteObject += deleteValue;

            //消したオブジェクトに応じて difficultyレベルを低下させる。
            if(deleteValue <= 40)// 40以上だと
            {
                enemyspawnnd.difficultyLevel -= 3;// 3段階減少させ。
            }
            else enemyspawnnd.difficultyLevel -= 2; // それ以外だと2段階減少させる。

            enemyspawnnd.BearSpawnRefresh();// お邪魔キャラのクマのスポーンする条件に当てはまるかを確認する。

            ULT_Collider.enabled = false;

            playerstatus.playerSt_HP += 10.0f;//プレイヤーの体力を少し回復させる。

            deleteValue = 0;// カウント数の初期化。
            ingamemanagersd.stopGameTimeSW = false;
            ultSW = true;
        }
    }

    public void ULTooooo()// ULTを開始する為の関数。
    {
        timeTimeScale = 0;
        ingamemanagersd.stopGameTimeSW = true;
        ultObj_MR.enabled = true;
        ultSW = false;// ULTの処理起動。
    }

    private void OnTriggerEnter(Collider other)// 何かしらとの接触時の処理。
    {
        if (other.tag == "Enemy" || other.tag == "EnemyAttack")// もし当たった相手のタグがEnemyもしくはEnemyAttackだったらどうする？
        {
            deleteValue += 1;// カウントを増加させる。
            Destroy(other.gameObject);// 消す。
        }
    }
}
