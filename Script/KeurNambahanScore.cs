using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeurNambahanScore : MonoBehaviour {

    public int pointsToAdd;

    private void OnTriggerEnter2D(Collider2D naonweh)
    {
        if (naonweh.GetComponent<PlayerController>() == null)
            return;

        ScoreManager.AddPoints(pointsToAdd);

        gameObject.SetActive(false);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
