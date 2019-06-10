using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {

    public GameObject gameFinished;

    public PlayerController player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            gameFinished.SetActive(true);
            player.gameObject.SetActive(false);
        }
    }
}
