using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public Text timerText;
    float timer;

    private void Start()
    {
        timerText = GameObject.Find("Timer").GetComponent<Text>();
    }
    private void Update()
    {
        
        timer = timer + 1 * Time.deltaTime;
        timerText.text = "" + timer;
    }
}
