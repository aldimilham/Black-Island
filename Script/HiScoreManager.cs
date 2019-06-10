using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text hiScoreText;

    public float hiScoreCount;

    private ScoreManager SM;

	// Use this for initialization
	void Start () {
        SM = GetComponent<ScoreManager>();

        if(PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("highScore");
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (ScoreManager.score > hiScoreCount)
        {
            hiScoreCount = ScoreManager.score;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);
        }

        scoreText.text = "SCORE ANDA : " + ScoreManager.score;
        hiScoreText.text = "HIGH SCORE : " + hiScoreCount;
    }
}
