using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
using UnityEngine.UI;
 
public class SetImage : MonoBehaviour {
 
    [SerializeField]private Sprite sprite;
    [SerializeField]private Sprite sprite2;
    [SerializeField]private Sprite sprite3;
    [SerializeField]private SpriteRenderer spriteRenderer;

    private bool isLowestPosition;
    private bool isIntermediatePosition;
    private bool isHighestPosition;
 
 
    // Use this for initialization
    void Start () {
       isLowestPosition = true; // ここは仮でおいてます。本番はboolを受け取る。
    }
 
    // Update is called once per frame
    void Update () {
        
        if (isLowestPosition)
        {
            spriteRenderer.sprite = sprite; // spriteRenderをspriteにする。
            isLowestPosition = false;
            isIntermediatePosition = true;
            isHighestPosition = false;
        }

        if (isIntermediatePosition)
        {
            spriteRenderer.sprite = sprite2;
            isLowestPosition = true;
            isIntermediatePosition = false;
            isHighestPosition = true;
        }

        if (isHighestPosition)
        {
            spriteRenderer.sprite = sprite3;
            isLowestPosition = true;
            isIntermediatePosition = false;
            isHighestPosition = false;
        }
    }
}