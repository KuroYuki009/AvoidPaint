using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tips_Button : MonoBehaviour
{
    [SerializeField] GameObject tipsGUI;

    [SerializeField] Button endButton;
    public void ClickForTips()
    {
        tipsGUI.SetActive(true);

        this.GetComponent<Button>().enabled = false;
        endButton.enabled = false;
    }
}
