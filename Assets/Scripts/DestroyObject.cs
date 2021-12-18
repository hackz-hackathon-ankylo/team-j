using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField]private float objectHP;
    [SerializeField]ActionPoint actionPoint;
    [SerializeField]private float destroyDurability;
    void Start(){
        destroyDurability = objectHP;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            destroyDurability = actionPoint.ReduceObjectDurability(destroyDurability);
            actionPoint.ReduceActionPoint(objectHP);

            // もしもオブジェクトのHPが0になった場合には（条件）
            if (destroyDurability <= 0)
            {
                Destroy(this.gameObject); // このオブジェクトを破壊する
            }
            Debug.Log($"耐久度{destroyDurability}");
        }
    }
}