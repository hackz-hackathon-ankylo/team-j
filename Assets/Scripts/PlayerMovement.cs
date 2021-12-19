using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private Rigidbody2D rigidBody;
    public void AddPlayerVelocity(float x)
    {
        rigidBody.velocity = new Vector2(x, rigidBody.velocity.y);
        StartCoroutine("ReducePlayerVelocity");
    }
    IEnumerator ReducePlayerVelocity()
    {
        yield return new WaitForSeconds(0.2f);
        rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
    }
}
