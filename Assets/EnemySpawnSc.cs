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
    int playerstageRondomNamber;
    Vector3 playerstageSpawnVc3;
    void Start()
    {
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
             /* case 3:
                    PlayerStageCrayonCautionEffect();
                    iventSW = true;
                    break;
                case 4:
                    PlayerStageCrayonCautionEffect();
                    iventSW = true;
                    break; */
                default:
                    //未選択時。
                    break;
            }
        }
        
        //試験的。押すと敵が沸く。
        /* if (Input.GetButtonDown("Jump"))
        {
            ChairStageSpawn();
            PlayerStageCautionEffect();
        } */
        if(iventTime <= 10.0f - difficultyLevel)
        {
            iventTime += 1.0f * Time.deltaTime;
        }
        else if(iventTime >= 10.0f - difficultyLevel)
        {
            iventSW = false;
            randomizer = Random.Range(0, 3);//ランダマイザ―の範囲の選択
            iventTime = 0.0f;
            
        }

        //自然時間からdifficultyレベルを設定する。難易度値が５以上の場合は増えない。
        diffiRollTimer += Time.deltaTime * 1;
        if(diffiRollTimer >= 10.0f && difficultyLevel <= 5)
        {
            difficultyLevel += 1;
            diffiRollTimer = 0;
        }
        else if(diffiRollTimer >= 10.0f) diffiRollTimer = 0;

        //difficultyが3以上だとクマがbombを投げてくるようになる。
        if (difficultyLevel >= 5)
        {
            enemyObject_Bear_3.SetActive(true);
        }
        if (difficultyLevel >= 4)
        {
            enemyObject_Bear_2.SetActive(true);
        }
        if (difficultyLevel >= 3)
        {
            enemyObject_Bear_1.SetActive(true);
        }

        if(difficultyLevel <= 3)
        {
            enemyObject_Bear_1.SetActive(false);
            enemyObject_Bear_2.SetActive(false);
            enemyObject_Bear_3.SetActive(false);
        }

    }

    void PlayerStageCautionEffect()
    {
        //登録されている沸き場所指定用の空オブジェクトの数を取得し、そこからランダムな数字を割り出す。
        playerstageRondomNamber = Random.Range(0, PlayerStageEnemySpawner.Length);
        playerstageSpawnVc3 = PlayerStageEnemySpawner[playerstageRondomNamber].transform.position;
        //割り出された数字を使いエフェクトを発生させる
        PlayerStageEnemySpawner_cautionEffect[playerstageRondomNamber].SetTrigger("cautionEffect");
        Debug.Log("机で沸きます");
    }
    void PlayerStageCrayonCautionEffect()
    {
        //登録されている沸き場所指定用の空オブジェクトの数を取得し、そこからランダムな数字を割り出す。
        playerstageRondomNamber = Random.Range(0, PlayerStageCrayonEnemySpawner.Length);
        playerstageSpawnVc3 = PlayerStageCrayonEnemySpawner[playerstageRondomNamber].transform.position;
        //割り出された数字を使いエフェクトを発生させる
        PlayerStageCrayonEnemySpawner_cautionEffect[playerstageRondomNamber].SetTrigger("cautionEffect");
        Debug.Log("机で沸きます");
    }

    public void PlayerStageInSpawn_paint()//プレイヤーの居るステージ上にスポーン。
    {
        Instantiate(enemyObject_Paint, playerstageSpawnVc3, transform.rotation, playerstageExistenceEnemysObj.transform);
    }
    public void PlayerStageInSpawn_crayon()//プレイヤーの居るステージ上にスポーン。
    {
        Instantiate(enemyObject_Crayon, playerstageSpawnVc3, transform.rotation, playerstageExistenceEnemysObj.transform);
    }

    public void ChairStageSpawn()//椅子の背もたれ上にスポーン。
    {
        int chairRondomNamber = Random.Range(0, ChairStageEnemySpawner.Length);
        Vector3 chairSpawnVc3 = ChairStageEnemySpawner[chairRondomNamber].transform.position;
        Instantiate(enemyObject_Paint, chairSpawnVc3, transform.rotation, chairExistenceEnemysObj.transform);
        Debug.Log("椅子に沸きます");
    }

}
