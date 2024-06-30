using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Button : MonoBehaviour
{
    public void ClickForEnd()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
        #else
            Application.Quit();//ゲームプレイ終了
        #endif
    }

}
