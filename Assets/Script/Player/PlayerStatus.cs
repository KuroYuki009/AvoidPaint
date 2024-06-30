using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerStatus : MonoBehaviour
{
    //�v���C���[�̃q�b�g�|�C���g
    public float playerSt_HP;

    //���G��
    public bool invisibleMode;
    //���G���Ԃ̍ő�l
    [SerializeField]private float maxInvisiTime;
    //���G���Ԃ̊i�[�p�ϓ��ۗL�l�B
    float invisibleTime;
    
    //HPBer��UI
    [SerializeField] Image ui_playerHPber;

    //Skill�p�̊i�[�l

    //skill_Guard�̃K�[�h���̔�_���L��(ture�ŃK�[�h���)
    public bool playerGuardBool;

    //����Q
    skill_Guard guardSkillSc;
    NewPlayerMove playermoveSc;

    //�A�j���[�V����
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
        //�ϐ�playerSt_HP��0.0f�l����������ꍇ�ɑ���s�\�ɂȂ�B�C���Q�[���}�l�[�W���[�ŃV�[���̏z�Ȃǂ��s���E
        if (playerSt_HP <= 0.0f)
        {
            guardSkillSc.enabled = false;
            playermoveSc.enabled = false;

            modelanimator.SetBool("Idol", false);
            modelanimator.SetBool("RunAnima", false);
            modelanimator.SetBool("WalkAnima", false);
            modelanimator.SetBool("KnockOut",true);
            //�e�X�g�v���C�Ƃ��āA���񂾂�V�[���������[�h����B
            /* SceneManager.LoadScene(SceneManager.GetActiveScene().name); */
        }

    �@�@//���G���Ԃ̏����B
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

    //UI���X�V����B
    void PlayerUIUpdate()
    {
        ui_playerHPber.fillAmount = playerSt_HP / 100.0f;
    }


    //�Փ˂���GameObject���_���[�W�ϐ����������킹�Ă���ꍇ�Ƀ_���[�W��ǂݍ��ށB
    public void Damege(float damage)
    {
        if(invisibleMode == false && playerGuardBool == false)
        {
            playerSt_HP -= damage;
            PlayerUIUpdate();
        } 
    }
    //�Փ˂���GameObject�����G�����ϐ����������킹�Ă���ꍇ�Ƀv���C���[�ɖ��G���Ԃ𔭐�������B
    public void OnInvisible(bool invisible)
    {
        invisibleMode = true;
    }
}
