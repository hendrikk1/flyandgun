using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    public float kecepatan;
    public float health;
    Rigidbody2D enemyRigidbody;
    Animator enemyAnimator;
    SpriteRenderer enemySpriteRenderer;

    AudioSource audioSource;
    public AudioClip hitSound;

    Scoring scoring;

    bool scoreIn;

	// Use this for initialization
	void Start () {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = FindObjectOfType<AudioSource>();

        scoring = FindObjectOfType<Scoring>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-kecepatan * Time.deltaTime, 0, 0);

        if (health <= 0) {
            if (!scoreIn) {
                scoring.score++;
                scoreIn = true;
            }
            
            enemyRigidbody.bodyType = RigidbodyType2D.Dynamic;
            enemyAnimator.SetBool("isDead", true);
        }
	}

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Bullet") {
            health--;
            audioSource.PlayOneShot(hitSound);
            SimplePool.Despawn(collision.gameObject);
        }

        if (collision.gameObject.tag == "Dead Zone") {
            SimplePool.Despawn(gameObject);
        }
    }

    void OnDisable() {
        scoreIn = false;
        enemyAnimator.SetBool("isDead", false);
        health = 1;
        enemyRigidbody.bodyType = RigidbodyType2D.Kinematic;
        enemySpriteRenderer.flipX = true;
        enemySpriteRenderer.flipY = false;     
    }
}
