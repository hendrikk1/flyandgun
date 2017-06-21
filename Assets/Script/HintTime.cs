using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintTime : MonoBehaviour {
    public float hintTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        hintTime -= Time.deltaTime;
        if (hintTime <= 0) {
            hintTime = 0;
            gameObject.SetActive(false);
        }
	}
}
