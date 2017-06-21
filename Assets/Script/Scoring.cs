using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scoring : MonoBehaviour {
    public Text scoreText, scoreText2;
    public int score, point;

    public Animator gameOverAnimator;

    AudioSource audioSource;
    public AudioClip buttonSound;

	// Use this for initialization
	void Start () {
        point = PlayerPrefs.GetInt("Point");

        audioSource = FindObjectOfType<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "" + score;
        scoreText2.text = "" + score;

        PlayerPrefs.SetInt("Point", score + point);
    }

    public void Restart() {
        audioSource.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void Menu() {
        audioSource.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

    public void GameOver() {
        gameOverAnimator.SetBool("isGameOver", true);
    }
}
