using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JoyconInformation : MonoBehaviour
{
    // 読み込み専用 の変数 = 定数
    // JoyConボタンのありうる種類のパターンの配列
    //
    // typeOf = 引数のメソッドの型を取得（複数候補あれば Enum）
    // Joycon: 予想では 左の JoyCon と 右の JoyCon
    // Enum.GetValues = Enum の値を配列として扱える変換
    // "HOGE" as number: "HOGE"といういう変数の型がなんであっても、その型を number として扱う。

    [SerializeField]ActionPoint actionPoint;
    [SerializeField]PauseAnim pauseAnim;
    [SerializeField]PauseAnim pauseAnim2;
    private static readonly Joycon.Button[] m_buttons =
        Enum.GetValues( typeof( Joycon.Button ) ) as Joycon.Button[];

    private List<Joycon>    m_joycons; // 接続されたJoyConの配列
    private Joycon          m_joyconL; // 接続されたJoyConの左
    private Joycon          m_joyconR; // 接続されたJoyConの右
    private Joycon.Button?  m_pressedButtonL; // 押された左ボタンを格納
    private Joycon.Button?  m_pressedButtonR; // 押された右ボタンを格納

    public static bool hoge = false;

    

    /// <summary>
    /// TODO:enumで管理する
    /// </summary>
    [System.NonSerialized]public bool isLowestPositionL = false;
    [System.NonSerialized]public bool isIntermediatePositionL = false;
    [System.NonSerialized]public bool isHighestPositionL = false;
    [System.NonSerialized]public bool isLowestPositionR = false;
    [System.NonSerialized]public bool isIntermediatePositionR = false;
    [System.NonSerialized]public bool isHighestPositionR = false;

    private void Start()
    {
        SetControllers ();
    }

    private void Update()
    {
        SetControllers ();

        foreach ( var joycon in m_joycons )
        {
            var isLeft      = joycon.isLeft;

            var name        = isLeft ? "Joy-Con (L)" : "Joy-Con (R)";

            // joyCon が左なら左の押されている状況、右なら右の押されている状況
            var button      = isLeft ? m_pressedButtonL : m_pressedButtonR;

            // joycon 加速度
            var accel       = joycon.GetAccel();

            if(isLeft)
            {
                isLowestPositionL = (0.9f < accel.x);
                isIntermediatePositionL = (0.3f < accel.x && accel.x < 0.7f);
                isHighestPositionL = (accel.x < 0.1f);
            }
            else 
            {
                isLowestPositionR = (accel.x < 0.1f);
                isIntermediatePositionR = (0.3f < accel.x && accel.x < 0.7f);
                isHighestPositionR = (0.9f < accel.x);
            }
        }

        // ボタンの押されてるか否かをリセット
        m_pressedButtonL = null;
        m_pressedButtonR = null;

        // JoyConが存在しなければ、早期return
        if ( m_joycons == null || m_joycons.Count <= 0 ) return;

        // https://docs.microsoft.com/ja-jp/dotnet/csharp/programming-guide/arrays/using-foreach-with-arrays
        // ボタンを一つずつ、チェック
        foreach ( var button in m_buttons )
        {
            // 左のボタンは押されているのであれば
            if ( m_joyconL.GetButton( button ) )
            {
                // 左ボタンのインスタンス変数の値を更新
                m_pressedButtonL = button;
            }
            // 右のボタンは押されているのであれば
            if ( m_joyconR.GetButton( button ) )
            {
                // 右ボタンのインスタンス変数の値を更新
                m_pressedButtonR = button;
            }
        }
        if(m_pressedButtonR.ToString() == "PLUS")
        {
            pauseAnim2.PauseButtonPushed();
        }
        if(m_pressedButtonR.ToString() == "DPAD_RIGHT")
        {
            pauseAnim.ResumeButtonPushed();
        }
        if(m_pressedButtonR.ToString() == "DPAD_DOWN")
        {
            pauseAnim.ResumeButtonPushed();
            hoge = true;
        }
    }
    private void SetControllers ()
    {
        // つながっている JoyCon の配列を取得
        m_joycons = JoyconManager.Instance.j;

        // JoyCon が存在しなければ、早期 return
        if ( m_joycons == null || m_joycons.Count <= 0 ) return;

        // https://www.sejuku.net/blog/45252
        // つながっている Joycon の中から、左のものの一番目のコントローラを取得
        m_joyconL = m_joycons.Find( c =>  c.isLeft );
        // つながっている Joycon の中から、右のものの一番目のコントローラを取得
        m_joyconR = m_joycons.Find( c => !c.isLeft );
    }

}