using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tempPos = transform.position; // Current position of the camera
        tempPos.x = player.position.x; // Sets x axis current position of the camera = player's current x axis position
        
        if(tempPos.x < minX) { tempPos.x = minX; } // Here we set the camera limits 
        if(tempPos.x > maxX) { tempPos.x = maxX; } // Here we set the camera limits

        transform.position = tempPos; // Assigns the new value back to the current position of the camera
    }
} // class
