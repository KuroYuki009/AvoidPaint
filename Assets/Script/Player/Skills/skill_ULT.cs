using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class skill_ULT : MonoBehaviour
{
    public ULTController ultControllerScript;
    [SerializeField] SphereCollider ultSphere;

    public int ULT_Count1;// ULTカウント
    public int ULT_Count2;
    public int ULT_Count3;
    public int ULT_Count4;

    [SerializeField] Image ui_ultGage_up;
    [SerializeField] Image ui_ultGage_right;
    [SerializeField] Image ui_ultGage_down;
    [SerializeField] Image ui_ultGage_left;

    
    void Start()
    {
        EnableReset();
        ULT_Count1 = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))// ULTボタンポチィ
        {
            /*if(ULT_Count1 >= 4)// ULTカウントが規定値以上にあったら
            {
                ULT_Count1 = 0;// カウントを0に戻す
                StartCoroutine(ultScript.ULTooooo());
            }*/
            if (ULT_Count1 >= 1 && ULT_Count2 >= 1 && ULT_Count3 >= 1 && ULT_Count4 >= 1)
            {
                ultSphere.enabled = true;
                EnableReset();
                ULT_Count1 = 0;// カウントを0に戻す
                ULT_Count2 = 0;
                ULT_Count3 = 0;
                ULT_Count4 = 0;
                ultControllerScript.SendMessage("ULTooooo");

            }

        }

        if(ULT_Count1 >= 1)
        {
            ui_ultGage_up.enabled = true;
        }
        if (ULT_Count2 >= 1)
        {
            ui_ultGage_right.enabled = true;
        }
        if (ULT_Count3 >= 1)
        {
            ui_ultGage_down.enabled = true;
        }
        if (ULT_Count4 >= 1)
        {
            ui_ultGage_left.enabled = true;
        }
    }

    void EnableReset()
    {
        ui_ultGage_up.enabled = false;
        ui_ultGage_right.enabled = false;
        ui_ultGage_down.enabled = false;
        ui_ultGage_left.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Item1":
                ULT_Count1++;
                Destroy(collision.gameObject);
                Debug.Log("あたった");
                break;

            case "Item2":
                ULT_Count2++;
                Destroy(collision.gameObject);
                Debug.Log("あたった");
                break;

            case "Item3":
                ULT_Count3++;
                Destroy(collision.gameObject);
                Debug.Log("あたった");
                break;

            case "Item4":
                ULT_Count4++;
                Destroy(collision.gameObject);
                break;
        }
    }
}
