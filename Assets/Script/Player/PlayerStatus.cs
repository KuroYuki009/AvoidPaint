using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerStatus : MonoBehaviour
{
    //プレイヤーのヒットポイント
    public float playerSt_HP;

    //無敵化
    public bool invisibleMode;
    //無敵時間の最大値
    [SerializeField]private float maxInvisiTime;
    //無敵時間の格納用変動保有値。
    float invisibleTime;
    
    //HPBerのUI
    [SerializeField] Image ui_playerHPber;

    //Skill用の格納値

    //skill_Guardのガード時の被ダメ有無(tureでガード状態)
    public bool playerGuardBool;

    //操作群
    skill_Guard guardSkillSc;
    NewPlayerMove playermoveSc;

    //アニメーション
    [SerializeField]Animator modelanimator;

    //se

    void Start()
    {
        guardSkillSc = GetComponent<skill_Guard>();
        playermoveSc = GetComponent<NewPlayerMove>();
        playerSt_HP = 100.0f;
        ui_playerHPber.fillAmount = playerSt_HP / 100.0f;
        maxInvisiTime = 0.4f;
    }

    
    void Update()
    {
        //変数playerSt_HPが0.0f値を下回った場合に操作不能になる。インゲームマネージャーでシーンの循環などを行う・
        if (playerSt_HP <= 0.0f)
        {
            guardSkillSc.enabled = false;
            playermoveSc.enabled = false;

            modelanimator.SetBool("Idol", false);
            modelanimator.SetBool("RunAnima", false);
            modelanimator.SetBool("WalkAnima", false);
            modelanimator.SetBool("KnockOut",true);
            //テストプレイとして、死んだらシーンをリロードする。
            /* SceneManager.LoadScene(SceneManager.GetActiveScene().name); */
        }

    　　//無敵時間の処理。
        if(invisibleMode == true && invisibleTime >= 0.0f && playerGuardBool == false)
        {
            invisibleTime -= 1.0f * Time.deltaTime;
        }
        else if(invisibleTime <= 0.0f)
        {
            invisibleMode = false;
            invisibleTime = maxInvisiTime;
        }
    }

    //UIを更新する。
    void PlayerUIUpdate()
    {
        ui_playerHPber.fillAmount = playerSt_HP / 100.0f;
    }


    //衝突したGameObjectがダメージ変数を持ち合わせている場合にダメージを読み込む。
    public void Damege(float damage)
    {
        if(invisibleMode == false && playerGuardBool == false)
        {
            playerSt_HP -= damage;
            PlayerUIUpdate();
        } 
    }
    //衝突したGameObjectが無敵発生変数を持ち合わせている場合にプレイヤーに無敵時間を発生させる。
    public void OnInvisible(bool invisible)
    {
        invisibleMode = true;
    }
}
