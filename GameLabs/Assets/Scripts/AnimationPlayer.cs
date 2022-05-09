using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    public int Walking = 0;
    public bool Moving = false;
    private Animator _anim;
    public bool Attacking = false;
    public bool Interacting = false;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ifMoving();

        if (Input.GetAxis("Horizontal") > 0 && Moving == true) //animation moving right
        {
            Walking = 1;
            if (Walking == 1)
            {
                _anim.SetInteger("Direction", 0);
            }
        }
        else if (Input.GetAxis("Horizontal") < 0 && Moving == true) //animation moving left
        {
            Walking = -1;
            if (Walking == -1)
            {
                _anim.SetInteger("Direction", 1);
            }
        }

        if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") < 1 && Input.GetAxis("Horizontal") > -1 && Moving == true) //animation moving up
        {
            Walking = 2;
            if (Walking == 2)
            {
                _anim.SetInteger("Direction", 2);
            }
        }
        else if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") < 1 && Input.GetAxis("Horizontal") > -1 && Moving == true) //animation moving down
        {
            Walking = 3;
            if (Walking == 3)
            {
                _anim.SetInteger("Direction", 3);
            }
        }
        if (Input.GetKeyDown("u")) //animation for attacking
        {
            Attacking = true;
            if (Attacking)
            {
                _anim.SetBool("Attacking", true);
            }

        }

        if (Input.GetAxis("Interact") > 0f) //animation for interaction
        {
            Interacting = true;
            if (Interacting)
            {
                _anim.SetBool("Interacting", true);
            }

        }
    }

    private void ifMoving() //used for checking if should be idle or not
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Moving = true;
            if (Moving == true)
            {
                _anim.SetBool("Moving", true);
            }
        }
        else
        {
            Moving = false;
            if (Moving == false)
            {
                _anim.SetBool("Moving", false);
            }
        }
    }
}
