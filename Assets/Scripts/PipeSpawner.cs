using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] float minYHeight = 0;
    [SerializeField] float maxYHeight = 5.0f;
    [SerializeField] float pipeSpawnTime = 2.0f;
    [SerializeField] GameObject pipe;

    void Start()
    {
    }

    public void StartSpawner()
    {
        InvokeRepeating("SpawnPipe", 0.0f, pipeSpawnTime);
    }

    void SpawnPipe()
    {
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(minYHeight, maxYHeight), 0), Quaternion.identity);
    }

    public void StopSpawnPipe()
    {
        CancelInvoke("SpawnPipe");
        foreach (Pipe pipe in FindObjectsOfType<Pipe>())
        {
            pipe.StopPipe();
        }
    }
}
