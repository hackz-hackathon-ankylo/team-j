using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class SendRankingData : MonoBehaviour
{
    [SerializeField] Text scoreText;

    public void UserLogin(string useName)
    {
        PlayFabClientAPI.LoginWithCustomID(
        new LoginWithCustomIDRequest { CustomId = useName, CreateAccount = true},
            result => 
            {
                Debug.Log("ログイン成功！");
                SetPlayerDisplayName(useName);
            },
            error => 
            {
                Debug.Log("ログイン失敗");
            }
        );
    }
    void SetPlayerDisplayName (string displayName) 
    {
        PlayFabClientAPI.UpdateUserTitleDisplayName(
            new UpdateUserTitleDisplayNameRequest {
                DisplayName = displayName
            },
            result => {
                Debug.Log("Set display name was succeeded");
                ScoreText score = scoreText.GetComponent<ScoreText>();
                SubmitScore(score.Score);
            },
            error => {
                Debug.LogError(error.GenerateErrorReport());
            }
        );
    }
    void SubmitScore(int playerScore)
    {
        PlayFabClientAPI.UpdatePlayerStatistics(
            new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>()
                {
                    new StatisticUpdate
                    {
                        StatisticName = "shiiRanking",
                        Value = playerScore
                    }
                }
            },
            result =>
            {
                SceneManager.LoadScene("Title");
            },
            error =>
            {
                Debug.Log(error.GenerateErrorReport());
            }
        );
    }
}
