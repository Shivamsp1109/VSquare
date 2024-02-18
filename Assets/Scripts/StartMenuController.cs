using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenuController : MonoBehaviour
{
    // public GameObject startMenuPanel, gamePlayPanel, gameOverPanel;
    public GameObject startMenuPanel;
    public TMP_InputField nameInputField;
    public Button playButton;
    public string playerName;
    // public BalloonManager balloonManager;

    // public void SetPlayerName()
    // {
    //     if(balloonManager != null)
    //     {
    //         balloonManager.playerName = nameInputField.text;
    //     }
    // }

    void Start()
    {
        startMenuPanel.SetActive(true);
        // gamePlayPanel.SetActive(false);
        // gameOverPanel.SetActive(false);
        // Disable the Play button initially
        playButton.interactable = false;
    }

    public void CheckInputField()
    {
        // Enable the Play button only if the input field is not empty
        playButton.interactable = !string.IsNullOrEmpty(nameInputField.text);
    }

    public void StartGame()
    {
        if(!string.IsNullOrEmpty(nameInputField.text))
        {
            playerName = nameInputField.text;
            // SetPlayerName();
            // startMenuPanel.SetActive(false);
            // gamePlayPanel.SetActive(true);
            // gameOverPanel.SetActive(false);
            // Load the GamePlayScene
            SceneManager.LoadScene("FinalGame_1");
        }
    }
}
