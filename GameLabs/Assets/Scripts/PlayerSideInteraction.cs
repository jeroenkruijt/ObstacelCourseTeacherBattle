using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class PlayerSideInteraction : MonoBehaviour
    {
        //create: gameobject that stores an object for interaction, a gameobject that stores the attack hitbox to instantiate upon attacking, some ints for the stats and a gameobject that links it to the health bar
        [SerializeField]
        public GameObject inRange = null;
        [SerializeField]
        public GameObject attackHitbox;
        [Header("Stats:")]
        [SerializeField]
        public int health = 15;
        [SerializeField]
        int armor = 0;
        [SerializeField]
        int damage = 1;
        //[SerializeField]
        //private GameObject healthbar;
        [SerializeField]
        private int team;
        [SerializeField]
        private GameObject manager;
        [SerializeField]
        private bool playingPiano = false;
        PlayerControllerNew controller;
        [SerializeField]
        private int deaths;
        public bool Respawn = false;
        public int playerID;
        public Slider healthBar;
        [SerializeField] AnimationPlayer animatorScript;
        [SerializeField] playerManager PM;

        private void Start()
        {
            //FindObjectOfType<AudioManager>().Play("Piano12");
            controller = gameObject.GetComponent<PlayerControllerNew>();
            GameObject target = GameObject.Find("playermanager");
            PM = target.GetComponent<playerManager>();
            PM.SendMessage("joinPlayer");
            manager = GameObject.FindGameObjectWithTag("manager");
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            //if the player enters an object's interaction range said object is stored to interacti with
            if (other.CompareTag("Interactable"))
            {
                Debug.Log("notices your player UwU");
                inRange = other.gameObject;
            }

            //if the player comes into contact with an enemy, the enemy's deal damage function is called, damaging the player
            if (other.CompareTag("Enemy"))
            {
                Debug.Log("hahaha");
                other.SendMessage("dealDamage");
            }

        }
        void OnTriggerExit2D(Collider2D other)
        {
            //if the player leaves an object's interaction range remove it from the storage
            if (other.CompareTag("Interactable") && other.gameObject == inRange)
            {
                Debug.Log("Don't leave me :(");
                inRange = null;
            }
        }

        void progress()
        {
            if (team == 1) manager.SendMessage("progress1");
            else manager.SendMessage("progress2");
            Debug.Log("sent over progress");
        }

        private void playPiano()
        {
            playingPiano = true;
            
            controller.walkSpeed = 0f;
        }
        void Update()
        {
            //do stuff when you press buttons, interact interacts with the stored object and attack calls the attack function
            //if (Input.GetButtonDown("Interact") && inRange)
            //{
            //    inRange.SendMessage("DoInteraction");
            //}

            //if (Input.GetButtonDown("Attack"))
            //{
            //    StartCoroutine(attack());
            //}
            healthBar.value = health;

            if (Input.GetKeyDown(KeyCode.K))
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                for (int i = 0; i < enemies.Length; i++)
                {
                    EnemyAI enemyscript = enemies[i].GetComponent<EnemyAI>();
                    enemyscript.enabled = false;
                }
            }

            if (playingPiano)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    FindObjectOfType<AudioManager>().Play("Piano7");
                    inRange.SendMessage("KeyOne");
                    playingPiano = false;
                    controller.walkSpeed = 4f;
                }
                else if (Input.GetKeyDown(KeyCode.T))
                {
                    FindObjectOfType<AudioManager>().Play("Piano12");
                    inRange.SendMessage("KeyTwo");
                    playingPiano = false;
                    controller.walkSpeed = 4f;
                }
                else if (Input.GetKeyDown(KeyCode.Y))
                {
                    FindObjectOfType<AudioManager>().Play("Piano18");
                    inRange.SendMessage("KeyThree");
                    playingPiano = false;
                    controller.walkSpeed = 4f;
                }
                else if (Input.GetKeyDown(KeyCode.Escape))
                {
                    inRange.SendMessage("Exit");
                    playingPiano = false;
                    controller.walkSpeed = 4f;
                }
            }
            //if a player dies, turn off their functionality and teleport them away (dont destroy them because that causes communication issues)
            if (health <= 0)
            {
                StartCoroutine(die());
            }
        }

        private IEnumerator die()
        {
            animatorScript.SendMessage("DeathAnimation");
            health = 15;
            gameObject.GetComponent<PlayerControllerNew>().enabled = false;
            gameObject.GetComponent<PlayerSideInteraction>().enabled = false;
            transform.position = new Vector3(99, 99, 99);
            controller.walkSpeed = 0;
            deaths++;
            yield return new WaitForSeconds(deaths * 5);
            transform.position = new Vector3(0, 5, -1);
            StartCoroutine(respawn());
        }

        private IEnumerator respawn()
        {
            animatorScript.SendMessage("hugeRez");
            yield return new WaitForSeconds(1);
            gameObject.GetComponent<PlayerControllerNew>().enabled = true;
            gameObject.GetComponent<PlayerSideInteraction>().enabled = true;
            controller.walkSpeed = 4f;
            
        }

        public IEnumerator attack()
        {
            //take the direction from the player controller and create an attack hitbox on that side of the player
            animatorScript.SendMessage("AttackAnimation");
            GameObject fist = Instantiate(attackHitbox);
            PlayerControllerNew pointing = gameObject.GetComponent<PlayerControllerNew>();

            if (pointing.direction == 0)
            {
                fist.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z);
            }
            else if (pointing.direction == 1)
            {
                fist.transform.position = new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z);
            }
            else if (pointing.direction == 2)
            {
                fist.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
            }
            else if (pointing.direction == 3)
            {
                fist.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1, this.transform.position.z);
            }
            yield return new WaitForSeconds(0.5f);
            animatorScript.SendMessage("AttackAnimation");
            Destroy(fist);
            Debug.Log("bonk go to horny jail");
        }

        public void goFuckYourself()
        {
            //take 3 damage but reduce it by the player's armor, then update the healthbar
            animatorScript.SendMessage("GetHitAnimation");
            health -= (3 - armor);
            float healthbarstuff = (0.26f * health);
            Debug.Log(healthbarstuff);
            //healthbar.transform.localScale = new Vector3(healthbarstuff, 0.1f, 1);
            //healthbar.transform.position += new Vector3(-0.5f*healthbarstuff, 0, 0);
        }

        public void HealthBuff()
        {
            //self explanatory
            health++;
        }

        public IEnumerator ArmorBuff()
        {
            //sets an int to the player's armor then gives the player 1 armor. if the player has more armor than before after 5 seconds, 1 armor is removed.
            int preBuffArmor = armor;
            armor++;
            yield return new WaitForSeconds(5);
            if (armor > preBuffArmor)
            {
                armor--;
            }
        }

        public IEnumerator SpeedBuff()
        {
            // gets a scuffedplayercontroller from the object this is attached to and sets it walkspeed to 10 for 5 seconds, then sets it back to FOUR
            ScuffedPlayerController target = gameObject.GetComponent<ScuffedPlayerController>();
            target.walkSpeed = 10f;
            yield return new WaitForSeconds(5);
            target.walkSpeed = 4f;
        }

        public IEnumerator DamageBuff()
        {
            // same thing as with armor but with damage instead
            int preBuffDamage = damage;
            damage++; 
            yield return new WaitForSeconds(5);
            if (damage > preBuffDamage)
            {
                damage--;
            }
        }

    }
}
