using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomWalk : MonoBehaviour
{
    float standbyTimeScale = 2.0f;
    float moveingTimeScale = 1.0f;
     
    Rigidbody rb;
    float moveSpeed;
    Vector3 moveForward;
    float randomVertical;
    float randomHorizontal;
    bool randomRollSW;

    turretQuo turretquo;

    Vector3 cameraForward;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        turretquo = GetComponent<turretQuo>();
    }

    
    void Update()
    {
        if (standbyTimeScale >= 0.0f)
        {
            if(randomRollSW == false)
            {
                //turretquo.enabled = true;
                Randomizer();
                randomRollSW = true;
            }
            moveingTimeScale = 1.0f;
            standbyTimeScale -= 1.0f * Time.deltaTime;
            //Debug.Log("stanby");
        }
        else if (moveingTimeScale >= 0.0f)
        {
            //turretquo.enabled = false;
            moveingTimeScale -= 1.0f * Time.deltaTime;
            RandomMove();
            //Debug.Log("go!!");
        }
        else
        {
            randomRollSW = false;
            standbyTimeScale = 2.0f;
        }
    }

    void RandomMove()
    {
        

        // �ړ������ɃX�s�[�h(moveSpeed��scroll�l)���|����B�W�����v�◎��������ꍇ�́A�ʓrY�������̑��x�x�N�g���𑫂��B
        rb.velocity = moveForward * moveSpeed + new Vector3(randomHorizontal, rb.velocity.y, randomVertical);

       
    }

    void Randomizer()
    {
        randomHorizontal = Random.Range(-0.5f, 0.5f);
        randomVertical = Random.Range(-0.5f, 0.5f);
    }
    private void OnTriggerStay(Collider other)
    {
        
    }
}
