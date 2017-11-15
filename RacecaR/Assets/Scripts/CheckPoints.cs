using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public bool[] inactive = new bool[2];

    void Start()
    {
        //start = Mathf.Lerp(start,finish,0.1f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            Debug.Log("Boop. Player " + player.playerID + " just passed by " + gameObject.name);

            switch (player.playerID)
            {
                case 1:
                    inactive[0] = true;
                    break;
                case 2:
                    inactive[1] = true;
                    break;
            }

            player.checkpointCount++;
        }
    }
}