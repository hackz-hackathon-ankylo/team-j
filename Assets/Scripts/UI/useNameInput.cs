using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class useNameInput : MonoBehaviour
{
    [SerializeField] InputField inputField;
    [SerializeField] SendRankingData sendRanking;
    // Start is called before the first frame update
    public void CallSendRanking(){
        inputField = inputField.GetComponent<InputField>();
        sendRanking.UserLogin(inputField.text);
    }
}
