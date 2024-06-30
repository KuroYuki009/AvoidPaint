using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestPlaySc : MonoBehaviour
{
    [SerializeField] GameObject LectureSpriteObgect;
    [SerializeField] GameObject testConfigGroup;
    [SerializeField] Text playerSpeedTx;
    [SerializeField] Text EnemyShootSpeedTx;
    [SerializeField] Text enemyIntervalTx;
    [SerializeField] Text cameraSensiTx;

    [SerializeField] PlayerMove playerMoveSc;

    [SerializeField] turretQuo turretQuotanionSc;

    //��xatkSpeed�ɐ��l���������A��������EnAtcanonSc�ɓn���B
    [SerializeField] EnemyATK_StraightShoot EnAtcanonSc;
    float atkSpeed;

    //�΋�̓G
    bool floatEnemySW;
    [SerializeField] GameObject floatEnemysObj_1;
    [SerializeField] GameObject floatEnemysObj_2;

    //�C���W�Q�[�^�[
    bool indicatorSW;
    [SerializeField] GameObject indicatorTrigger;
    [SerializeField] GameObject indicatorSprite_1;
    [SerializeField] GameObject indicatorSprite_2;

    //�v���C���[�̎��_����p
    [SerializeField] PlayerCameraControll playerCamerasensi;
    void Start()
    {
        atkSpeed = 0.25f;//shootspeed�
        LectureSpriteObgect.SetActive(false);
        testConfigGroup.SetActive(false);
        floatEnemysObj_1.SetActive(false);
        indicatorTrigger.SetActive(false);

    }

    
    void Update()
    {
        EnAtcanonSc.shootSpeed = atkSpeed;
        //F1�������ƃ��N�`���[�N���B
        if (Input.GetKey(KeyCode.F1))
        {
            LectureSpriteObgect.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.F1)) LectureSpriteObgect.SetActive(false);

        if (Input.GetKey(KeyCode.O))
        {
            testConfigGroup.SetActive(true);
            
            //�v���C���[�̈ړ����x
            if (Input.GetKeyDown(KeyCode.Alpha1)) playerMoveSc.speed += 2.0f;
            if (Input.GetKeyDown(KeyCode.Alpha2)) playerMoveSc.speed -= 2.0f;
            playerSpeedTx.text = string.Format("{0:0}", playerMoveSc.speed);
            //�G�̍U�����ˊԊu
            if (Input.GetKeyDown(KeyCode.Alpha3)) turretQuotanionSc.shotIntervalSpeed += 0.1f;
            if (Input.GetKeyDown(KeyCode.Alpha4)) turretQuotanionSc.shotIntervalSpeed -= 0.1f;
            enemyIntervalTx.text = string.Format("{0:0.0}", turretQuotanionSc.shotIntervalSpeed);


            //�G�̍U���̒e��
            if (Input.GetKeyDown(KeyCode.Alpha5)) atkSpeed += 0.01f;
            if (Input.GetKeyDown(KeyCode.Alpha6)) atkSpeed -= 0.01f;
            //atkspeed�̐�����EnAt��shootspeed�ɓ����B
            
            EnemyShootSpeedTx.text = string.Format("{0:0.00}", EnAtcanonSc.shootSpeed);

            //
            if(Input.GetKeyDown(KeyCode.Alpha0) && floatEnemySW == false)
            {
                floatEnemySW = true;
                floatEnemysObj_1.SetActive(true);
                floatEnemysObj_2.SetActive(true);
            }
            else if(Input.GetKeyDown(KeyCode.Alpha0) && floatEnemySW == true)
            {
                floatEnemySW = false;
                floatEnemysObj_1.SetActive(false);
                floatEnemysObj_2.SetActive(false);
            }

            //9�������x�ɃC���W�Q�[�^�[��onoff��؂�ւ���B
            if (Input.GetKeyDown(KeyCode.Alpha9) && indicatorSW == false)
            {
                indicatorSW = true;
                indicatorTrigger.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9) && indicatorSW == true)
            {
                indicatorSW = false;
                indicatorTrigger.SetActive(false);
                indicatorSprite_1.SetActive(false);
                indicatorSprite_2.SetActive(false);
            }

            //z,x�L�[��������Camera��x�̐��l��ύX�o����
            if (Input.GetKeyDown(KeyCode.Z)) playerCamerasensi.x_sensi += 1.0f;
            if (Input.GetKeyDown(KeyCode.X)) playerCamerasensi.x_sensi -= 1.0f;
            cameraSensiTx.text = string.Format("{0:0.0}", playerCamerasensi.x_sensi);
        }
        else if (Input.GetKeyUp(KeyCode.O)) testConfigGroup.SetActive(false);

        //ESC�������ƃQ�[�����I��������B
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        
    }
}
