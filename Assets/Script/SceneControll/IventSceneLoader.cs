using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IventSceneLoader : MonoBehaviour
{
    public void LoadScene_InGame()
    {
        // シーンの読み込み
        SceneManager.LoadScene("InGameScene");
    }

    public void LoadScene_Result()
    {
        // シーンの読み込み
        SceneManager.LoadScene("ResultScene");
    }
    public void LoadScene_Title()
    {
        // シーンの読み込み
        SceneManager.LoadScene("TitleScene");
    }
}
