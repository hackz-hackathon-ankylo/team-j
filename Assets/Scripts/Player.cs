using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Player : MonoBehaviour {
 
    //インスペクタに表示する変数
    [SerializeField]
    float speed = 0.0f;
    [SerializeField]
    float jumpPower = 30.0f;
    [SerializeField]
    Transform groundCheck;
 
    //インスペクタには表示しない変数
    bool jumped = false;
    bool grounded = false;
    bool groundedPrev = false;
    Animator animator;
    Rigidbody2D rigidBody2D;
 
    //初期化
    void Start () {
        //コンポーネントを取得
        animator = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }
 
    //毎フレームの処理（一般）
    void Update()
    {
        //接地チェック
        //GroundCheckオブジェクトに床などが重なってるならtrue
        grounded = (Physics2D.OverlapPoint(groundCheck.position) != null) ? true : false;
 
        //接地してるかどうかの分岐
        if (grounded)
        {
            //接地しているならジャンプを許可
            if (Input.GetMouseButtonDown(0))
            {
                Jump();
            }
        }
 
        //ジャンプしてるかどうかの分岐
        if (jumped)
        {
            animator.SetTrigger("ST");
 
            //ジャンプ終了（前フレームで接地してなくて、今のフレームで接地したとき）
            if (!groundedPrev & grounded)
            {
                jumped = false;
            }
        }
        else
        {
            animator.SetTrigger("Run");
        }
 
        //このフレームの接地状態を保存
        groundedPrev = grounded ? true : false;
    }
 
    //毎フレームの処理（物理演算）
    void FixedUpdate()
    {
         
    }
 
    //ジャンプ
    void Jump()
    {
        jumped = true;
 
        rigidBody2D.velocity = Vector2.up * jumpPower;
    }
}