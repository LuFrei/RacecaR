using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints1 : MonoBehaviour {

    public PlayerController PC;
    public GameObject player1;
    public bool active;
    void Start()
    {
        player1 = GameObject.Find("Player");
        PC = player1.GetComponent<PlayerController>();
        
        active = true;
    }
    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(player1) && active)
        {
            Debug.Log("Boop. Player1 just passed by " + gameObject.name);
            active = false;
            PC.cpCount += 1;
        }
    }
}
