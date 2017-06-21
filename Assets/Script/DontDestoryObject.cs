using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoryObject : MonoBehaviour {
    public GameObject[] bgm;

	// Use this for initialization
	void Start () {
        bgm = GameObject.FindGameObjectsWithTag("BGM");

        DontDestroyOnLoad(bgm[0]);

        if (bgm.Length > 1) {
            Destroy(bgm[1]);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
