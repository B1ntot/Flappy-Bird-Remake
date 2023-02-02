using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] float pipeSpeed = 5.0f;

    // Components
    Rigidbody2D myRigidbody;

    bool birdHasPassed = false;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        myRigidbody.velocity = Vector2.left * pipeSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!birdHasPassed)
        {
            scoreKeeper.IncrementScore();
            GetComponent<AudioSource>().Play();
            birdHasPassed = true;
        }
    }

    public void StopPipe()
    {
        myRigidbody.velocity = Vector2.zero;
    }
}
