using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IventSceneLoader : MonoBehaviour
{
    public void LoadScene_InGame()
    {
        // �V�[���̓ǂݍ���
        SceneManager.LoadScene("InGameScene");
    }

    public void LoadScene_Result()
    {
        // �V�[���̓ǂݍ���
        SceneManager.LoadScene("ResultScene");
    }
    public void LoadScene_Title()
    {
        // �V�[���̓ǂݍ���
        SceneManager.LoadScene("TitleScene");
    }
}
