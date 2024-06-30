using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBom : MonoBehaviour
{
    
    public ParticleSystem Burst;// �����̃G�t�F�N�g������

    void Start()
    {
        StartCoroutine(BomBurst());
    }

    IEnumerator BomBurst()
    {
        yield return new WaitForSeconds(2f);// 2�b��ɉ��̏������J�n

        ParticleSystem BomParticle = Instantiate(Burst);// �܂������̃G�t�F�N�g�𐶐�����

        BomParticle.transform.position = this.transform.position;// �����G�t�F�N�g�����e�̈ʒu�ɐ��������悤�ɂ���

        Burst.Play();// �ق�Ŕ����G�t�F�N�g�Đ��J�n

        Destroy(gameObject);// �Đ��J�n�Ɠ����ɔ��e������
    }
}
