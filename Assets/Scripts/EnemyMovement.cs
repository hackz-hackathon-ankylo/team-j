using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]private Rigidbody2D rigidBody;

    void Start()
    {
        StartCoroutine("AddEnemyVelocity");
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("GameOver");
        }
    }
    IEnumerator AddEnemyVelocity()
    {
        yield return new WaitForSeconds(10.0f);
        rigidBody.velocity = new Vector2(1, rigidBody.velocity.y);
    }
}
