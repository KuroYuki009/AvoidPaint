using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CamFaceSc : MonoBehaviour
{
    //�o�ߎ���
    float timeScale;
    //����
    float transparent;

    [SerializeField] Image camFacsImage;

    void Start()
    {
        transparent = 0.0f;
        camFacsImage.color = new Color(1,1,1,transparent);
    }

    
    void Update()
    {
        //�ő�l(1.0f)�𒴂�����ő�l��Ԃ��B
        transparent = System.Math.Min(transparent, 1.0f);
        //�ŏ��l(0.0f)�����������ŏ��l��Ԃ��B
        transparent = System.Math.Max(transparent, 0.0f);

        if (Input.GetButton("Fire1"))
        {
            camFacsImage.color = new Color(1, 1, 1, transparent);

            transparent += 4.0f * Time.deltaTime;
        }
        else if(transparent >= 0.0f)
        {
            camFacsImage.color = new Color(1, 1, 1, transparent);

            transparent -= 4.0f * Time.deltaTime;
        }
    }

    void guardCamFace()
    {

    }
}