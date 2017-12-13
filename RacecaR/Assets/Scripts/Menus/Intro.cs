using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{	
	// Update is called once per frame
	void Update ()
    {
        if (Input.anyKeyDown)
            UIManager.instance.ChangeMenu(Menus.Main);
	}
}