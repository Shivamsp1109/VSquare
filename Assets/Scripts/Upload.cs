using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;

public class Upload : MonoBehaviour
{
    public Button uploadButton;

    private void Start()
    {
        uploadButton.onClick.AddListener(OnUploadButtonClick);
    }

    public void OnUploadButtonClick()
    {
        // Find the TouchManager script in the scene
        TouchManager touchManager = FindObjectOfType<TouchManager>();
        if (touchManager != null)
        {
            int score = touchManager.score;

            // Call PlayFab API to upload score
            var request = new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>
                {
                    new StatisticUpdate
                    {
                        StatisticName = "Score",
                        Value = score
                    }
                }
            };

            PlayFabClientAPI.UpdatePlayerStatistics(request, OnUpdateStatisticsSuccess, OnUpdateStatisticsFailure);
        }
    }

    private void OnUpdateStatisticsSuccess(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Score uploaded successfully!");
    }

    private void OnUpdateStatisticsFailure(PlayFabError error)
    {
        Debug.LogError("Failed to upload score: " + error.ErrorMessage);
    }
}
