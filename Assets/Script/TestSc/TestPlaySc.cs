using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestPlaySc : MonoBehaviour
{
    [SerializeField] GameObject LectureSpriteObgect;
    [SerializeField] GameObject testConfigGroup;
    [SerializeField] Text playerSpeedTx;
    [SerializeField] Text EnemyShootSpeedTx;
    [SerializeField] Text enemyIntervalTx;
    [SerializeField] Text cameraSensiTx;

    [SerializeField] PlayerMove playerMoveSc;

    [SerializeField] turretQuo turretQuotanionSc;

    //一度atkSpeedに数値を持たせ、そこからEnAtcanonScに渡す。
    [SerializeField] EnemyATK_StraightShoot EnAtcanonSc;
    float atkSpeed;

    //対空の敵
    bool floatEnemySW;
    [SerializeField] GameObject floatEnemysObj_1;
    [SerializeField] GameObject floatEnemysObj_2;

    //インジゲーター
    bool indicatorSW;
    [SerializeField] GameObject indicatorTrigger;
    [SerializeField] GameObject indicatorSprite_1;
    [SerializeField] GameObject indicatorSprite_2;

    //プレイヤーの視点操作用
    [SerializeField] PlayerCameraControll playerCamerasensi;
    void Start()
    {
        atkSpeed = 0.25f;//shootspeed基準
        LectureSpriteObgect.SetActive(false);
        testConfigGroup.SetActive(false);
        floatEnemysObj_1.SetActive(false);
        indicatorTrigger.SetActive(false);

    }

    
    void Update()
    {
        EnAtcanonSc.shootSpeed = atkSpeed;
        //F1を押すとレクチャー起動。
        if (Input.GetKey(KeyCode.F1))
        {
            LectureSpriteObgect.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.F1)) LectureSpriteObgect.SetActive(false);

        if (Input.GetKey(KeyCode.O))
        {
            testConfigGroup.SetActive(true);
            
            //プレイヤーの移動速度
            if (Input.GetKeyDown(KeyCode.Alpha1)) playerMoveSc.speed += 2.0f;
            if (Input.GetKeyDown(KeyCode.Alpha2)) playerMoveSc.speed -= 2.0f;
            playerSpeedTx.text = string.Format("{0:0}", playerMoveSc.speed);
            //敵の攻撃発射間隔
            if (Input.GetKeyDown(KeyCode.Alpha3)) turretQuotanionSc.shotIntervalSpeed += 0.1f;
            if (Input.GetKeyDown(KeyCode.Alpha4)) turretQuotanionSc.shotIntervalSpeed -= 0.1f;
            enemyIntervalTx.text = string.Format("{0:0.0}", turretQuotanionSc.shotIntervalSpeed);


            //敵の攻撃の弾速
            if (Input.GetKeyDown(KeyCode.Alpha5)) atkSpeed += 0.01f;
            if (Input.GetKeyDown(KeyCode.Alpha6)) atkSpeed -= 0.01f;
            //atkspeedの数字をEnAtのshootspeedに入れる。
            
            EnemyShootSpeedTx.text = string.Format("{0:0.00}", EnAtcanonSc.shootSpeed);

            //
            if(Input.GetKeyDown(KeyCode.Alpha0) && floatEnemySW == false)
            {
                floatEnemySW = true;
                floatEnemysObj_1.SetActive(true);
                floatEnemysObj_2.SetActive(true);
            }
            else if(Input.GetKeyDown(KeyCode.Alpha0) && floatEnemySW == true)
            {
                floatEnemySW = false;
                floatEnemysObj_1.SetActive(false);
                floatEnemysObj_2.SetActive(false);
            }

            //9を押す度にインジゲーターのonoffを切り替える。
            if (Input.GetKeyDown(KeyCode.Alpha9) && indicatorSW == false)
            {
                indicatorSW = true;
                indicatorTrigger.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9) && indicatorSW == true)
            {
                indicatorSW = false;
                indicatorTrigger.SetActive(false);
                indicatorSprite_1.SetActive(false);
                indicatorSprite_2.SetActive(false);
            }

            //z,xキーを押すとCamera軸xの数値を変更出来る
            if (Input.GetKeyDown(KeyCode.Z)) playerCamerasensi.x_sensi += 1.0f;
            if (Input.GetKeyDown(KeyCode.X)) playerCamerasensi.x_sensi -= 1.0f;
            cameraSensiTx.text = string.Format("{0:0.0}", playerCamerasensi.x_sensi);
        }
        else if (Input.GetKeyUp(KeyCode.O)) testConfigGroup.SetActive(false);

        //ESCを押すとゲームを終了させる。
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        
    }
}
