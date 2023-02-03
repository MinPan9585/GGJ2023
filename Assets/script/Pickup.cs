using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform player;
    public Transform pos;
    private bool picked = false;

    private void Update()
    {
        if(picked == true)
            this.transform.position = pos.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            picked = true;
            this.transform.parent = player;
            

        }
    }
}
