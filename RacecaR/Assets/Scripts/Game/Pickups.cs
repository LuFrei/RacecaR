using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public PlayerController player;
    public PlayerController player2;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        player2 = GameObject.Find("Player2").GetComponent<PlayerController>();
    }

    void Update()
    {
        //animate the object
        transform.Rotate(1, 1, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if player1 touches pickup, they get 1 pickup

        if (other.gameObject.name == "Player" && player.pickupCount == 0)
        {

            if(gameObject.tag == "Pickup A")
            {
                player.pickupCount = 1;
            }

            if (gameObject.tag == "Pickup B")
            {
                player.pickupCount = 2;
            }

            if (gameObject.tag == "Pickup C")
            {
                player.pickupCount = 3;
            }

            Destroy(gameObject);
        }

        if (other.gameObject.name == "Player2" && player2.pickupCount == 0)
        {

            if (gameObject.tag == "Pickup A")
            {
                player2.pickupCount = 1;
            }

            if (gameObject.tag == "Pickup B")
            {
                player2.pickupCount = 2;
            }

            if (gameObject.tag == "Pickup C")
            {
                player2.pickupCount = 3;
            }

            Destroy(gameObject);
        }
    }
}