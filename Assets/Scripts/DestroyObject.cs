using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField]private float objectHP;
    GameObject actionPointAdmin;
    ActionPoint actionPoint;
    GameObject movingDistanceAdmin;
    MovingDistance movingDistance;
    [SerializeField]private float destroyDurability;
    public int DestroyDurability{
        get{
            return (int)destroyDurability;
        }
    }
    
    void Start(){
        destroyDurability = objectHP;
        actionPointAdmin = GameObject.Find("ActionPointAdmin");
        movingDistanceAdmin = GameObject.Find("MovingDisatnceAdmin");
        actionPoint = actionPointAdmin.GetComponent<ActionPoint>();
        movingDistance = movingDistanceAdmin.GetComponent<MovingDistance>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("hoge");
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