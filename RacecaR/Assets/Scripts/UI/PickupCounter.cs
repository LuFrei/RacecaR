using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupCounter : MonoBehaviour {

    public Text text;
    public PlayerController player;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = "" + player.pickupCount;
    }
}
