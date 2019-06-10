using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraControl : MonoBehaviour
{

    public GameObject player;       
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;       
    
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");  //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
