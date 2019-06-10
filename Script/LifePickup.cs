using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickup : MonoBehaviour {

    private LifeManager lifeSystem;

	// Use this for initialization
	void Start () {
        lifeSystem = FindObjectOfType<LifeManager>();
	}

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D naon)
    {
        if(naon.name == "Player")
        {
            lifeSystem.KasihNyawa();
            gameObject.SetActive(false);
        }
    }
}
