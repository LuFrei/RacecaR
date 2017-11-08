using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour {

    public PlayerController player;
    public Player2Controller player2;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        player2 = GameObject.Find("Player2").GetComponent<Player2Controller>();
    }
    private void Update()
    {
        //animate the object
        transform.Rotate(1, 1, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if player1 touches pickup, they get 1 pickup
        if (other.gameObject.name == "Player" && player.pickupCount < 1)
        {
            player.pickupCount += 1;
            Destroy(gameObject);
        }

        if (other.gameObject.name == "Player2" && player2.pickupCount < 1)
        {
            player2.pickupCount += 1;
            Destroy(gameObject);
        }
    }
}
