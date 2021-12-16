using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField]PowerGauge powergauge;
    [SerializeField]private float objectHP;
    private float destroyDurability;
    void Start(){
    destroyDurability = objectHP;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            destroyDurability -= powergauge.nowPG;
            powergauge.nowPG -= objectHP;
            // もしもオブジェクトのHPが0になった場合には（条件）
            if (destroyDurability <= 0)
            {
                Destroy(this.gameObject); // このオブジェクトを破壊する
                Debug.Log("Destroy!!!");
            }
        }
    }
}