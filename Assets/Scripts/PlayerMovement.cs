using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private Rigidbody2D rigidBody;


    public void hoge(float x)
    {
        rigidBody.velocity = new Vector2(x, rigidBody.velocity.y);
        StartCoroutine("hoge2");
    }
    IEnumerator hoge2()
    {
        yield return new WaitForSeconds(1f);
        rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
    }
}
