using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Vector2 jumpForce = new Vector2(0, 300);
    Rigidbody2D playerRigidbody;

    SpriteRenderer gunSpriteRenderer;
    public Sprite[] gunSprites;

    public GameObject bullet, laser;

    public Transform[] bulletPoint;

    AudioSource audioSource;

    public AudioClip shotSound, laserSound;

    CameraShaking cameraShaking;

    int weaponID;

    public float laserTime, uziTime;

    public bool uziShot, gameOver;

    Scoring scoring;

    // Use this for initialization
    void Start () {
        playerRigidbody = GetComponent<Rigidbody2D>();
        gunSpriteRenderer = GetComponent<SpriteRenderer>();

        audioSource = FindObjectOfType<AudioSource>();
        cameraShaking = FindObjectOfType<CameraShaking>();

        scoring = FindObjectOfType<Scoring>();

        if (PlayerPrefs.GetInt("WeaponID") == 0) {
            gunSpriteRenderer.sprite = gunSprites[0];
            weaponID = 0;
        }
        else if (PlayerPrefs.GetInt("WeaponID") == 1) {
            gunSpriteRenderer.sprite = gunSprites[1];
            weaponID = 1;
        }
        else if (PlayerPrefs.GetInt("WeaponID") == 2)
        {
            gunSpriteRenderer.sprite = gunSprites[2];
            weaponID = 2;
        }
        else if (PlayerPrefs.GetInt("WeaponID") == 3)
        {
            gunSpriteRenderer.sprite = gunSprites[3];
            weaponID = 3;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !gameOver) {
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.AddForce(jumpForce);            
            if (weaponID != 2) {
                SpawnBullet();
            }            
        }

        if (weaponID == 2) {
            if (Input.GetKey(KeyCode.Mouse0) && uziTime <= 0 && !gameOver) {                
                SpawnBullet();
                uziShot = true;                            
            }

            if (uziShot) {
                uziTime += Time.deltaTime;
            }

            if (uziTime >= 0.1F)
            {
                uziTime = 0;
                uziShot = false;
            }
        }

        if (weaponID == 3 && laserTime > 0) {
            laserTime -= Time.deltaTime;
        }

        if (weaponID == 3 && laserTime <= 0)
        {
            laserTime = 0;
            laser.SetActive(false);
        }

    }

    void SpawnBullet() {
        if (weaponID == 0 || weaponID == 2) {
            audioSource.PlayOneShot(shotSound);
            SimplePool.Spawn(bullet, bulletPoint[1].position, bulletPoint[1].rotation);
            cameraShaking.shakeDuration = 0.1F;
        }
        else if (weaponID == 1) {
            audioSource.PlayOneShot(shotSound);
            audioSource.PlayOneShot(shotSound);
            audioSource.PlayOneShot(shotSound);
            SimplePool.Spawn(bullet, bulletPoint[0].position, bulletPoint[0].rotation);
            SimplePool.Spawn(bullet, bulletPoint[1].position, bulletPoint[1].rotation);
            SimplePool.Spawn(bullet, bulletPoint[2].position, bulletPoint[2].rotation);
            cameraShaking.shakeDuration = 0.1F;
        }
        else if (weaponID == 3) {
            audioSource.PlayOneShot(laserSound);
            laser.SetActive(true);
            cameraShaking.shakeDuration = 0.1F;
            laserTime = 1;
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Dead Zone") {
            gameOver = true;
            scoring.GameOver();
        }
    }
}
