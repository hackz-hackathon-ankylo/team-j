using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMovement : MonoBehaviour
{    
    [SerializeField]private RectTransform Textmove;//RectTransform型の変数を宣言し、作成したテキストオブジェクトをアタッチする

    void Start()
    {
        Textmove = GetComponent < RectTransform > ();
    }
    void Update()
    {
        Textmove.localPosition += new Vector3(-1, 0, 0);//毎フレームx座標を0.01ずつプラス        
    }
}