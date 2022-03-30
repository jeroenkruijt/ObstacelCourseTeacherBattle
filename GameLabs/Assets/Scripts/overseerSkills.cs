using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overseerSkills : MonoBehaviour
{
    [SerializeField] private GameObject[] players;
    private GameObject target;
    bool healthUseable = true;
    bool armorUseable = true;
    bool damageUseable = true;
    bool speedUseable = true;
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    private void Update()
    {
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
