using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityRadarSc : MonoBehaviour
{
    //・範囲内にTag / EnemyAttackがついているオブジェクトが範囲内に入るとアタッチされた画像が表示される。
    //・警告表示に使用することが出来る
    //表示する画像
    [SerializeField] private GameObject indicatorSprite;

    void Start()
    {
        indicatorSprite.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "EnemyAttack")
        {
            indicatorSprite.SetActive(true);
            Debug.Log("COlllijhonEnemyAte!");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "EnemyAttack")
        {
            indicatorSprite.SetActive(false);
        }
    }
}
