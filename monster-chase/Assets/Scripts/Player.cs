using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveForce = 10f; // Variable that we are going to use to move the player.
                                     
    public float jumpForce = 11f; // Variable that we are going to use to manage jump movement.
   
    private float movementX;

    private Rigidbody rb;

    private SpriteRenderer sr;

    private Animator animator;

    private string WALK_ANIMATION = "Walk";

    // Start is called before the first frame update
    void Start()
    {
       
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}


