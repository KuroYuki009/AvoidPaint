using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewPlayerMove : MonoBehaviour
{
    public float inputHorizontal;
    public float inputVertical;
    Rigidbody rb;

    public float moveSpeed = 0.5f;
    //[SerializeField]float jumpPower = 2.0f;
    //bool jumpSW = false;

    Vector3 cameraForward;
    Vector3 moveForward;

    //MouseScrollInput
    [SerializeField]private float mouseScroll = 0.0f;
    float maxScroll = 2f;
    float minScroll = -2f;
    [SerializeField]private int scrollVolume;

    //skill_dash
    float forcePower = 10.0f;
    //ダッシュUI関連
    [SerializeField] Image ui_DashFill;
    [SerializeField] Text cooltimeText;
    float dashCoolTime;
    bool dashCoolSW;

    //se
    AudioSource audioSource;
    [SerializeField] AudioClip use_SE;
    void Start()
    {
        moveSpeed = 0.5f;
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        cooltimeText.enabled = false;
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        //マウススクロールの入力値。
        mouseScroll += 10.0f * (Input.GetAxis("MouseScrollWheel"));
        //マウススクロール値の最大値最小値を設定。
        mouseScroll = Mathf.Clamp(mouseScroll, minScroll, maxScroll);
        //mouseScrollのfloat値をint値に変更する。
        scrollVolume = (int)mouseScroll;

        //ジャンプ(未完成)
        /*if(Input.GetButtonDown("Jump") && jumpSW == false)
        {
            Jump();
        }*/
        

        //スキル「ダッシュ」を使用する。
        if (Input.GetButtonDown("Fire2") && rb.velocity.magnitude != 0.0f && dashCoolTime <= 0.0f)
        {
            ForceDash();
        }
        //ホイールボタンを押すとホイール値をリセットする。
        if (Input.GetButtonDown("Fire3"))
        {
            mouseScroll = 0.0f;
        }

        //dashcooltimeの数値が0以上でdashcoolSwがオンになってる場合に数字を減らす。
        if(dashCoolTime >= 0.0 && dashCoolSW == true)
        {
            dashCoolTime -= 1.0f * Time.deltaTime;
            cooltimeText.text = string.Format("{0:0.0}", dashCoolTime);

        }
        else if(dashCoolTime <= 0.0f && dashCoolSW == true)
        {
            cooltimeText.enabled = false;
            ui_DashFill.enabled = true;
            dashCoolSW = false;
        }

    }

    void FixedUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        // 移動方向にスピード(moveSpeedとscroll値)を掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = moveForward * (moveSpeed + ((float)scrollVolume / 10.0f)) + new Vector3(0, rb.velocity.y, 0);

        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }

    void ForceDash()
    {
        cooltimeText.enabled = true;
        ui_DashFill.enabled = false;
        dashCoolSW = true;

        dashCoolTime = 3.0f;
        Vector3 force = moveForward * forcePower;
        rb.AddForce(force, ForceMode.Impulse);
        Debug.Log(force);
        audioSource.PlayOneShot(use_SE);
    }

    /*void Jump()
    {
        Vector3 force = new Vector3(0,jumpPower,0);
        rb.AddForce(force, ForceMode.Impulse);
        Debug.Log(force);
    }*/
    //参考にしたサイト
    //https://tech.pjin.jp/blog/2016/11/04/unity_skill_5/
}
