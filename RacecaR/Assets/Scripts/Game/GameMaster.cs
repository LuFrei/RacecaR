using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public Text timerText;
    float timer;
    public bool inversion;

    public PlayerController player;
    public PlayerController player2;
    public float inverseDuration = 0;
    public float inverseCountdown;

    private void Start()
    {
        inverseCountdown = Random.Range(15f, 20f);
        timerText = GameObject.Find("Timer").GetComponent<Text>();
    }
    private void Update()
    {
        
        timer = timer + 1 * Time.deltaTime;
        timerText.text = "" + timer;

        /*if (timer >= 25)
        {
            inversion = true;
        }*/

        if (inverseDuration > 0)
        {
            inverseDuration -= 1 * Time.deltaTime;
        }

        if (inverseCountdown > 0)
        {
            inverseCountdown -= 1 * Time.deltaTime;
        }

        if(inverseCountdown <= 0)
        {
            inverseDuration = Random.Range(4f, 10f);
            player.reverse = true;
            player2.reverse = true;
        }

        if(inverseDuration <= 0)
        {
            inverseCountdown = Random.Range(15f, 25f);
            player.reverse = false;
            player2.reverse = false;
        }


    }
}
