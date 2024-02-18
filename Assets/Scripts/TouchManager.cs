using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TouchManager : MonoBehaviour
{
    public float laserLength = 0.3f;
    public int score = 0;
    public TMP_Text scoreText;
    PlayFabManager playFabManager = new PlayFabManager();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.up * laserLength);
            Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.up * laserLength, Color.red);
            if(ray.collider != null)
            {
                if(ray.collider.gameObject.CompareTag("Balloon"))
                {
                    score++;
                    scoreText.text = "Score: " + score;
                    ray.collider.gameObject.GetComponent<Animator>().SetBool("Destroy", true);
                    Destroy(ray.collider.gameObject, 0.5F);
                } 
                if(ray.collider.gameObject.CompareTag("Enemy"))
                {
                    Time.timeScale = 0;
                    ray.collider.gameObject.GetComponent<Animator>().SetBool("Destroy", true);
                    Destroy(ray.collider.gameObject, 0.5F);
                    SceneManager.LoadScene("EndMenuScene");
                } 
            }
        }
    }

    public void OnQuitButton()
    {
        SceneManager.LoadScene("EndMenuScene");
        // playFabManagaer.SendLeaderBoard(int.Parse(scoreText.text.Split(':')[1].Trim()));
    }
}
