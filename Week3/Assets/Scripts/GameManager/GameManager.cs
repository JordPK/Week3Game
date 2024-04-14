using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int playerHealth;
    public int score;
    public float timeLeft;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "High Score : " + PlayerPrefs.GetInt("HighScore").ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
  
        timeLeft -= Time.deltaTime;

        if (timeLeft < 0f)
        {
            Time.timeScale = 0f;

            if (score > PlayerPrefs.GetInt("HighScore")) 
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
            RestartScene();
        }

        timeText.text ="Time left:" + Mathf.RoundToInt(timeLeft).ToString();
        scoreText.text ="Score:" + score.ToString();
        
        void RestartScene()
        {
            Time.timeScale = 1f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }
            
    }
}
