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
            player.pickupCount += Random.Range(1, 4);
            Destroy(gameObject);
        }

        if (other.gameObject.name == "Player2" && player2.pickupCount == 0)
        {
            player2.pickupCount += Random.Range(1, 4);
            Destroy(gameObject);
        }
    }
}