using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InGameManager : MonoBehaviour
{
    ////ゲームスコア
    public float inGameScore;
    //ultでの敵の弾の削除数
    public int inGameDeleteObject;

    //別シーンに受け渡す用の変数。
    public static float globalScore;
    public static float globalSuvivalTime;

    //ゲームが開始してからの自然経過時間。ゲームが始まり、終わるまで止まることなく計測する。
    public float neutralTime = 0.0f;

    ////StartingCountTime用変数
    //ゲームがスタートする前のカウントダウン用。
    [SerializeField] float StartingCount;

    ////InGameCountTimer用変数
    //ゲーム内の制限時間。
    public float GameTimeCount;
    [SerializeField] Text gametimecounterText;

    ////インスペクターからのアタッチ用。
    //UI「InGameCountDownTImer」
    [SerializeField] GameObject inGamecountTimerObj;

    //GameObject親「InGameScriptObjects」
    [SerializeField] GameObject inGameScriptObj;

    //GameObject親「playablePlayer」
    [SerializeField] GameObject playerObj;
    PlayerStatus playerstatus;

    //StartingCountDown用のUIスプライト表示用。( Imageコンポーネントで差し替えする手もあり )
    [SerializeField] GameObject standbyCountDown_3;
    [SerializeField] GameObject standbyCountDown_2;
    [SerializeField] GameObject standbyCountDown_1;
    [SerializeField] GameObject standbyCountDown_start;

    ////ゲームオーバー時の演出面
    //波状のスプライトあにま。
    [SerializeField] GameObject waveSpriteAnima;
    //プレイヤーがやられて、あにまが再生されるまでのディレイ。
    float delayTime = 2.0f;
    //あにまが最後まで終わるとこの変数にtrueが返される。よてい。
    public bool waveAnimaPassing = false;

    ////敵のスポーン関連
    [SerializeField] EnemySpawnSc Enemyspawnsc;

    string switchRoot = "";
    //Resultで一回だけ実行する際の。
    bool resultSW = false;
    //カットイベントを起こす。
    [SerializeField] Animator cutAnimator;

    //BGM
    AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;
    public bool[] countSE_SW;
    void Start()
    {
        playerstatus = playerObj.GetComponent<PlayerStatus>();
        GameSetUp();
        StartingCount = 4.5f;//カウントダウン３秒+余白時間１秒。
        GameTimeCount = 120.0f;//初期制限時間は120秒。要調整。
        audioSource = GetComponent<AudioSource>();
        //最初にcase:"StartingCountdown" を作動させる。作動させるとスタートカウントダウン。
        switchRoot = "StartingCountdown";
    }

    void Update()
    {
        switch (switchRoot)
        {
            case "StartingCountdown":
                StartingCountTime();              //ゲーム開始前のカウントダウンを開始する。
                break;
            case "InGameCountdown":
                InGameCountTimer();               //制限時間を作動させる。
                break;
            case "GameOver":
                GameOver();                       //専用のアニメーションを流し、Resultにスイッチする。
                break;
            case "TimeOver":
                TimeOver();                       //専用のアニメーションを流し、Resultにスイッチする。
                break;
            case "Result":
                Result();                         //保管されている数値を使い、リザルト画面をだす。
                break;
            default:
                Debug.Log("testでふぉると");      //未選択時。
                break;
        }
        
    }

    void GameSetUp()
    {

        //外部オブジェクトをあらかじめ無効化する。
        inGameScriptObj.SetActive(false);
        inGamecountTimerObj.SetActive(false);
        //Countobject類
        standbyCountDown_3.SetActive(false);
        standbyCountDown_2.SetActive(false);
        standbyCountDown_1.SetActive(false);
        standbyCountDown_start.SetActive(false);
    }

    void StartingCountTime()
    {
        //ゲームスタートまでカウントダウン。
        StartingCount -= 1.0f * Time.deltaTime;
        

        if(StartingCount <= 3.0f && StartingCount >= 2.0f)//３...
        {
            standbyCountDown_3.SetActive(true);
            //SEの再生
            if (countSE_SW[3] == false)
            {
                audioSource.PlayOneShot(audioClips[3]);
                countSE_SW[3] = true;
            }
            //Debug.Log("３");
        }

        if(StartingCount <= 2.0f && StartingCount >= 1.0f)//２...
        {
            standbyCountDown_3.SetActive(false);
            standbyCountDown_2.SetActive(true);
            //SEの再生
            if (countSE_SW[2] == false)
            {
                audioSource.PlayOneShot(audioClips[2]);
                countSE_SW[2] = true;
            }
            //Debug.Log("２");
        }

        if(StartingCount <= 1.0f && StartingCount >= 0.0f)//１...
        {
            standbyCountDown_2.SetActive(false);
            standbyCountDown_1.SetActive(true);
            //SEの再生
            if (countSE_SW[1] == false)
            {
                audioSource.PlayOneShot(audioClips[1]);
                countSE_SW[1] = true;
            }
            //Debug.Log("１");
        }

        if (StartingCount <= 0.0)//０...!
        {
            standbyCountDown_1.SetActive(false);
            standbyCountDown_start.SetActive(true);
            //SEの再生
            if (countSE_SW[0] == false)
            {
                audioSource.PlayOneShot(audioClips[0]);
                countSE_SW[0] = true;
            }
            //ゲームがスタート。
            Debug.Log("Start!");

            //UIであるInGameCountDownTimerを表示する。
            inGamecountTimerObj.SetActive(true);

            //// InGameScriptObjectsを起動する。以下のスクリプトオブジェクトが関連図けられている。
            // 敵の沸きをコントロールするスクリプトオブジェクト。
            // ULT用のアイテムの沸きをコントロール。
            inGameScriptObj.SetActive(true);

            //敵をプレイヤーステージの上に一体出現させる。
            //Enemyspawnsc.SendMessage("PlayerStageCautionEffect");

            //スイッチルートを"InGameCountdown"に変更。
            switchRoot = "InGameCountdown";
        }
    }

    void InGameCountTimer()
    {
        //経過時間を測る。
        neutralTime += 1.0f * Time.deltaTime;

        //開始してneutraltimeが2.0fになったら開始表示を無効化する。
        if(neutralTime >= 1.5f)
        {
            standbyCountDown_start.SetActive(false);
            //SEの再生。BGM
            if (countSE_SW[4] == false)
            {
                audioSource.PlayOneShot(audioClips[4]);
                countSE_SW[4] = true;
            }
        }

        //残り時間のカウントダウン。
        GameTimeCount -= 1.0f * Time.deltaTime;
        //カウントダウンをアタッチしたUI.Textに代入する。
        gametimecounterText.text = string.Format("{0:0}", GameTimeCount);

        //プレイヤーの体力が無くなるとスイッチルートを"GameOver"に変更する
        if(playerstatus.playerSt_HP <= 0.0f) switchRoot = "GameOver";

        //制限時間が0になると
        if (GameTimeCount <= 0.0f)
        {
            Debug.Log("げーむしゅうりょう！");
            switchRoot = "TimeOver";
        }
    }

    void GameOver()
    {
        //delayTimeが0.0f以下になるとwaveSpriteAnimaが有効になる。
        if(delayTime >= 0.0f)
        {
            delayTime -= 1.0f * Time.deltaTime;
        }
        else
        {
            waveSpriteAnima.SetActive(true);
        }

        if(waveAnimaPassing == true)
        {
            Debug.Log("げーむおーばー");
            switchRoot = "Result";
        }
    }

    void TimeOver()
    {
        playerObj.GetComponent<PlayerStatus>().playerGuardBool = true;//ガードスキルの無敵化用変数を使い無敵化する。
        Debug.Log("たいむおーばー");
        switchRoot = "Result";
    }

    void Result()
    {
        if(resultSW == false)
        {
            inGameScore += neutralTime;
            inGameScore += inGameDeleteObject;
            inGameScore += (2 * playerstatus.playerSt_HP);
            if(playerstatus.playerSt_HP <= 100.0f)
            {
                inGameScore += 100.0f;
            }

            //globalScoreは計算した数字を渡すようにする。
            globalScore = inGameScore;
            globalSuvivalTime = neutralTime;
            Debug.Log("りざると");
            cutAnimator.SetTrigger("CutOUT_LoadResult");
            
            resultSW = true;
        }
    }

}
