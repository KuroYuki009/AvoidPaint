using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSc : MonoBehaviour
{
    //difficulty���x���B��{�I�Ɏ��Ԍo�߂ɂ��㏸�B�����_�����I�̎��ԒZ�k
    public int difficultyLevel;

    //
    float diffiRollTimer;
    //���[�v�^�C���B10�b�����ɃC�x���g�𔭐�������B
    float iventTime;
    int randomizer;
    bool iventSW;
    ////�G�̕����n�_����I�u�W�F�N�g�Őݒ�B-----
    //�X�|�[���n�_�uStage(��)�v
    [SerializeField] GameObject[] PlayerStageEnemySpawner;
    [SerializeField] Animator[] PlayerStageEnemySpawner_cautionEffect;
    //�X�|�[���n�_�uStage(��)�v�N�������p
    //�X�|�[���n�_�uStage(��)�v
    [SerializeField] GameObject[] PlayerStageCrayonEnemySpawner;
    [SerializeField] Animator[] PlayerStageCrayonEnemySpawner_cautionEffect;

    //�X�|�[���n�_�uChair�v
    [SerializeField] GameObject[] ChairStageEnemySpawner;


    ////�X�|�[��������G�L����-----
    //�G�uPaint�v
    [SerializeField] private GameObject enemyObject_Paint;
    //�G�uCrayon�v
    [SerializeField] private GameObject enemyObject_Crayon;

    //����G�uBear�v//difficulty��3�ȏ�łȂ��ƕ����Ȃ��B
    [SerializeField] private GameObject enemyObject_Bear_1;
    [SerializeField] private GameObject enemyObject_Bear_2;
    [SerializeField] private GameObject enemyObject_Bear_3;

    ////���������G�L�������w��̋�I�u�W�F�N�g�̎q�Ƃ��Ēǉ��B-----
    //�y�A�����g�I�u�W�F�N�g�uchairExistenceEnemys�v
    [SerializeField] private GameObject chairExistenceEnemysObj;

    //�y�A�����g�I�u�W�F�N�g�uchairExistenceEnemys�v
    [SerializeField] private GameObject playerstageExistenceEnemysObj;

    ////���̑��֐�---
    //
    int enemySpawnInt;
    Vector3 playerstageSpawnVc3;

    void Start()
    {
        // ��x�����V�[�h�l��b�������ɐݒ肷��B
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
                default:
                    //���I�����B
                    break;
            }
        }

        if(iventTime <= 10.0f - difficultyLevel)// �C�x���g�𔭐�������ۂɎg�p���鎞�Ԃ��v������B
        {
            iventTime += 1.0f * Time.deltaTime;
        }
        else if(iventTime >= 12.0f- difficultyLevel)// �ڕW�̎��ԂɒB�����ꍇ�A�����Ő��l������o������ɉ������C�x���g�����s����B
        {
            iventSW = false;
            randomizer = Random.Range(0, 3);//�����_�}�C�U�\�͈̔͂̑I��
            iventTime = 0.0f;
            
        }

        // ���R���Ԃ���difficulty���x����ݒ肷��B��Փx�l���T�ȏ�̏ꍇ�͑����Ȃ��B
        diffiRollTimer += Time.deltaTime * 1;

        if(diffiRollTimer >= 10.0f)
        {
            if (difficultyLevel < 5) difficultyLevel += 1;

            BearSpawnRefresh();
            diffiRollTimer = 0;

        }
        else if(diffiRollTimer >= 10.0f) diffiRollTimer = 0;

    }

    void PlayerStageCautionEffect()// �G�����̏�ɏo��������|�C���g���o�͂���Ƌ��Ɍx���\�����Đ�������B
    {
        //�o�^����Ă��镦���ꏊ�w��p�̋�I�u�W�F�N�g�̐����擾���A�������烉���_���Ȑ���������o���B
        enemySpawnInt = Random.Range(0, PlayerStageEnemySpawner.Length);
        playerstageSpawnVc3 = PlayerStageEnemySpawner[enemySpawnInt].transform.position;

        //����o���ꂽ�������g���G�t�F�N�g�𔭐�������
        PlayerStageEnemySpawner_cautionEffect[enemySpawnInt].SetTrigger("cautionEffect");
        Debug.Log("���ŕ����܂�");
    }


    void PlayerStageCrayonCautionEffect()// 
    {
        //�o�^����Ă��镦���ꏊ�w��p�̋�I�u�W�F�N�g�̐����擾���A�������烉���_���Ȑ���������o���B
        enemySpawnInt = Random.Range(0, PlayerStageCrayonEnemySpawner.Length);
        playerstageSpawnVc3 = PlayerStageCrayonEnemySpawner[enemySpawnInt].transform.position;

        //����o���ꂽ�������g���G�t�F�N�g�𔭐�������
        PlayerStageCrayonEnemySpawner_cautionEffect[enemySpawnInt].SetTrigger("cautionEffect");
        Debug.Log("���ŕ����܂�");
    }

    public void PlayerStageInSpawn_paint()// �v���C���[�̋���X�e�[�W��� �G�̋�� �X�|�[���B
    {
        Instantiate(enemyObject_Paint, playerstageSpawnVc3, transform.rotation, playerstageExistenceEnemysObj.transform);
    }

    public void PlayerStageInSpawn_crayon()// �v���C���[�̋���X�e�[�W��� �N�������� �X�|�[���B
    {
        Instantiate(enemyObject_Crayon, playerstageSpawnVc3, transform.rotation, playerstageExistenceEnemysObj.transform);
    }
    
    public void ChairStageSpawn()// �֎q�̔w�������� �G�̋�� �X�|�[���B
    {
        int chairRondomNamber = Random.Range(0, ChairStageEnemySpawner.Length);
        Vector3 chairSpawnVc3 = ChairStageEnemySpawner[chairRondomNamber].transform.position;
        Instantiate(enemyObject_Paint, chairSpawnVc3, transform.rotation, chairExistenceEnemysObj.transform);
        Debug.Log("�֎q�ɕ����܂�");
    }

    public void BearSpawnRefresh()// �N�}�̏o�������𖞂����Ă��邩���m�F����
    {
        //difficulty��3�ȏゾ�ƃN�}��bomb�𓊂��Ă���悤�ɂȂ�B
        if (difficultyLevel >= 5)
        {
            enemyObject_Bear_1.SetActive(true);
            enemyObject_Bear_2.SetActive(true);
            enemyObject_Bear_3.SetActive(true);
        }
        else if (difficultyLevel >= 4)
        {
            enemyObject_Bear_1.SetActive(true);
            enemyObject_Bear_2.SetActive(true);
            enemyObject_Bear_3.SetActive(false);
        }
        else if (difficultyLevel >= 3)
        {
            enemyObject_Bear_1.SetActive(true);
            enemyObject_Bear_2.SetActive(false);
            enemyObject_Bear_3.SetActive(false);
        }
        else if (difficultyLevel <= 3)
        {
            enemyObject_Bear_1.SetActive(false);
            enemyObject_Bear_2.SetActive(false);
            enemyObject_Bear_3.SetActive(false);
        }
    }
}
