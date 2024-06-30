using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text suvivaltimeText;

    float totalScore;
    float survivTime;

    [SerializeField] Animator cutAnimator;

    [SerializeField] GameObject nextbuttonObj;
    float buttonDelay;
    void Start()
    {
        totalScore = InGameManager.globalScore;
        survivTime = InGameManager.globalSuvivalTime;

        //
        scoreText.text = string.Format("{0:0}", totalScore);
        suvivaltimeText.text = string.Format("{0:0}", survivTime);

        cutAnimator.SetTrigger("CutIN");
    }
    private void Update()
    {
        if (buttonDelay >= 1.0f) buttonDelay += 1 * Time.deltaTime;
        else nextbuttonObj.SetActive(true);
    }
}
