using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class PlayerSideInteraction : MonoBehaviour
    {
        [SerializeField]
        public GameObject inRange = null;
        [SerializeField]
        public GameObject attackHitbox;
        [Header("Stats:")]
        [SerializeField]
        public int health = 5;
        [SerializeField]
        int armor = 0;
        [SerializeField]
        int damage = 1;
        [SerializeField]
        private GameObject healthbar;


        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Interactable"))
            {
                Debug.Log("notices your player UwU");
                inRange = other.gameObject;
            }

            if (other.CompareTag("Enemy"))
            {
                Debug.Log("hahaha");
                other.SendMessage("dealDamage");
            }

        }
        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Interactable") && other.gameObject == inRange)
            {
                Debug.Log("Don't leave me :(");
                inRange = null;
            }
        }

        void Update()
        {
            if (Input.GetButtonDown("Interact") && inRange)
            {
                inRange.SendMessage("DoInteraction");
            }

            if (Input.GetButtonDown("Attack"))
            {
                StartCoroutine(attack());
            }

            if (health <= 0)
            {
                gameObject.GetComponent<ScuffedPlayerController>().enabled = false;
                gameObject.GetComponent<PlayerSideInteraction>().enabled = false;

                transform.position = new Vector3(99, 99, 99);

                ScuffedPlayerController target = gameObject.GetComponent<ScuffedPlayerController>();
                target.walkSpeed = 0;
            }
        }

        public IEnumerator attack()
        {
            GameObject fist = Instantiate(attackHitbox);
            ScuffedPlayerController pointing = gameObject.GetComponent<ScuffedPlayerController>();

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
            Destroy(fist);
            Debug.Log("bonk go to horny jail");
        }

        public void goFuckYourself()
        {
            health -= (3 - armor);
            float healthbarstuff = (0.26f * health);
            Debug.Log(healthbarstuff);
            healthbar.transform.localScale = new Vector3(healthbarstuff, 0.2f, 1);
            healthbar.transform.position += new Vector3(-0.5f*healthbarstuff, 0, 0);
        }

        public void HealthBuff()
        {
            health++;
        }

        public IEnumerator ArmorBuff()
        {
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
            ScuffedPlayerController target = gameObject.GetComponent<ScuffedPlayerController>();
            target.walkSpeed = 10f;
            yield return new WaitForSeconds(5);
            target.walkSpeed = 4f;
        }

        public IEnumerator DamageBuff()
        {
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
