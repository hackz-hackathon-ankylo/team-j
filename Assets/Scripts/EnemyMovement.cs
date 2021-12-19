using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]private Rigidbody2D rigidBody;
    [SerializeField]private GameObject input;
    private float enemySpeed = 1;

    void Start()
    {
        StartCoroutine("AddEnemyVelocity");
    }
    void Update()
    {
        if(JoyconInformation.hoge)this.gameObject.SetActive (false);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            input.SetActive(true);
        }
    }
    IEnumerator AddEnemyVelocity()
    {
        yield return new WaitForSeconds(2.0f);
        rigidBody.velocity = new Vector2(1, rigidBody.velocity.y);
        while(true)
        {
            yield return new WaitForSeconds(1.0f);
            enemySpeed *= 1.1f;
            rigidBody.velocity = new Vector2(enemySpeed, rigidBody.velocity.y);
        }
    }
}
