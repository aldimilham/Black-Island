using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NyawaManager : MonoBehaviour {

    public int maxPlayerHealth;

    public static int nyawaPlayer;

    Text text;

    private LevelManager levelManager;

    public bool isDead;

    private LifeManager lifeSystem;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();

        //nyawaPlayer = maxPlayerHealth;
        nyawaPlayer = PlayerPrefs.GetInt("PlayerCurrentHealth");

        lifeSystem = FindObjectOfType<LifeManager>();

        levelManager = FindObjectOfType<LevelManager>();

        isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(nyawaPlayer <= 0 && !isDead)
        {
            nyawaPlayer = 0;
            levelManager.RespawnPlayer();
            lifeSystem.AmbilNyawa();
            isDead = true;
        }

        text.text = "" + nyawaPlayer;
	}

    public static void HurtPlayer(int damageToGive)
    {
        nyawaPlayer -= damageToGive;
        PlayerPrefs.SetInt("PlayerCurrentHealth", nyawaPlayer);
    }

    public void FullHealth()
    {
        nyawaPlayer = PlayerPrefs.GetInt("PlayerMaxHealth"); 
    }
}
