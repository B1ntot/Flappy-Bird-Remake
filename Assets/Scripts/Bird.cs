using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    [SerializeField] float birdUpwardVelocity = 5.0f;
    [SerializeField] AudioClip flapSFX;

    // Components
    Rigidbody2D myRigidbody;

    bool hasGameStarted = false;
    public bool birdIsDead = false;
    float normalGravityScale;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        normalGravityScale = myRigidbody.gravityScale;
        myRigidbody.gravityScale = 0.0f;
    }

    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && !birdIsDead)
        {
            if (!hasGameStarted)
            {
                hasGameStarted = true;
                myRigidbody.gravityScale = normalGravityScale;
                FindObjectOfType<PipeSpawner>().StartSpawner();
            }
            myRigidbody.velocity = Vector2.up * birdUpwardVelocity;
            GetComponent<AudioSource>().PlayOneShot(flapSFX);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!birdIsDead)
        {
            birdIsDead = true;
            ProcessDeath();
            FindObjectOfType<PipeSpawner>().StopSpawnPipe();
            FindObjectOfType<BackgroundScroller>().StopScroll();
        }
    }

    public void ProcessDeath()
    {
        myRigidbody.velocity = Vector2.up * 2.0f;
        birdIsDead = true;
        GetComponent<Animator>().enabled = false;
        transform.Rotate(Vector3.forward * 180.0f);
    }
}
