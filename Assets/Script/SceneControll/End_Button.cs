using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Button : MonoBehaviour
{
    public void ClickForEnd()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
        #else
            Application.Quit();//�Q�[���v���C�I��
        #endif
    }

}
