using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform player1;
    public Transform pos1;
    public Transform player2;
    public Transform pos2;
    private bool picked = false;
    private bool isPlayer1;
    public AudioClip pick;

    private void Update()
    {
        if(picked == true && isPlayer1)
        {
            this.transform.position = pos1.position;
        }
        else if(picked == true && !isPlayer1)
        {
            this.transform.position = pos2.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(picked == false)
        {
            if (other.gameObject.CompareTag("Player1"))
            {
                if (other.gameObject.GetComponent<palyercontrol1>().hasPickup == false)
                {
                    player1.GetComponent<palyercontrol1>().audios.PlayOneShot(pick);
                    isPlayer1 = true;
                    picked = true;
                    this.transform.parent = player1;
                    other.gameObject.GetComponent<palyercontrol1>().hasPickup = true;
                }
            }
            if (other.gameObject.CompareTag("Player2"))
            {
                if (other.gameObject.GetComponent<palyercontrol2>().hasPickup == false)
                {
                    player2.GetComponent<palyercontrol2>().audios.PlayOneShot(pick);
                    isPlayer1 = false;
                    picked = true;
                    this.transform.parent = player2;
                    other.gameObject.GetComponent<palyercontrol2>().hasPickup = true;
                }
            }
        }
    }
}
