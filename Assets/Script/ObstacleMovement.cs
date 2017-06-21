using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {
    public float kecepatan;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-kecepatan * Time.deltaTime, 0, 0);
	}

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Dead Zone") {
            SimplePool.Despawn(gameObject);
        }
    }
}
