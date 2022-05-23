using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Scripts {
    public class AnimationPlayer : MonoBehaviour
    {
        public int Walking = 0;
        public bool Moving = false;
        public bool Attacking = false;
        public bool Interacting = false;
        public bool ded = false;
        public bool respawn = false;
        [SerializeField] private Animator _anim;
        [SerializeField] private PlayerSideInteraction InteractScript;
        [SerializeField] private PlayerControllerNew controller;

        // Update is called once per frame
        void Update()
        {
            ifMoving();
            if (Moving)
            {
                if (controller.direction == 0) //animation moving right
                {
                    Walking = 1;
                    if (Walking == 1)
                    {
                        _anim.SetInteger("Direction", 0);
                    }
                }
                
                 else if (controller.direction == 1) //animation moving left
                {
                    Walking = -1;
                    if (Walking == -1)
                    {
                        _anim.SetInteger("Direction", 1);
                    }
                }

                else if (controller.direction == 2)
                {
                    Walking = 2;
                    if (Walking == 2)
                    {
                        _anim.SetInteger("Direction", 2);
                    }
                }

                //if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") < 1 && Input.GetAxis("Horizontal") > -1) //animation moving up
                //{
                    
                //}
                else if (controller.direction == 3) //animation moving down
                {
                    Walking = 3;
                    if (Walking == 3)
                    {
                        _anim.SetInteger("Direction", 3);
                    }
                }
            }
            
            //if (Input.GetKeyDown("u")) //animation for attacking
            //{
            //    Attacking = true;
            //    if (Attacking)
            //    {
            //        _anim.SetBool("Attacking", true);
            //    }

            //}

            //if (Input.GetAxis("Interact") > 0f) //animation for interaction
            //{
            //    Interacting = true;
            //    if (Interacting)
            //    {
            //        _anim.SetBool("Interacting", true);
            //    }
            //}
            //if (InteractScript.died == true)
            //{
            //    ded = true;
            //    if (ded)
            //    {
            //        _anim.SetBool("rudead", true);
            //    }
            //}
        
        //    if (InteractScript.Respawn == true)
        //    {
        //        respawn = true;
        //        if (respawn)
        //        {
        //            _anim.SetBool("AliveAgain", true);
        //        }
        //    }
        }

        void GetHitAnimation()
        {
            _anim.SetBool("IsHit", true);
        }

        void AttackAnimation()
        {
            if (Attacking)
            {
                _anim.SetBool("Attacking", false);
                Attacking = true;
            }
            else
            {
                _anim.SetBool("Attacking", true);
                Attacking = false;
            }
        }

        void InteractAnimation()
        {
            _anim.SetBool("Interacting", true);
        }

        void DeathAnimation()
        {
            _anim.SetBool("rudead", true);
        }

        void hugeRez()
        {
            _anim.SetBool("AliveAgain", true);
        }

            private void ifMoving() //used for checking if should be idle or not
        {
            if (controller.walkInput.x != 0 || controller.walkInput.y != 0)
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
}
