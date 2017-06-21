using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
    public GameObject[] obstacle;
    public float timeToSpawn = 1, timeTSpawnTemp;

	// Use this for initialization
	void Start () {
        timeTSpawnTemp = timeToSpawn;
	}
	
	// Update is called once per frame
	void Update () {
        if (timeToSpawn > 0) {
            timeToSpawn -= Time.deltaTime;
        }

        if (timeToSpawn <= 0) {
            timeToSpawn = 0;
            SpawnObstacle();           
        }
	}

    void SpawnObstacle() {
        SimplePool.Spawn(obstacle[Random.Range(0, obstacle.Length)], transform.position, Quaternion.identity);
        timeToSpawn = timeTSpawnTemp;
    }
}
