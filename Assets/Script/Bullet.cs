using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float timeToDestroy, kecepatan;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0) {
            SimplePool.Despawn(gameObject);
        }

        transform.Translate(kecepatan * Time.deltaTime, 0, 0);
	}

    void OnDisable() {
        timeToDestroy = 3;
    }
}
