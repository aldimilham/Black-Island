using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour {

    //public int nyawaAwal;
    private int penghitungNyawa;

    private Text theText;

    public GameObject gameOverScreen;

    public PlayerController player;

    public string mainMenu;

    public float waitAfterGameOver;

	// Use this for initialization
	void Start () {
        theText = GetComponent<Text>();

        penghitungNyawa = PlayerPrefs.GetInt("PlayerCurrentLives");

        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        if(penghitungNyawa == 0)
        {
            gameOverScreen.SetActive(true);
            player.gameObject.SetActive(false);
        }
        theText.text = "x " + penghitungNyawa;

        if (gameOverScreen.activeSelf)
        {
            waitAfterGameOver -= Time.deltaTime;
        }

        if(waitAfterGameOver < 0)
        {
            
        }
	}

    public void KasihNyawa()
    {
        penghitungNyawa++;
        PlayerPrefs.SetInt("PlayerCurrentLives", penghitungNyawa);
    }

    public void AmbilNyawa()
    {
        penghitungNyawa--;
        PlayerPrefs.SetInt("PlayerCurrentLives", penghitungNyawa);
    }
}
