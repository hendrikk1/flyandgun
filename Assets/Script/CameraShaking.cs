using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaking : MonoBehaviour {
    public float shakeDuration = 0f;

    float shakeAmount = 0.05f;
    float decreaseFactor = 0.2f;

    Vector3 originalPos;

    void OnEnable()
    {
        originalPos = transform.localPosition;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (shakeDuration > 0)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = originalPos;
        }
    }
}
