using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSc : MonoBehaviour
{
    //difficultyレベル。基本的に時間経過による上昇。ランダム抽選の時間短縮
    public int difficultyLevel;

    //
    float diffiRollTimer;
    //ループタイム。10秒おきにイベントを発生させる。
    float iventTime;
    int randomizer;
    bool iventSW;
    ////敵の沸き地点を空オブジェクトで設定。-----
    //スポーン地点「Stage(机)」
    [SerializeField] GameObject[] PlayerStageEnemySpawner;
    [SerializeField] Animator[] PlayerStageEnemySpawner_cautionEffect;
    //スポーン地点「Stage(机)」クレヨン用
    //スポーン地点「Stage(机)」
    [SerializeField] GameObject[] PlayerStageCrayonEnemySpawner;
    [SerializeField] Animator[] PlayerStageCrayonEnemySpawner_cautionEffect;

    //スポーン地点「Chair」
    [SerializeField] GameObject[] ChairStageEnemySpawner;


    ////スポーンさせる敵キャラ-----
    //敵「Paint」
    [SerializeField] private GameObject enemyObject_Paint;
    //敵「Crayon」
    [SerializeField] private GameObject enemyObject_Crayon;

    //特殊敵「Bear」//difficultyが3以上でないと沸かない。
    [SerializeField] private GameObject enemyObject_Bear_1;
    [SerializeField] private GameObject enemyObject_Bear_2;
    [SerializeField] private GameObject enemyObject_Bear_3;

    ////生成した敵キャラを指定の空オブジェクトの子として追加。-----
    //ペアレントオブジェクト「chairExistenceEnemys」
    [SerializeField] private GameObject chairExistenceEnemysObj;

    //ペアレントオブジェクト「chairExistenceEnemys」
    [SerializeField] private GameObject playerstageExistenceEnemysObj;

    ////その他関数---
    //
    int enemySpawnInt;
    Vector3 playerstageSpawnVc3;

    void Start()
    {
        // 一度だけシード値を秒数を元に設定する。
        Random.InitState(System.DateTime.Now.Millisecond);
    }

    
    void Update()
    {
        if(iventSW == false)
        {
            switch (randomizer)
            {
                case 0:
                    PlayerStageCautionEffect();
                    iventSW = true;
                    break;
                case 1:
                    ChairStageSpawn();
                    iventSW = true;
                    break;
                case 2:
                    ChairStageSpawn();
                    iventSW = true;
                    break;
                default:
                    //未選択時。
                    break;
            }
        }

        if(iventTime <= 10.0f - difficultyLevel)// イベントを発生させる際に使用する時間を計測する。
        {
            iventTime += 1.0f * Time.deltaTime;
        }
        else if(iventTime >= 12.0f- difficultyLevel)// 目標の時間に達した場合、乱数で数値を割り出しそれに応じたイベントを実行する。
        {
            iventSW = false;
            randomizer = Random.Range(0, 3);//ランダマイザ―の範囲の選択
            iventTime = 0.0f;
            
        }

        // 自然時間からdifficultyレベルを設定する。難易度値が５以上の場合は増えない。
        diffiRollTimer += Time.deltaTime * 1;

        if(diffiRollTimer >= 10.0f)
        {
            if (difficultyLevel < 5) difficultyLevel += 1;

            BearSpawnRefresh();
            diffiRollTimer = 0;

        }
        else if(diffiRollTimer >= 10.0f) diffiRollTimer = 0;

    }

    void PlayerStageCautionEffect()// 敵を机の上に出現させるポイントを出力すると共に警告表示を再生させる。
    {
        //登録されている沸き場所指定用の空オブジェクトの数を取得し、そこからランダムな数字を割り出す。
        enemySpawnInt = Random.Range(0, PlayerStageEnemySpawner.Length);
        playerstageSpawnVc3 = PlayerStageEnemySpawner[enemySpawnInt].transform.position;

        //割り出された数字を使いエフェクトを発生させる
        PlayerStageEnemySpawner_cautionEffect[enemySpawnInt].SetTrigger("cautionEffect");
        Debug.Log("机で沸きます");
    }


    void PlayerStageCrayonCautionEffect()// 
    {
        //登録されている沸き場所指定用の空オブジェクトの数を取得し、そこからランダムな数字を割り出す。
        enemySpawnInt = Random.Range(0, PlayerStageCrayonEnemySpawner.Length);
        playerstageSpawnVc3 = PlayerStageCrayonEnemySpawner[enemySpawnInt].transform.position;

        //割り出された数字を使いエフェクトを発生させる
        PlayerStageCrayonEnemySpawner_cautionEffect[enemySpawnInt].SetTrigger("cautionEffect");
        Debug.Log("机で沸きます");
    }

    public void PlayerStageInSpawn_paint()// プレイヤーの居るステージ上に 絵の具を スポーン。
    {
        Instantiate(enemyObject_Paint, playerstageSpawnVc3, transform.rotation, playerstageExistenceEnemysObj.transform);
    }

    public void PlayerStageInSpawn_crayon()// プレイヤーの居るステージ上に クレヲンを スポーン。
    {
        Instantiate(enemyObject_Crayon, playerstageSpawnVc3, transform.rotation, playerstageExistenceEnemysObj.transform);
    }
    
    public void ChairStageSpawn()// 椅子の背もたれ上に 絵の具を スポーン。
    {
        int chairRondomNamber = Random.Range(0, ChairStageEnemySpawner.Length);
        Vector3 chairSpawnVc3 = ChairStageEnemySpawner[chairRondomNamber].transform.position;
        Instantiate(enemyObject_Paint, chairSpawnVc3, transform.rotation, chairExistenceEnemysObj.transform);
        Debug.Log("椅子に沸きます");
    }

    public void BearSpawnRefresh()// クマの出現条件を満たしているかを確認する
    {
        //difficultyが3以上だとクマがbombを投げてくるようになる。
        if (difficultyLevel >= 5)
        {
            enemyObject_Bear_1.SetActive(true);
            enemyObject_Bear_2.SetActive(true);
            enemyObject_Bear_3.SetActive(true);
        }
        else if (difficultyLevel >= 4)
        {
            enemyObject_Bear_1.SetActive(true);
            enemyObject_Bear_2.SetActive(true);
            enemyObject_Bear_3.SetActive(false);
        }
        else if (difficultyLevel >= 3)
        {
            enemyObject_Bear_1.SetActive(true);
            enemyObject_Bear_2.SetActive(false);
            enemyObject_Bear_3.SetActive(false);
        }
        else if (difficultyLevel <= 3)
        {
            enemyObject_Bear_1.SetActive(false);
            enemyObject_Bear_2.SetActive(false);
            enemyObject_Bear_3.SetActive(false);
        }
    }
}
