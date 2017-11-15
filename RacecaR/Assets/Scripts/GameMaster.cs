using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public Text timerText;
    float timer;
    public bool inversion;

    private void Start()
    {
        timerText = GameObject.Find("Timer").GetComponent<Text>();
    }
    private void Update()
    {
        
        timer = timer + 1 * Time.deltaTime;
        timerText.text = "" + timer;

        if (timer >= 25)
        {
            inversion = true;
        }
    }
}
