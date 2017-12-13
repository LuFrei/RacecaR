using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    public Text instructionsText;

    public Text returnKeyText;

	// Use this for initialization
	void Start ()
    {
        instructionsText.text = "*Instructions Go Here*";

        returnKeyText.text = "I | Return to Main";
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.I))
            UIManager.instance.ChangeMenu(!GameManager.instance.isRunning ? Menus.Main : Menus.Pause);
	}
}