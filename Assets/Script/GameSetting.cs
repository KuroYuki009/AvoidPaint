using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    
    void Awake()
    {
        //フレームレートを固定させる。
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        Debug.Log("AwakeIn GameSettingSc!!");

        //マウスポインターの非表示、固定を行う。
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
