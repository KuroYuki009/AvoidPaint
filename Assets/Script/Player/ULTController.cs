using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ULTController : MonoBehaviour
{
    //public int ULT_Count;// ULT�J�E���g
    //�I�u�W�F�N�g
    public GameObject ULT_object;
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

    private void Update()
    {
        if (timeTimeScale <= 3.0f && ultSW == false)
        {
            timeTimeScale += 1 * Time.deltaTime;
            ULT_object.gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        }
        else if (timeTimeScale >= 1.0f && ultSW == false)
        {
            ULT_object.gameObject.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
            //���������ɉ��������Ԓǉ��B1�������Ƃ�1�b�ǉ��B
            ingamemanagersd.GameTimeCount += (0.5f * deleteValue);
            //�W�v�p�̕ϐ��ɒǉ��B
            ingamemanagersd.inGameDeleteObject += deleteValue;
            //difficulty���x����ቺ������B
            if(deleteValue <= 50)
            {
                enemyspawnnd.difficultyLevel -= 2;
            }
            else enemyspawnnd.difficultyLevel -= 1;

            ULT_Collider.enabled = false;
            enemyspawnnd.SendMessage("InGameCountTimer");
            deleteValue = 0;
            playerstatus.playerSt_HP += 10.0f;
            ultSW = true;
        }
    }
    public void ULTooooo()// ULT�g������
    {
        timeTimeScale = 0;
        ultSW = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "EnemyAttack")// ����������������̃^�O��Enemy��������EnemyAttack��������ǂ�����H
        {
            deleteValue += 1;
            Destroy(other.gameObject);// ���O���E��
        }
    }
}
