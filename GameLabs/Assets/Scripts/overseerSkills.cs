using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overseerSkills : MonoBehaviour
{
    //create an array of players and some bools to indicate whether or not a buff is ready for use
    [SerializeField] private GameObject[] players;
    //private GameObject target;
    bool healthUseable = true;
    bool armorUseable = true;
    bool damageUseable = true;
    bool speedUseable = true;
    void Start()
    {
        //adds all players to the array
        players = GameObject.FindGameObjectsWithTag("Team1Player");
        players = GameObject.FindGameObjectsWithTag("Team2Player");

    }

    private void Update()
    {
        //calls a function based on the button pressed (alpha means number on the keyboard, so its numbers 1-4)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(sendHealthBuff());
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(sendArmorBuff());
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(sendDamageBuff());
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            StartCoroutine(sendSpeedBuff());
        }
    }

    private IEnumerator sendHealthBuff()
    { 
        // if the healthbuff is useable it is called in PlayerSideInteraction, then set to non-useable for 5 seconds
        if (healthUseable == true)
        {
            for (int i = 0; i < players.Length; i++)
            {
                players[i].SendMessage("HealthBuff");
            }
            healthUseable = false;
            yield return new WaitForSeconds(5);
            healthUseable = true;
        }
    }

    private IEnumerator sendArmorBuff()
    {
        // if the armorbuff is useable it is called in PlayerSideInteraction, then set to non-useable for 5 seconds
        if (armorUseable == true)
        {
            for (int i = 0; i < players.Length; i++)
            {
                players[i].SendMessage("ArmorBuff");
            }
            armorUseable = false;
            yield return new WaitForSeconds(5);
            armorUseable = true;
        }
    }

    private IEnumerator sendDamageBuff()
    {
        if (damageUseable == true)
        {
            // if the damagebuff is useable it is called in PlayerSideInteraction, then set to non-useable for 5 seconds
            for (int i = 0; i < players.Length; i++)
            {
                players[i].SendMessage("DamageBuff");
            }
            damageUseable = false;
            yield return new WaitForSeconds(5);
            damageUseable = true;
        }
    }

    private IEnumerator sendSpeedBuff()
    {
        if (speedUseable == true)
        {
            // if the speedbuff is useable it is called in PlayerSideInteraction, then set to non-useable for 5 seconds
            for (int i = 0; i < players.Length; i++)
            {
                players[i].SendMessage("SpeedBuff");
            }
            speedUseable = false;
            yield return new WaitForSeconds(5);
            speedUseable = true;
        }
    }
}
