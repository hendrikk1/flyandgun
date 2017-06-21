using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    int menuID, point;
    public int weaponID, weaponPrice;
    Animator mainMenuAnimator;
    public string gameScene;

    public Image soundSettingImage, gunImage;
    public Sprite[] soundSettingSprite, gunSprites;
    AudioSource bgm;

    public Text yourPointText, weaponPriceText;

    public AudioClip buttonSound, noSound;

	// Use this for initialization
	void Start () {
        point = PlayerPrefs.GetInt("Point");
        mainMenuAnimator = GetComponent<Animator>();

        bgm = FindObjectOfType<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        yourPointText.text = "Your Point : " + point;

        if (weaponID == 0) {
            gunImage.sprite = gunSprites[0];
            weaponPrice = 0;
        }
        else if (weaponID == 1)
        {
            gunImage.sprite = gunSprites[1];
            if (PlayerPrefs.GetInt("WeaponUnlocked" + weaponID) == 0)
            {
                weaponPrice = 30;
            }
            else if (PlayerPrefs.GetInt("WeaponUnlocked" + weaponID) == 1) {
                weaponPrice = 0;
            }
            
        }
        else if (weaponID == 2)
        {
            gunImage.sprite = gunSprites[2];
            if (PlayerPrefs.GetInt("WeaponUnlocked" + weaponID) == 0)
            {
                weaponPrice = 50;
            }
            else if (PlayerPrefs.GetInt("WeaponUnlocked" + weaponID) == 1)
            {
                weaponPrice = 0;
            }
        }
        else if (weaponID == 3)
        {
            gunImage.sprite = gunSprites[3];
            if (PlayerPrefs.GetInt("WeaponUnlocked" + weaponID) == 0)
            {
                weaponPrice = 70;
            }
            else if (PlayerPrefs.GetInt("WeaponUnlocked" + weaponID) == 1)
            {
                weaponPrice = 0;
            }            
        }

        if (weaponID > 3) {
            weaponID = 0;
        }
        else if (weaponID < 0) {
            weaponID = 3;
        }

        weaponPriceText.text = "" + weaponPrice;
    }

    public void BuyAndPlay() {
        if (point >= weaponPrice)
        {
            bgm.PlayOneShot(buttonSound);
            point -= weaponPrice;
            PlayerPrefs.SetInt("WeaponUnlocked" + weaponID, 1);
            PlayerPrefs.SetInt("WeaponID", weaponID);
            PlayerPrefs.SetInt("Point", point);
            SceneManager.LoadScene(gameScene, LoadSceneMode.Single);
        }
        else {
            bgm.PlayOneShot(noSound);
        }        
    }

    public void Play() {
        bgm.PlayOneShot(buttonSound);

        mainMenuAnimator.SetInteger("MenuID", 1);
    }

    public void Setting() {
        bgm.PlayOneShot(buttonSound);

        mainMenuAnimator.SetInteger("MenuID", 2);
    }

    public void Quit() {
        bgm.PlayOneShot(buttonSound);

        Application.Quit();
    }

    public void Back() {
        bgm.PlayOneShot(buttonSound);

        mainMenuAnimator.SetInteger("MenuID", 0);
    }

    public void SoundSetting() {
        bgm.PlayOneShot(buttonSound);

        if (bgm.volume == 1)
        {
            bgm.volume = 0;
            soundSettingImage.sprite = soundSettingSprite[1];
        }
        else {
            bgm.volume = 1;
            soundSettingImage.sprite = soundSettingSprite[0];
        }
    }

    public void LeftButton() {
        bgm.PlayOneShot(buttonSound);

        weaponID--;
    }

    public void RightButton() {
        bgm.PlayOneShot(buttonSound);

        weaponID++;
    }
}
