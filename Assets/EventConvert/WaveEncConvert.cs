using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEncConvert : MonoBehaviour
{
    [SerializeField] InGameManager gameManager;

    void WaveEnd()
    {
        gameManager.waveAnimaPassing = true;
    }

}
