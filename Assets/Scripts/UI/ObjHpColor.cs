using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class ObjHpColor : MonoBehaviour
{

    [SerializeField]private Color color1, color2, color3, color4, color5; // カラーの種類を4種類用意する
    [SerializeField]private float maxPG = 100; // 最大パワーゲージ数字を100とする
    [SerializeField]private SpriteRenderer HpColor; // Hpの画像をいれる
    [SerializeField]private float PG_ratio; // パワーゲージ100%を1としたときのゲージ割合
    DestroyObject[] hp;
    int p;
    public void StartChange(GameObject hpObj ){
       hp = hpObj.GetComponents<DestroyObject>();
        p = hp[0].DestroyDurability;
        StartCoroutine("ColorUpdate");
    }
     IEnumerator ColorUpdate()
    {
            
       PG_ratio = p / maxPG; // PG_ratioの計算式

        if (PG_ratio > 0.75f)
        {
            HpColor.color = Color.Lerp(color2, color1, (PG_ratio - 0.75f) * 4f);
        }
        else if(PG_ratio > 0.50f)
        {
            HpColor.color = Color.Lerp(color3, color2, (PG_ratio - 0.50f) * 4f);
        }
        else if(PG_ratio > 0.25f)
        {
            HpColor.color = Color.Lerp(color4, color3, (PG_ratio - 0.25f) * 4f);            
        }
        else
        {
            HpColor.color = Color.Lerp(color5, color4, PG_ratio * 4f);
        }
        yield return null;
    }
}
