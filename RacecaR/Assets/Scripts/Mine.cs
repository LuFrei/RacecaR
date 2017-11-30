using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {


    public PlayerController player;
    public PlayerController player2;

    public float bufferTimer = 2;



    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        player2 = GameObject.Find("Player2").GetComponent<PlayerController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if(player.reverse == true)
            {
                player.reverse = false;
            }
            if(player.reverse == false)
            {
                player.reverse = true;
            }
            //player.reverse = !player.reverse;
            Debug.Log("Player 1 just entered the bubble");
        }

        if (other.gameObject.name == "Player2")
        {
            if (player2.reverse == true)
            {
                player2.reverse = false;
            }
            if (player2.reverse == false)
            {
                player2.reverse = true;
            }
            //player2.reverse = !player2.reverse;
            Debug.Log("Player 2 just entered the bubble");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (player.reverse == true)
            {
                player.reverse = true;
            }
            if (player.reverse == false)
            {
                player.reverse = false;
            }
            //player.reverse = player.reverse;
            Debug.Log("Player 1 just left the bubble");
        }

        if (other.gameObject.name == "Player2")
        {
            if (player2.reverse == true)
            {
                player2.reverse = true;
            }
            if (player2.reverse == false)
            {
                player.reverse = false;
            }
            //player2.reverse = player2.reverse;
            Debug.Log("Player 2 jusleftt entered the bubble");
        }
    }
}
