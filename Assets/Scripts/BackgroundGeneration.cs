using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGeneration : MonoBehaviour
{

// Use this for initialization
 [SerializeField] private GameObject Plane; 
   //ここでpublicと宣言することで後でInspectorビューから操作できる
   //BackGroundの座標は(0, 0 ,100)にする
  float x = 472;
  float timer = 0;
  float spowntime = 40; //30秒ごとに生成させる

    void Update()
    {
    timer += Time.deltaTime; //timerの値を1秒に1のペースで増やす
    if(timer > spowntime) {
      PlaneGenerate(); //PlaneGenerate関数を呼び出す。
      timer = 0; //timerを0に戻す。
    }
    }

  void PlaneGenerate() {
    Instantiate(Plane, new Vector3(x, 0, 100),Quaternion.identity);
    x += 472;
    /*Planeを(472,0,0)の場所に生成する。
    Quaternion.identityは回転させないことを示す言葉*/
    //x を増加
  }
}