using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public LevelManager levelManager;
    private Animator anim;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D eta)
    {
        if(eta.tag == "Player")
        {
            anim.SetTrigger("Checked");
            levelManager.currentCheckpoint = gameObject;
        }
    }

}
