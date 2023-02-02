using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    int score = 0;

    private void Awake()
    {
        // Singleton pattern
        // ensures there is only one instance of this object
        // int numScenePersists = FindObjectsOfType<ScoreKeeper>().Length;
        // if (numScenePersists > 1)
        // {
        //     Destroy(gameObject);
        // }
        // else
        // {
        //     DontDestroyOnLoad(gameObject);
        // }
    }

    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Getters
    public int GetScore() { return score; }

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
