using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        setTitleId("28411");
        Login();
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest{CustomId = SystemInfo.deviceUniqueIdentifier, CreateAccount = true};
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    void OnSuccess(LoginResult result)
    {
        Debug.Log("Successfully LoggedIn");
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Error while logging");
        Debug.Log(error.GenerateErrorReport());
    }

    public void SendLeaderBoard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest{Statistics = new List<StatisticUpdate>{new StatisticUpdate {StatisticName = "BalloonBlast", Value = score}}};
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderBoardUpdate, OnError);
    }

    void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successfull");
    }

    void setTitleId(string titleId)
    {
        PlayFabSettings.TitleId = titleId;
    }
}