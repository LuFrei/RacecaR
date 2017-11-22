using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public GameObject startScreen;
    public GameObject playerSelect;

    private void Start()
    {
        startScreen.SetActive(true);
        playerSelect.SetActive(false);

    }

    public void SwitchToPlayerSelect()
    {
        startScreen.SetActive(false);
        playerSelect.SetActive(true);
    }

    public void SwitchToStartScreen()
    {
        startScreen.SetActive(true);
        playerSelect.SetActive(false);
    }

}
