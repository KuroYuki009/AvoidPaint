using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ULTController : MonoBehaviour
{
    //public int ULT_Count;// ULT�J�E���g
    //�I�u�W�F�N�g
    public GameObject ULT_object;
    MeshRenderer ultObj_MR;
    //ultSW�B�g�p���ture�ɂȂ�B
    bool ultSW = true;
    public SphereCollider ULT_Collider;// ULT�̓����蔻��
    //private int ULT_Time = 10;// ULT�̃T�C�Y
    float timeTimeScale = 0.0f;

    //��x�ŏ�������
    int deleteValue;

    //�C���Q�[���}�l�[�W���[
    [SerializeField]InGameManager ingamemanagersd;

    //�G�l�~�[�X�|�i�[����diffical�����ɖ߂��悤�ɂ���B
    [SerializeField] EnemySpawnSc enemyspawnnd;

    [SerializeField]PlayerStatus playerstatus;

    void Start()
    {
        ultObj_MR = ULT_object.GetComponent<MeshRenderer>();
        ultObj_MR.enabled = false;
    }

    void Update()
    {
        if (timeTimeScale <= 3.0f && ultSW == false)// ���Ԃ����Z���A����ɍ��킹�ăI�u�W�F�N�g�̃T�C�Y��傫������B
        {
            timeTimeScale += 1 * Time.deltaTime;
            ULT_object.gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        }
        else if (timeTimeScale >= 1.0f && ultSW == false)
        {
            ULT_object.gameObject.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
            ultObj_MR.enabled = false;

            //���������ɉ��������Ԓǉ��B1�������Ƃ�1�b�ǉ��B
            ingamemanagersd.GameTimeCount += (0.5f * deleteValue);

            //�W�v�p�̕ϐ��ɒǉ��B
            ingamemanagersd.inGameDeleteObject += deleteValue;

            //�������I�u�W�F�N�g�ɉ����� difficulty���x����ቺ������B
            if(deleteValue <= 40)// 40�ȏゾ��
            {
                enemyspawnnd.difficultyLevel -= 3;// 3�i�K���������B
            }
            else enemyspawnnd.difficultyLevel -= 2; // ����ȊO����2�i�K����������B

            enemyspawnnd.BearSpawnRefresh();// ���ז��L�����̃N�}�̃X�|�[����������ɓ��Ă͂܂邩���m�F����B

            ULT_Collider.enabled = false;

            playerstatus.playerSt_HP += 10.0f;//�v���C���[�̗̑͂������񕜂�����B

            deleteValue = 0;// �J�E���g���̏������B
            ingamemanagersd.stopGameTimeSW = false;
            ultSW = true;
        }
    }

    public void ULTooooo()// ULT���J�n����ׂ̊֐��B
    {
        timeTimeScale = 0;
        ingamemanagersd.stopGameTimeSW = true;
        ultObj_MR.enabled = true;
        ultSW = false;// ULT�̏����N���B
    }

    private void OnTriggerEnter(Collider other)// ��������Ƃ̐ڐG���̏����B
    {
        if (other.tag == "Enemy" || other.tag == "EnemyAttack")// ����������������̃^�O��Enemy��������EnemyAttack��������ǂ�����H
        {
            deleteValue += 1;// �J�E���g�𑝉�������B
            Destroy(other.gameObject);// �����B
        }
    }
}
