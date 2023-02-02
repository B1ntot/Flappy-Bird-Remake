using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;

    void Start()
    {

    }

    void Update()
    {

    }

    public void ShowScore()
    {
        scoreText.text = FindObjectOfType<ScoreKeeper>().GetScore().ToString();
        bestScoreText.text = PlayerPrefs.GetInt("highScore").ToString();

    }

    public void ProcessScore()
    {
        int playerScore = FindObjectOfType<ScoreKeeper>().GetScore();
        if (PlayerPrefs.HasKey("highScore"))
        {
            if (playerScore > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", playerScore);
                PlayerPrefs.Save();
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", playerScore);
            PlayerPrefs.Save();
        }
    }
}
