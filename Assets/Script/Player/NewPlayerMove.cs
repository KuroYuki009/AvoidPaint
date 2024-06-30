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
    //�_�b�V��UI�֘A
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

        //�}�E�X�X�N���[���̓��͒l�B
        mouseScroll += 10.0f * (Input.GetAxis("MouseScrollWheel"));
        //�}�E�X�X�N���[���l�̍ő�l�ŏ��l��ݒ�B
        mouseScroll = Mathf.Clamp(mouseScroll, minScroll, maxScroll);
        //mouseScroll��float�l��int�l�ɕύX����B
        scrollVolume = (int)mouseScroll;

        //�W�����v(������)
        /*if(Input.GetButtonDown("Jump") && jumpSW == false)
        {
            Jump();
        }*/
        

        //�X�L���u�_�b�V���v���g�p����B
        if (Input.GetButtonDown("Fire2") && rb.velocity.magnitude != 0.0f && dashCoolTime <= 0.0f)
        {
            ForceDash();
        }
        //�z�C�[���{�^���������ƃz�C�[���l�����Z�b�g����B
        if (Input.GetButtonDown("Fire3"))
        {
            mouseScroll = 0.0f;
        }

        //dashcooltime�̐��l��0�ȏ��dashcoolSw���I���ɂȂ��Ă�ꍇ�ɐ��������炷�B
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
        // �J�����̕�������AX-Z���ʂ̒P�ʃx�N�g�����擾
        cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // �����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
        moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        // �ړ������ɃX�s�[�h(moveSpeed��scroll�l)���|����B�W�����v�◎��������ꍇ�́A�ʓrY�������̑��x�x�N�g���𑫂��B
        rb.velocity = moveForward * (moveSpeed + ((float)scrollVolume / 10.0f)) + new Vector3(0, rb.velocity.y, 0);

        // �L�����N�^�[�̌�����i�s������
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
    //�Q�l�ɂ����T�C�g
    //https://tech.pjin.jp/blog/2016/11/04/unity_skill_5/
}
