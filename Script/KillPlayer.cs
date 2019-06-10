using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    public LevelManager levelManager;
    public GameObject deathParticle;
    public LifeManager lifeSystem;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();

        lifeSystem = FindObjectOfType<LifeManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D eta)
    {
        if(eta.tag == "Player")
        {
            lifeSystem.AmbilNyawa();
            levelManager.RespawnPlayer();
        }
    }

}
