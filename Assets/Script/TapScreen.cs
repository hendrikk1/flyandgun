using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TapScreen : MonoBehaviour {
    public Image tapImage;
    public float tapImageFadeIn = 0.1F, tapImageFadeOut = 0.1F;

    public string nextScene;

    Animator tapAnimator;

    AudioSource audioSource;
    public AudioClip tapSound;

	// Use this for initialization
	void Start () {
        tapAnimator = GetComponent<Animator>();
        audioSource = FindObjectOfType<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (tapImageFadeOut > 0) {
            tapImageFadeOut -= Time.deltaTime;
            tapImageFadeIn = 0.5F;
        }

        if (tapImageFadeOut <= 0) {
            tapImage.enabled = false;
            tapImageFadeOut = 0;
            tapImageFadeIn -= Time.deltaTime;
        }

        if (tapImageFadeIn <= 0) {
            tapImage.enabled = true;
            tapImageFadeIn = 0;
            tapImageFadeOut = 0.5F;
        }

        if (Input.anyKeyDown) {
            audioSource.PlayOneShot(tapSound);
            tapAnimator.SetBool("NextScene", true);
        }
	}

    public void NextScene() {
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }
}
