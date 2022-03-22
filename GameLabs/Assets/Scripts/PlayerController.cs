using Mirror;
using UnityEngine;
using Cinemachine; 

namespace Scripts
{
    public class PlayerController : NetworkBehaviour
    {
        //player
        [Header("Player Movement:")] public float walkSpeed = 4f;

        public float speedLimit = 0.7f;
        public float inputHorizontal;
        public float inputVertical;

        //Components
        private Rigidbody2D rb;

        [SerializeField] private CinemachineVirtualCamera fellowcam;


        // Start is called before the first frame update
        private void Start()
        {
            //gets the rigibody of the gameobject.
            rb = gameObject.GetComponent<Rigidbody2D>();

            if (isLocalPlayer)
            {
                fellowcam = CinemachineVirtualCamera.FindObjectOfType<CinemachineVirtualCamera>();
                fellowcam.LookAt = this.gameObject.transform;
                fellowcam.Follow = this.gameObject.transform;
            }
        }

        private void Update()
        {
            HandleMovement();
        }
        
        private void FixedUpdate()
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

        private void HandleMovement()
        {
            if (isLocalPlayer)
            {
                //checks the inputs and makes it 1, -1 or 0 depending on the button pressed.
                //Horizontal and Vertical are two things that depending the settings which button is bind to it.
                inputHorizontal = Input.GetAxisRaw("Horizontal");
                inputVertical = Input.GetAxisRaw("Vertical");
            }
        }
    }
}