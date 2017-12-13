using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public Text creditsText;

    public Button returnButton;
    public Button settingsButton;

	// Use this for initialization
	void Start ()
    {
        creditsText.text = 
            "Renso Hernandez - Programmer/Menu System\n" +
            "";

        returnButton.onClick.AddListener(onReturn);
        settingsButton.onClick.AddListener(onSettings);
    }
	
	void onReturn()
    {
        UIManager.instance.ChangeMenu(Menus.Main);
    }

    void onSettings()
    {
        UIManager.instance.ChangeMenu(Menus.Settings);
    }
}