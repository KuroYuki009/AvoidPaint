using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMarker : MonoBehaviour
{
    
    public GameObject targetObject; // �ǉ��F���̐錾�ɑ΂��A�C���X�y�N�^�[����I�u�W�F�N�g���A�^�b�`
    public float MarkerPointY;
    void Update()
    {
        Vector3 position = targetObject.transform.position; //targetObject�ɕύX
        position.y = MarkerPointY;
        transform.position = position;
    }
}

