using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CamFaceSc : MonoBehaviour
{
    //経過時間
    float timeScale;
    //透明
    float transparent;

    [SerializeField] Image camFacsImage;

    void Start()
    {
        transparent = 0.0f;
        camFacsImage.color = new Color(1,1,1,transparent);
    }

    
    void Update()
    {
        //最大値(1.0f)を超えたら最大値を返す。
        transparent = System.Math.Min(transparent, 1.0f);
        //最小値(0.0f)を下回ったら最小値を返す。
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