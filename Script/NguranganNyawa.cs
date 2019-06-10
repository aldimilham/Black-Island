using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NguranganNyawa : MonoBehaviour {

    public int damageToGive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D eta)
    {
        if (eta.name == "Player")
        {
            NyawaManager.HurtPlayer(damageToGive);

            var player = eta.GetComponent<PlayerController>();
            player.knockbackCount = player.knockbackLength;

            if (eta.transform.position.x < transform.position.x)
                player.knockFromRight = true;
            else
                player.knockFromRight = false;
        }
    }
}
