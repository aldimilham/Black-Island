using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;

    private PlayerController player;
    public GameObject respawnParticle;
    public GameObject deathParticle;

    public int pointMunPaeh;

    public float respawnDelay;

    public NyawaManager nyawaManager;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();

        nyawaManager = FindObjectOfType<NyawaManager>();
	}
    // Update is called once per frame
    void Update () {
		
	}

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo", 1f);
    }

    public IEnumerator RespawnPlayerCo()
    {
        Debug.Log("Player Respawn");
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        player.gameObject.SetActive(false);
        player.GetComponent<Renderer>().enabled = false;
        ScoreManager.AddPoints(-pointMunPaeh);
        yield return new WaitForSeconds(respawnDelay);
        player.transform.position = currentCheckpoint.transform.position;
        player.gameObject.SetActive(true);
        player.GetComponent<Renderer>().enabled = true;
        player.knockbackCount = 0;
        nyawaManager.FullHealth();
        nyawaManager.isDead = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
