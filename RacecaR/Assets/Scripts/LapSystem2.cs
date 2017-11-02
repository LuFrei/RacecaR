using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapSystem2 : MonoBehaviour {

    public int lapCount;
    public Text text;
    public Player2Controller player;

	// Use this for initialization
	void Start () {
        text = gameObject.GetComponent<Text>();
        player = GameObject.Find("Player2").GetComponent<Player2Controller>();
	}
	
	// Update is called once per frame
	void Update () {
        lapCount = player.lap ;

        text.text = "" + lapCount;
	}
}
