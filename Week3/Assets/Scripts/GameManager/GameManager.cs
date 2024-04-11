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

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f;
        }
        timeLeft -= Time.deltaTime;

        if (timeLeft < 0f)
        {
            Time.timeScale = 0f;
            RestartScene();
        }

        timeText.text ="Time left:" + Mathf.RoundToInt(timeLeft).ToString();
        scoreText.text ="Score:" + score.ToString();
        
        void RestartScene()
        {
            if (Input.GetKeyDown (KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
