using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBear : MonoBehaviour
{
    public GameObject FiringPoint;// ���e�̔��ˏꏊ
                                  // 
    public GameObject Bom;// ���e

    public float speed;// �����鋭��

    public float throwSpeed;// �����銴�o
    private void Start()
    {
        Application.targetFrameRate = 60;
        StartCoroutine(BomShoot());
    }


    IEnumerator BomShoot()
    {
        

        while (true)
        {
            // �e�𔭎˂���ꏊ���擾
            Vector3 bulletPosition = FiringPoint.transform.position;

            // ��Ŏ擾�����ꏊ�ɁA"bullet"��Prefab���o��������
            GameObject newBom = Instantiate(Bom, bulletPosition, transform.rotation);

            // �o�����������e��forward(z������)
            Vector3 front = newBom.transform.forward;

            // �o�����������e��up(y������)
            Vector3 top = newBom.transform.up;

            // ���e�̔��˕�����newBall��y����(���[�J�����W)�����A���e��rigidbody�ɏՌ��͂�������
            newBom.GetComponent<Rigidbody>().AddForce(top * speed, ForceMode.Impulse);

            // ���e�̔��˕�����newBall��z����(���[�J�����W)�����A���e��rigidbody�ɏՌ��͂�������
            newBom.GetComponent<Rigidbody>().AddForce(front * speed,  ForceMode.Impulse);

            // ���e�𓊂��銴�o
            yield return new WaitForSeconds(throwSpeed);

            
        }


    }

}
