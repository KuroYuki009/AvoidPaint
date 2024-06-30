using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InGameManager : MonoBehaviour
{
    ////�Q�[���X�R�A
    public float inGameScore;
    //ult�ł̓G�̒e�̍폜��
    public int inGameDeleteObject;

    //�ʃV�[���Ɏ󂯓n���p�̕ϐ��B
    public static float globalScore;
    public static float globalSuvivalTime;

    //�Q�[�����J�n���Ă���̎��R�o�ߎ��ԁB�Q�[�����n�܂�A�I���܂Ŏ~�܂邱�ƂȂ��v������B
    public float neutralTime = 0.0f;

    ////StartingCountTime�p�ϐ�
    //�Q�[�����X�^�[�g����O�̃J�E���g�_�E���p�B
    [SerializeField] float StartingCount;

    ////InGameCountTimer�p�ϐ�
    //�Q�[�����̐������ԁB
    public float GameTimeCount;
    [SerializeField] Text gametimecounterText;

    ////�C���X�y�N�^�[����̃A�^�b�`�p�B
    //UI�uInGameCountDownTImer�v
    [SerializeField] GameObject inGamecountTimerObj;

    //GameObject�e�uInGameScriptObjects�v
    [SerializeField] GameObject inGameScriptObj;

    //GameObject�e�uplayablePlayer�v
    [SerializeField] GameObject playerObj;
    PlayerStatus playerstatus;

    //StartingCountDown�p��UI�X�v���C�g�\���p�B( Image�R���|�[�l���g�ō����ւ����������� )
    [SerializeField] GameObject standbyCountDown_3;
    [SerializeField] GameObject standbyCountDown_2;
    [SerializeField] GameObject standbyCountDown_1;
    [SerializeField] GameObject standbyCountDown_start;

    ////�Q�[���I�[�o�[���̉��o��
    //�g��̃X�v���C�g���ɂ܁B
    [SerializeField] GameObject waveSpriteAnima;
    //�v���C���[������āA���ɂ܂��Đ������܂ł̃f�B���C�B
    float delayTime = 2.0f;
    //���ɂ܂��Ō�܂ŏI���Ƃ��̕ϐ���true���Ԃ����B��Ă��B
    public bool waveAnimaPassing = false;

    ////�G�̃X�|�[���֘A
    [SerializeField] EnemySpawnSc Enemyspawnsc;

    string switchRoot = "";
    //Result�ň�񂾂����s����ۂ́B
    bool resultSW = false;
    //�J�b�g�C�x���g���N�����B
    [SerializeField] Animator cutAnimator;

    //BGM
    AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;
    public bool[] countSE_SW;
    void Start()
    {
        playerstatus = playerObj.GetComponent<PlayerStatus>();
        GameSetUp();
        StartingCount = 4.5f;//�J�E���g�_�E���R�b+�]�����ԂP�b�B
        GameTimeCount = 120.0f;//�����������Ԃ�120�b�B�v�����B
        audioSource = GetComponent<AudioSource>();
        //�ŏ���case:"StartingCountdown" ���쓮������B�쓮������ƃX�^�[�g�J�E���g�_�E���B
        switchRoot = "StartingCountdown";
    }

    void Update()
    {
        switch (switchRoot)
        {
            case "StartingCountdown":
                StartingCountTime();              //�Q�[���J�n�O�̃J�E���g�_�E�����J�n����B
                break;
            case "InGameCountdown":
                InGameCountTimer();               //�������Ԃ��쓮������B
                break;
            case "GameOver":
                GameOver();                       //��p�̃A�j���[�V�����𗬂��AResult�ɃX�C�b�`����B
                break;
            case "TimeOver":
                TimeOver();                       //��p�̃A�j���[�V�����𗬂��AResult�ɃX�C�b�`����B
                break;
            case "Result":
                Result();                         //�ۊǂ���Ă��鐔�l���g���A���U���g��ʂ������B
                break;
            default:
                Debug.Log("test�łӂ����");      //���I�����B
                break;
        }
        
    }

    void GameSetUp()
    {

        //�O���I�u�W�F�N�g�����炩���ߖ���������B
        inGameScriptObj.SetActive(false);
        inGamecountTimerObj.SetActive(false);
        //Countobject��
        standbyCountDown_3.SetActive(false);
        standbyCountDown_2.SetActive(false);
        standbyCountDown_1.SetActive(false);
        standbyCountDown_start.SetActive(false);
    }

    void StartingCountTime()
    {
        //�Q�[���X�^�[�g�܂ŃJ�E���g�_�E���B
        StartingCount -= 1.0f * Time.deltaTime;
        

        if(StartingCount <= 3.0f && StartingCount >= 2.0f)//�R...
        {
            standbyCountDown_3.SetActive(true);
            //SE�̍Đ�
            if (countSE_SW[3] == false)
            {
                audioSource.PlayOneShot(audioClips[3]);
                countSE_SW[3] = true;
            }
            //Debug.Log("�R");
        }

        if(StartingCount <= 2.0f && StartingCount >= 1.0f)//�Q...
        {
            standbyCountDown_3.SetActive(false);
            standbyCountDown_2.SetActive(true);
            //SE�̍Đ�
            if (countSE_SW[2] == false)
            {
                audioSource.PlayOneShot(audioClips[2]);
                countSE_SW[2] = true;
            }
            //Debug.Log("�Q");
        }

        if(StartingCount <= 1.0f && StartingCount >= 0.0f)//�P...
        {
            standbyCountDown_2.SetActive(false);
            standbyCountDown_1.SetActive(true);
            //SE�̍Đ�
            if (countSE_SW[1] == false)
            {
                audioSource.PlayOneShot(audioClips[1]);
                countSE_SW[1] = true;
            }
            //Debug.Log("�P");
        }

        if (StartingCount <= 0.0)//�O...!
        {
            standbyCountDown_1.SetActive(false);
            standbyCountDown_start.SetActive(true);
            //SE�̍Đ�
            if (countSE_SW[0] == false)
            {
                audioSource.PlayOneShot(audioClips[0]);
                countSE_SW[0] = true;
            }
            //�Q�[�����X�^�[�g�B
            Debug.Log("Start!");

            //UI�ł���InGameCountDownTimer��\������B
            inGamecountTimerObj.SetActive(true);

            //// InGameScriptObjects���N������B�ȉ��̃X�N���v�g�I�u�W�F�N�g���֘A�}�����Ă���B
            // �G�̕������R���g���[������X�N���v�g�I�u�W�F�N�g�B
            // ULT�p�̃A�C�e���̕������R���g���[���B
            inGameScriptObj.SetActive(true);

            //�G���v���C���[�X�e�[�W�̏�Ɉ�̏o��������B
            //Enemyspawnsc.SendMessage("PlayerStageCautionEffect");

            //�X�C�b�`���[�g��"InGameCountdown"�ɕύX�B
            switchRoot = "InGameCountdown";
        }
    }

    void InGameCountTimer()
    {
        //�o�ߎ��Ԃ𑪂�B
        neutralTime += 1.0f * Time.deltaTime;

        //�J�n����neutraltime��2.0f�ɂȂ�����J�n�\���𖳌�������B
        if(neutralTime >= 1.5f)
        {
            standbyCountDown_start.SetActive(false);
            //SE�̍Đ��BBGM
            if (countSE_SW[4] == false)
            {
                audioSource.PlayOneShot(audioClips[4]);
                countSE_SW[4] = true;
            }
        }

        //�c�莞�Ԃ̃J�E���g�_�E���B
        GameTimeCount -= 1.0f * Time.deltaTime;
        //�J�E���g�_�E�����A�^�b�`����UI.Text�ɑ������B
        gametimecounterText.text = string.Format("{0:0}", GameTimeCount);

        //�v���C���[�̗̑͂������Ȃ�ƃX�C�b�`���[�g��"GameOver"�ɕύX����
        if(playerstatus.playerSt_HP <= 0.0f) switchRoot = "GameOver";

        //�������Ԃ�0�ɂȂ��
        if (GameTimeCount <= 0.0f)
        {
            Debug.Log("���[�ނ��イ��傤�I");
            switchRoot = "TimeOver";
        }
    }

    void GameOver()
    {
        //delayTime��0.0f�ȉ��ɂȂ��waveSpriteAnima���L���ɂȂ�B
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
            Debug.Log("���[�ނ��[�΁[");
            switchRoot = "Result";
        }
    }

    void TimeOver()
    {
        playerObj.GetComponent<PlayerStatus>().playerGuardBool = true;//�K�[�h�X�L���̖��G���p�ϐ����g�����G������B
        Debug.Log("�����ނ��[�΁[");
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

            //globalScore�͌v�Z����������n���悤�ɂ���B
            globalScore = inGameScore;
            globalSuvivalTime = neutralTime;
            Debug.Log("�肴���");
            cutAnimator.SetTrigger("CutOUT_LoadResult");
            
            resultSW = true;
        }
    }

}
