using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class skill_ULT : MonoBehaviour
{
    public ULTController ultControllerScript;
    [SerializeField] SphereCollider ultSphere;

    public int ULT_Count1;// ULT�J�E���g
    public int ULT_Count2;
    public int ULT_Count3;
    public int ULT_Count4;

    [SerializeField] Image ui_ultGage_up;
    [SerializeField] Image ui_ultGage_right;
    [SerializeField] Image ui_ultGage_down;
    [SerializeField] Image ui_ultGage_left;

    
    void Start()
    {
        ULT_ItemReset();
        ULT_Count1 = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))// ULT�̋N���{�^���B
        {
            if (ULT_Count1 >= 1 && ULT_Count2 >= 1 && ULT_Count3 >= 1 && ULT_Count4 >= 1)
            {
                ultSphere.enabled = true;

                ultControllerScript.ULTooooo();// ult�̏������N��������B
                ULT_ItemReset();// �l�������A�C�e���̃��Z�b�g�B
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

    void ULT_ItemReset()// �E���g���g���̂ɕK�v�Ȏ��W�A�C�e���̏������B�܂�UI��������������B
    {
        ULT_Count1 = 0;
        ULT_Count2 = 0;
        ULT_Count3 = 0;
        ULT_Count4 = 0;

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
                Debug.Log("��������");
                break;

            case "Item2":
                ULT_Count2++;
                Destroy(collision.gameObject);
                Debug.Log("��������");
                break;

            case "Item3":
                ULT_Count3++;
                Destroy(collision.gameObject);
                Debug.Log("��������");
                break;

            case "Item4":
                ULT_Count4++;
                Destroy(collision.gameObject);
                break;
        }
    }
}
