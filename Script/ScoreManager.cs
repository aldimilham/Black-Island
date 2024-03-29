﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static int score;

    public Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();

        //score = 0;

        score = PlayerPrefs.GetInt("CurrentPlayerScore");
	}
	
	// Update is called once per frame
	void Update () {
        if (score < 0)
            score = 0;


        text.text = "" + score;
	}

    public static void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
        PlayerPrefs.SetInt("CurrentPlayerScore", score);
    }

    public static void Reset()
    {
        score = 0;
        PlayerPrefs.SetInt("CurrentPlayerScore", score);
    }
}
