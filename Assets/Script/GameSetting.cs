using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    
    void Awake()
    {
        //�t���[�����[�g���Œ肳����B
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        Debug.Log("AwakeIn GameSettingSc!!");

        //�}�E�X�|�C���^�[�̔�\���A�Œ���s���B
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
