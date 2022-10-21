using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float maxYpos;
    public float spawnTime;
    public GameObject Pipe;
    bool spawnTimeChanged = false;

    private void Start()
    {
        StartSpawningPipes();
    }
    void SpawnPipe()
    {
        Instantiate(Pipe, new Vector3(transform.position.x, Random.Range(-maxYpos, maxYpos), 0), Quaternion.identity);

    }

    public void StartSpawningPipes()
    {
        InvokeRepeating("SpawnPipe", 0.2f, spawnTime);
    }

    public void StopSpawningPipes()
    {
        CancelInvoke("SpawnPipe");
    }

    private void Update()
    {
        if(ScoreManager.instance.score == 3 && !spawnTimeChanged)
        {
            spawnTime--;
            spawnTimeChanged = true;
        }


    }
}
