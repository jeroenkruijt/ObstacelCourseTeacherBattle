using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class EnemyAI : MonoBehaviour
    {
        //create an array of all the players, a gameobject to store the closest one, a float to decide the movement speed of the slime, a float that decides the detection range of the slime, an int that stores its health
        // a bool to grant brief invulnerability when it takes damage and a float to decide its attack cooldown time
        [SerializeField] private GameObject[] players;
        [SerializeField] private GameObject closestPlayer;
        [SerializeField] private float slimeSpeed = 0.01f;
        [SerializeField] private float detectionRange = 25;
        [SerializeField] private int slimeHealth = 5;
        [SerializeField] private bool takenDamage;
        [SerializeField] private float attackCooldown = 1;
        Vector3 targetPos;
        public Animator _anim;

        private void Start()
        {
            _anim = GetComponent<Animator>();
        }
        private void FixedUpdate()
        {
            //find all of the players and add them to the array
            players = GameObject.FindGameObjectsWithTag("Player");
            //set the closestplayer to a nonexistent one with the highest possible distance
            int closestPlayerIndex = -1;
            float distanceMin = float.MaxValue;
            for (int i = 0; i < players.Length; i++)
            {
                //check if the player is alive, if so get the distance to it
                PlayerSideInteraction aliveChecker = players[i].GetComponent<PlayerSideInteraction>();
                if (aliveChecker.health > 0)
                {
                    float distCheck = Vector3.Distance(players[i].transform.position, this.transform.position);
                    //compare the distances to get the closest one
                    if (distCheck < distanceMin)
                    {
                        distanceMin = distCheck;
                        closestPlayerIndex = i;
                    }
                }
            }

            closestPlayer = players[closestPlayerIndex];
            targetPos = new Vector3(closestPlayer.transform.position.x, (closestPlayer.transform.position.y-0.9f), transform.position.z);
            //if the distance is less that the detection range move towards them
            if (distanceMin <= detectionRange)
            {
                _anim.SetBool("Moving", true);
                transform.position = Vector3.MoveTowards(transform.position, targetPos, slimeSpeed);
            }
            else
            {
                _anim.SetBool("Moving", false);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            //if the slime touches an attack hitbox it takes damage but is granted brief invulnerability
            //if the slime's health is at or below zero after taking damage, destroy it
            if (other.CompareTag("attack"))
            {
                Debug.Log("bruh");
                StartCoroutine(takeDamage());
                if (slimeHealth <= 0)
                {
                    StartCoroutine(almostDead());
                }
            }
        }

        private IEnumerator takeDamage()
        {
            //if the slime hasnt taken damage within the last second, its health decreases by one
            if (!takenDamage)
            {
                slimeHealth--;
                takenDamage = true;
            }
            yield return new WaitForSeconds(1);
            takenDamage = false;
        }

        private IEnumerator dealDamage()
        {
            //this function is called in PlayerSideInteraction. the player's gofuckyourself function is called, then the slime waits for its attack cooldown
            bool Iframes = false;
            while (Vector3.Distance(closestPlayer.transform.position, this.transform.position) <= 1)
            {
                if (!Iframes)
                {
                    closestPlayer.SendMessage("goFuckYourself");
                    Iframes = true;
                }
                yield return new WaitForSeconds(attackCooldown);
                Iframes = false;
            }
        }
        private IEnumerator almostDead()
        {
            _anim.SetBool("Dead", true);
            slimeSpeed = 0;
            yield return new WaitForSeconds(1);
            Destroy(gameObject);
        }

    }
}
