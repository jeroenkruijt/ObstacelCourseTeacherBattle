using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class ScuffedPlayerController : MonoBehaviour
    {
    //This script only exists for testing purposes - it removes the need for a player to be connected to networkbehaviour

    //Components
    Rigidbody2D rb;
    
    //player
    [Header("Player Movement:")] 
    public float walkSpeed = 4f;
    public float speedLimit = 0.7f;
    public float inputHorizontal;
    public float inputVertical;
    public float direction = 0;


    // Start is called before the first frame update
    void Start()
    {
        //gets the rigibody of the gameobject.
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //checks the inputs and makes it 1, -1 or 0 depending on the button pressed.
        //Horizontal and Vertical are two things that depending the settings which button is bind to it.
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        if (inputHorizontal == 1) {
                direction = 0;
        }
        else if (inputHorizontal == -1)
        {
                direction = 1;
        }
        else if (inputVertical == 1)
        {
                direction = 2;          
        }
        else if (inputVertical == -1)
        {
                direction = 3;            
        }

        if (Input.GetKeyDown("p"))
        {
            RestartLevel();
        }
           
    }

    void FixedUpdate()
    {
        //goes to check what value is in these variables and adding the force to move the player
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            if (inputHorizontal != 0 && inputVertical != 0)
            {
                inputHorizontal *= speedLimit;
                inputVertical *= speedLimit;
            }
            
            rb.velocity = new Vector2(inputHorizontal * walkSpeed, inputVertical * walkSpeed);
        }
        else
        {
                        rb.velocity = new Vector2(0f, 0f);
        }
        
    }
    
    void RestartLevel() //Restarts the level
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
}
