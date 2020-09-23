using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeoniesSpawner : MonoBehaviour
{
    public GameObject peoniesPrefab;
    enum SpawnerState { spawn, wait };
    SpawnerState currentSpawnerState = SpawnerState.spawn;

    float lastStateChange = 0.0f;
    public float spawnWaitTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        setCurrentState(SpawnerState.spawn);
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentSpawnerState)
        {
            case SpawnerState.spawn:
                spawn();
                break;
            case SpawnerState.wait:
                wait();
                break;
            
        }
    }

    void spawn()
    {
        Instantiate(peoniesPrefab, new Vector3(0, 0, 0), Quaternion.identity, this.gameObject.transform);
        setCurrentState(SpawnerState.wait);
    }

    void wait()
    {
        if(getStateElapsed() > spawnWaitTime)
        {
            setCurrentState(SpawnerState.spawn);
        }
    }

    void setCurrentState(SpawnerState state)
    {
        currentSpawnerState = state;
        lastStateChange = Time.time;
    }

    float getStateElapsed()
    {
        return Time.time - lastStateChange;
    }
}
