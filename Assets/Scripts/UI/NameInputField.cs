using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameInputField : MonoBehaviour
{
    [SerializeField] GameObject inputField;
    // Start is called before the first frame update
    public void OnPushed(){
        inputField.SetActive(true);
    }
}
