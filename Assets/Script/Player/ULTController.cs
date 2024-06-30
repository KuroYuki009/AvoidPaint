using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ULTController : MonoBehaviour
{
    //public int ULT_Count;// ULTカウント
    //オブジェクト
    public GameObject ULT_object;
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

    private void Update()
    {
        if (timeTimeScale <= 3.0f && ultSW == false)
        {
            timeTimeScale += 1 * Time.deltaTime;
            ULT_object.gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        }
        else if (timeTimeScale >= 1.0f && ultSW == false)
        {
            ULT_object.gameObject.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
            //消した個数に応じた時間追加。1つ消すごとに1秒追加。
            ingamemanagersd.GameTimeCount += (0.5f * deleteValue);
            //集計用の変数に追加。
            ingamemanagersd.inGameDeleteObject += deleteValue;
            //difficultyレベルを低下させる。
            if(deleteValue <= 50)
            {
                enemyspawnnd.difficultyLevel -= 2;
            }
            else enemyspawnnd.difficultyLevel -= 1;

            ULT_Collider.enabled = false;
            enemyspawnnd.SendMessage("InGameCountTimer");
            deleteValue = 0;
            playerstatus.playerSt_HP += 10.0f;
            ultSW = true;
        }
    }
    public void ULTooooo()// ULT使った時
    {
        timeTimeScale = 0;
        ultSW = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "EnemyAttack")// もし当たった相手のタグがEnemyもしくはEnemyAttackだったらどうする？
        {
            deleteValue += 1;
            Destroy(other.gameObject);// お前を殺す
        }
    }
}
