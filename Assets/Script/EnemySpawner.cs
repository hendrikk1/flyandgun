using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public float timeToSpawn, timeToSpawnMax;
    public float randomYPos, randomYPosRange;

    public GameObject enemy;

	// Use this for initialization
	void Start () {
        timeToSpawn = Random.Range(1, timeToSpawnMax);
        randomYPos = Random.Range(-randomYPosRange, randomYPosRange);
	}
	
	// Update is called once per frame
	void Update () {
        if (timeToSpawn > 0) {
            timeToSpawn -= Time.deltaTime;
        }

        if (timeToSpawn <= 0) {
            timeToSpawn = 0;
            SpawnEnemy();
        }
	}

    void SpawnEnemy() {
        SimplePool.Spawn(enemy, new Vector3(transform.position.x, randomYPos, transform.position.z), Quaternion.identity);
        timeToSpawn = Random.Range(1, timeToSpawnMax);
        randomYPos = Random.Range(-randomYPosRange, randomYPosRange);
    }
}
