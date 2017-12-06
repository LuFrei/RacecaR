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
            Debug.Log("A: " + player.reverse);
            player.reverse = !player.reverse;
            Debug.Log("B: " + player.reverse);
            Debug.Log("Player 1 just entered the bubble");
        }

        if (other.gameObject.name == "Player2")
        {
            player2.reverse = !player2.reverse;
            Debug.Log("Player 2 just entered the bubble");
        }
        Debug.Log("C: " + player.reverse);
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
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
    }*/
}
