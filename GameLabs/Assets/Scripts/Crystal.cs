using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Scripts
{
    public class Crystal : MonoBehaviour
    {
        [SerializeField] private int CorrectPlayer;
        [SerializeField] private Sprite Glow;
        [SerializeField] private GameObject restartPos;
        // Start is called before the first frame update
        void Start()
        {

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("ICU");
            PlayerSideInteraction PSI = other.GetComponent<PlayerSideInteraction>();
            if (PSI.playerID == CorrectPlayer)
            {
                SpriteRenderer SR = GetComponent<SpriteRenderer>();
                SR.sprite = Glow;
            }
            else if (other.tag == "Player")
            {
                other.transform.position = restartPos.transform.position;
            }
        }
    }

}

