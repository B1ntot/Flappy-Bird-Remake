using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Bird bird;
    EndScreen endScreen;

    private void Awake()
    {
        bird = FindObjectOfType<Bird>();
        endScreen = FindObjectOfType<EndScreen>();
    }

    void Start()
    {
        endScreen.gameObject.SetActive(false);
    }

    void Update()
    {
        if (bird.birdIsDead)
        {
            Invoke("OpenEndScreen", 1.5f);
        }
    }

    void OpenEndScreen()
    {
        endScreen.gameObject.SetActive(true);
        endScreen.ProcessScore();
        endScreen.ShowScore();
    }

    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
