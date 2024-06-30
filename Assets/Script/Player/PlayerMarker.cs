using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMarker : MonoBehaviour
{
    
    public GameObject targetObject; // 追加：この宣言に対し、インスペクターからオブジェクトをアタッチ
    public float MarkerPointY;
    void Update()
    {
        Vector3 position = targetObject.transform.position; //targetObjectに変更
        position.y = MarkerPointY;
        transform.position = position;
    }
}

