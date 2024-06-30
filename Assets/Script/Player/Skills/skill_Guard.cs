using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class skill_Guard : MonoBehaviour
{
    //�w�肳�ꂽ�{�^���������ƃv���C���[�̎����Ă���invisibleMode���N�����A�_���[�W���󂯂Ȃ��Ȃ�B

    [SerializeField] float guardTimeScarl;

    [SerializeField] float guardCoolTime;

    bool selftySW;

    [SerializeField]private GameObject imageUI;

    //�v���C���[�ɃA�^�b�`����Ă���PlayerStatus���g�p����B
    [SerializeField] private PlayerStatus playerstateusSc;

    //�N�[���^�C�����Ԃ�\�L����ׂ̃e�L�X�g���A�^�b�`
    [SerializeField]private Text cooltimeText;

    [SerializeField] private Image ui_GuardFill;

    //�[�[�[�[�[
    //CamFace�p
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
        //�̗̓o�[����Line�\�L
        imageUI.SetActive(false);

        //�[�[�[�[�[
        //CamFace�p

        transparent = 0.0f;
        camFacsImage.color = new Color(1, 1, 1, transparent);
    }


    void Update()
    {
        ui_GuardFill.fillAmount = guardTimeScarl / 1.0f;//guardTimeScarl�Ɠ��������Ŋ���B

        //�ő�l(1.0f)�𒴂�����ő�l��Ԃ��B
        transparent = System.Math.Min(transparent, 1.0f);
        //�ŏ��l(0.0f)�����������ŏ��l��Ԃ��B
        transparent = System.Math.Max(transparent, 0.0f);
        
        if (Input.GetButton("Fire1") && guardTimeScarl >= 0.0f && selftySW == false)//AND��
        {
            imageUI.SetActive(true);

            //playerStatus����bool�֐���^�ɓ����B
            playerstateusSc.playerGuardBool = true;

            //guardTimeScarl���̐��l��deltatime���g��1.0���}�C�i�X���Ă���
            guardTimeScarl -= 1.0f * Time.deltaTime;


            //CamFace�𐔒l�����X�ɏグ��B
            camFacsImage.color = new Color(1, 1, 1, transparent);

            if(seSW == false)
            {
                audioSource.PlayOneShot(use_SE);
                seSW = true;
            }

            transparent += 4.0f * Time.deltaTime;

        }
        else if (Input.GetButtonUp("Fire1") || guardTimeScarl <= 0.0f)//OR��
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
            //guardCoolTime���̐��l��deltatime���g��1.0���}�C�i�X���Ă���
            guardCoolTime -= 1.0f * Time.deltaTime;
            //�A�^�b�`����text�ɐ�����������B
            cooltimeText.text = string.Format("{0:0.0}",guardCoolTime);

            //CamFace�̐��l�����X�ɉ�����B
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
