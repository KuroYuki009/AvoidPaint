using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrayonSpown : MonoBehaviour
{
    // ����̓v���C���[�ɂ��Ă���X�N���v�g�ł�!!!!!!!!!!!!!!!!


    public GameObject CrayonObject;// �X�|�[��������N���������Ԃ�����
    public float CrayonSpownCount;// �N�������̃X�|�[���Ԋu�����߂�


    void Start()
    {
        StartCoroutine(CrayonSpown());
    }

    void Update()
    {
        
    }

    IEnumerator CrayonSpown()
    {
        while (true)
        {
            // �v���n�u�̈ʒu�������_���Őݒ�
            float x = Random.Range(-0.6f, 0.6f);
            float z = Random.Range(-0.5f, 0.5f);
            Vector3 pos = new Vector3(x, 0, z);

            // �v���n�u�𐶐�
            Instantiate(CrayonObject, pos, Quaternion.identity);

            // �����ŃN�������̃X�|�[���Ԋu�����߂Ă�
            yield return new WaitForSeconds(CrayonSpownCount);
        }
    }

    
}
