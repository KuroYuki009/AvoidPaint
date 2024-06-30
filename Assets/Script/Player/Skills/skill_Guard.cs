using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class skill_Guard : MonoBehaviour
{
    //指定されたボタンを押すとプレイヤーの持っているinvisibleModeを起動し、ダメージを受けなくなる。

    [SerializeField] float guardTimeScarl;

    [SerializeField] float guardCoolTime;

    bool selftySW;

    [SerializeField]private GameObject imageUI;

    //プレイヤーにアタッチされているPlayerStatusを使用する。
    [SerializeField] private PlayerStatus playerstateusSc;

    //クールタイム時間を表記する為のテキストをアタッチ
    [SerializeField]private Text cooltimeText;

    [SerializeField] private Image ui_GuardFill;

    //ーーーーー
    //CamFace用
    float transparent;

    [SerializeField] Image camFacsImage;

    //se
    AudioSource audioSource;
    [SerializeField]AudioClip use_SE;
    bool seSW;
    void Start()
    {
        playerstateusSc = GetComponent<PlayerStatus>();
        audioSource = GetComponent<AudioSource>();
        GuardReboot();
        //体力バー下のLine表記
        imageUI.SetActive(false);

        //ーーーーー
        //CamFace用

        transparent = 0.0f;
        camFacsImage.color = new Color(1, 1, 1, transparent);
    }


    void Update()
    {
        ui_GuardFill.fillAmount = guardTimeScarl / 1.0f;//guardTimeScarlと同じ数字で割る。

        //最大値(1.0f)を超えたら最大値を返す。
        transparent = System.Math.Min(transparent, 1.0f);
        //最小値(0.0f)を下回ったら最小値を返す。
        transparent = System.Math.Max(transparent, 0.0f);
        
        if (Input.GetButton("Fire1") && guardTimeScarl >= 0.0f && selftySW == false)//AND式
        {
            imageUI.SetActive(true);

            //playerStatus内のbool関数を真に入れる。
            playerstateusSc.playerGuardBool = true;

            //guardTimeScarl中の数値をdeltatimeを使い1.0ずつマイナスしていく
            guardTimeScarl -= 1.0f * Time.deltaTime;


            //CamFaceを数値を徐々に上げる。
            camFacsImage.color = new Color(1, 1, 1, transparent);

            if(seSW == false)
            {
                audioSource.PlayOneShot(use_SE);
                seSW = true;
            }

            transparent += 4.0f * Time.deltaTime;

        }
        else if (Input.GetButtonUp("Fire1") || guardTimeScarl <= 0.0f)//OR式
        {
            cooltimeText.enabled = true;
            guardTimeScarl = 0.0f;
            imageUI.SetActive(false);

            playerstateusSc.playerGuardBool = false;
            selftySW = true;
            if(seSW == true)
            {
                audioSource.Stop();
                seSW = false;
            }
        }

        if (selftySW == true && guardCoolTime >= 0.0f)
        {
            //guardCoolTime中の数値をdeltatimeを使い1.0ずつマイナスしていく
            guardCoolTime -= 1.0f * Time.deltaTime;
            //アタッチしたtextに数字を代入する。
            cooltimeText.text = string.Format("{0:0.0}",guardCoolTime);

            //CamFaceの数値を徐々に下げる。
            camFacsImage.color = new Color(1, 1, 1, transparent);

            transparent -= 4.0f * Time.deltaTime;
        }
        else if (guardCoolTime <= 0.0f)
        {
            GuardReboot();
        }
    }

    void GuardReboot()
    {
        selftySW = false;
        guardTimeScarl = 1.0f;
        guardCoolTime = 15.0f;

        cooltimeText.enabled = false;
    }
}
