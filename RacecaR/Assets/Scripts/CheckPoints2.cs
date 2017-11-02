using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints2 : MonoBehaviour {

    public Player2Controller PC;
    public GameObject player;
    public bool active;
    void Start()
    {
        player = GameObject.Find("Player2");
        PC = player.GetComponent<Player2Controller>();

        //start = Mathf.Lerp(start,finish,0.1f);
        
        active = true;
    }
    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(player) && active)
        {
            Debug.Log("Boop. Player1 just passed by " + gameObject.name);
            active = false;
            PC.cpCount += 1;
        }
    }
}
