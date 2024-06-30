using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrayon : MonoBehaviour
{
    public Transform CrayonTransfome;// ������Transfome�����B

    Transform PlayerTransfome;// �ǐՖڕW
    public float TrackingSpeed;// �ǐՑ��x

    public float TrackingCount;// �ǐՕb��
    public float DestroyCount;// �ǐՏI���ォ��̍폜����
    bool TrackingFlag = true;// �ǐՃt���O

    //-------
    
    
    void Start()
    {
        PlayerTransfome = GameObject.FindGameObjectWithTag("Player").transform;// �ǐՖڕW��Tag�Ŏw�肵�Ă܂�
        StartCoroutine(Tracking());
    }

    void Update()
    {
        TrackingCount -= Time.deltaTime;// �ǐՕb����1�b�Â��炵�Ă���

        if (TrackingCount <= 0)// �ǐՕb����0�b�ȉ��ɂȂ�����
        {
            TrackingFlag = false;
            //Debug.Log("�Ƃ܂����������I�I");
            transform.Translate(Vector3.forward * Time.deltaTime * TrackingSpeed);
            Destroy(gameObject, DestroyCount);
        }

    }

    IEnumerator Tracking()
    {
        while (TrackingFlag)
        {
            CrayonTransfome.LookAt(PlayerTransfome);// �v���C���[�̕����Ɍ����悤�ɂ��Ă���

            // MoveTowards�ŖڕW���W���w�肵�A�����Ɍ����Ă��̃I�u�W�F�N�g�𓮂����Ă���
            transform.position = Vector3.MoveTowards
                (transform.position, new Vector3(PlayerTransfome.position.x, PlayerTransfome.position.y, PlayerTransfome.position.z), TrackingSpeed * Time.deltaTime);

            yield return new WaitForSeconds(0);
        }
    }


}
