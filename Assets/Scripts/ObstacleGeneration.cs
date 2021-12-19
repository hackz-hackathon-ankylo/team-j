using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
public GameObject obj; // 生成するオブジェクト
[SerializeField] GameObject HpInfo;
    [SerializeField]private int createNumbers; // 生成する数
    [SerializeField]private int obstaclespace; // 生成する間隔
    [SerializeField]private Vector2 createPos; // 生成する場所
    Vector3 offset = new Vector3((float)-4.2,(float)2.2,0);
    GameObject info;
    ObjHpColor hpInfo;
    GameObject parentObj;

// Use this for initialization
    void Start ()
    {
        CreateObject(); // 生成メソッド実行
    }
    void CreateObject() // 生成メソッド
    {
        for (int i = 0; i < createNumbers; i++)
        {
            parentObj =  (GameObject)Instantiate(obj, createPos + new Vector2(i + obstaclespace * i, 0), Quaternion.identity);
            info = (GameObject)Instantiate(HpInfo,parentObj.transform.position + offset,Quaternion.identity);
            info.transform.parent = parentObj.transform;
            hpInfo = info.GetComponent<ObjHpColor>();
            hpInfo.StartChange(parentObj);
    }
}
}
