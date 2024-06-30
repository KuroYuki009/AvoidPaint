using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretQuo : MonoBehaviour
{
    //
    public GameObject target;
    [SerializeField]private GameObject ShootObject;

    [SerializeField] GameObject shootPos;

    Quaternion lookRotation;

    [SerializeField] float timeloop;

    public float shotIntervalSpeed;

    //���������I�u�W�F�N�g���A�^�b�`������I�u�W�F�N�g�̎q�Ƃ��Ēǉ�����B
    [SerializeField]private GameObject parentObject;

    //���f������A�j���[�^�[���擾
    [SerializeField] private GameObject charaModel;
    private void Start()
    {
        target = GameObject.Find("playablePlayer");
        parentObject = GameObject.Find("Parent_EnemyATKObjects");
        shotIntervalSpeed = 2.5f;
    }
    private void FixedUpdate()
    {
        lookRotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);

        //lookRotation.z = 0;
        //lookRotation.x = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.3f);

        //Vector3 p = new Vector3(0f, 0f, 0.08f);

        //transform.Translate(p);

        if (timeloop <= shotIntervalSpeed)
        {
            timeloop += 1.0f * Time.deltaTime; //���ˋ�Ԃ̐ݒ�
        }
        else if(timeloop >= shotIntervalSpeed)
        {
            //���f������A�j���[�^�[���擾�����̒��̍U���A�j�����Đ��B�A�j���[�V�����̒��ŃC�x���g�g���K�[���g�p���U�����s���B
            charaModel.GetComponent<Animator>().SetTrigger("PaintAttack");
            //EnemyAttackShoot();
            timeloop = 0.0f;
        }


    }

    void EnemyAttackShoot()
    {
        Vector3 pos = shootPos.transform.position;

        Instantiate(ShootObject, pos, transform.rotation,parentObject.transform);


    }
}
