using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class RankingTest : MonoBehaviour
{
    public string hoge;

    void Start()
    {
        UserLogin(hoge);
    }

    public void UserLogin(string useName)
    {
        PlayFabClientAPI.LoginWithCustomID(
        new LoginWithCustomIDRequest { CustomId = useName, CreateAccount = true},
            result => 
            {
                Debug.Log("ログイン成功！");
                //SetPlayerDisplayName(usename);
            },
            error => 
            {
                Debug.Log("ログイン失敗");
            }
        );
    }
    /*void SetPlayerDisplayName (string displayName) 
    {
        PlayFabClientAPI.UpdateUserTitleDisplayName(
            new UpdateUserTitleDisplayNameRequest {
                DisplayName = displayName
            },
            result => {
                Debug.Log("Set display name was succeeded");
                SubmitScore(Enemy.score);
            },
            error => {
                Debug.LogError(error.GenerateErrorReport());
            }
        );
    }*/
}
