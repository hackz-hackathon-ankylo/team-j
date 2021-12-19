using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    [SerializeField]private Transform Move;

    // Update is called once per frame
    
    void FixedUpdate()
    {
        Move.position += new Vector3(-0.03f, 0, 0);
    }
}
