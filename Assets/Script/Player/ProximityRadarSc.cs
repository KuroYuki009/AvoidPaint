using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityRadarSc : MonoBehaviour
{
    //�E�͈͓���Tag / EnemyAttack�����Ă���I�u�W�F�N�g���͈͓��ɓ���ƃA�^�b�`���ꂽ�摜���\�������B
    //�E�x���\���Ɏg�p���邱�Ƃ��o����
    //�\������摜
    [SerializeField] private GameObject indicatorSprite;

    void Start()
    {
        indicatorSprite.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "EnemyAttack")
        {
            indicatorSprite.SetActive(true);
            Debug.Log("COlllijhonEnemyAte!");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "EnemyAttack")
        {
            indicatorSprite.SetActive(false);
        }
    }
}
