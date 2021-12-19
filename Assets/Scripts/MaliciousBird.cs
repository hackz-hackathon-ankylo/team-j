using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class MaliciousBird : MonoBehaviour
{
    private static readonly string[] COMMENTS = new string[] { "あれ?あれれれ?", "ぬるぽー", "休憩中?","有給くれたら許してやる","もっと熱くなれよ.." };
    [SerializeField]private Transform target;
    public Vector3 offset;

    void Start()
    {
        //COMMENTSの中から一つをランダムで取得する
        string comment = COMMENTS.ElementAt(Random.Range(0, COMMENTS.Count()));
        Debug.Log(comment);
        GetComponent<Text>().text = comment;
        offset = new Vector3(0, 0, 0);
        this.transform.position = target.position + offset;
    }

}