using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class PlayerControllerNew : MonoBehaviour
    {
        CharacterController Controller;
        public Vector2 walkInput;
        Rigidbody2D rb;
        public float walkSpeed = 4f;
        PlayerSideInteraction interactionScript;
        public float direction = 0;
        [SerializeField] AnimationPlayer animator;
        private void Start()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
            Controller = GetComponent<CharacterController>();
            interactionScript = GetComponent<PlayerSideInteraction>();
        }
        public void onWalk(InputAction.CallbackContext context)
        {
            walkInput = context.ReadValue<Vector2>();
            if (walkInput.x == 1) direction = 0;                                   
            else if (walkInput.x == -1) direction = 1;
            else if (walkInput.y == 1) direction = 2;
            else if (walkInput.y == -1) direction = 3;
        }

        public void onInteract(InputAction.CallbackContext context)
        {
            animator.SendMessage("InteractAnimation");
            if (interactionScript.inRange != null) interactionScript.inRange.SendMessage("DoInteraction");
        }

        public void onAttack(InputAction.CallbackContext context)
        {
            interactionScript.SendMessage("attack");
        }

        public void OnEscape(InputAction.CallbackContext context)
        {
            interactionScript.SendMessage("Escaping");
        }

        public void OnPianoPlayR(InputAction.CallbackContext context)
        {
            interactionScript.SendMessage("RPress");
        }

        public void OnPianoPlayT(InputAction.CallbackContext context)
        {
            interactionScript.SendMessage("TPress");
        }

        public void OnPianoPlayY(InputAction.CallbackContext context)
        {
            interactionScript.SendMessage("YPress");
        }


        private void FixedUpdate()
        {
            rb.velocity = walkInput * walkSpeed;
        }
        private void Update()
        {
            if (Input.GetKeyDown("p"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            if (Input.GetKeyDown("l"))
            {
                Application.Quit();
            }
        }
    }
}

