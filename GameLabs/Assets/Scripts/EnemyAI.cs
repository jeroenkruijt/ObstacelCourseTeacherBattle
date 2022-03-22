using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private GameObject[] players;
        [SerializeField] private GameObject closestPlayer;
        [SerializeField] private float slimeSpeed = 0.01f;
        [SerializeField] private float detectionRange = 25;
        [SerializeField] private int slimeHealth = 5;
        [SerializeField] private bool takenDamage;
        [SerializeField] private float attackCooldown = 1;

        private void Start()
        {
            players = GameObject.FindGameObjectsWithTag("Player");
        }
        private void Update()
        {
            int closestPlayerIndex = -1;
            float distanceMin = float.MaxValue;
            for (int i = 0; i < players.Length; i++)
            {
                PlayerSideInteraction aliveChecker = players[i].GetComponent<PlayerSideInteraction>();
                if (aliveChecker.health > 0)
                {
                    float distCheck = Vector3.Distance(players[i].transform.position, this.transform.position);
                    if (distCheck < distanceMin)
                    {
                        distanceMin = distCheck;
                        closestPlayerIndex = i;
                    }
                }
            }
            closestPlayer = players[closestPlayerIndex];

            if (distanceMin <= detectionRange)
            {
                transform.position = Vector3.MoveTowards(transform.position, closestPlayer.transform.position, slimeSpeed);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("attack"))
            {
                Debug.Log("bruh");
                StartCoroutine(takeDamage());
                if (slimeHealth <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }

        private IEnumerator takeDamage()
        {
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

    }
}
