using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum Menus
{
    Intro,
    Main,
    Credits,
    VehicleSelection,
    StageSelection,
    Instructions,
    Settings,
    Pause
}

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject[] currentSceneMenus;

    public int numOfMenus;
    public int numOfMainMenus;
    public int numOfRuntimeMenus;

    public Menus currentMenu;
    public Menus previousMenu;

    void Awake()
    {
        instance = this;

        numOfMenus = System.Enum.GetNames(typeof(Menus)).Length;
    }

    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {
		if (GameManager.instance.isRunning && currentMenu == Menus.Pause && Input.GetKeyDown(KeyCode.P))
        {
            GameManager.instance.isPaused = !GameManager.instance.isPaused;
            currentSceneMenus[(int)Menus.Pause - (numOfMenus - numOfRuntimeMenus)].SetActive(!currentSceneMenus[(int)Menus.Pause - (numOfMenus - numOfRuntimeMenus)].activeSelf);
        }
	}

    public void InstantiateMenus()
    {
        for (int i = 0; i < currentSceneMenus.Length; i++)
            currentSceneMenus[i] = Instantiate(currentSceneMenus[i], GameObject.Find("Menus").transform);

        if (!GameManager.instance.isRunning)
        {
            currentMenu = Menus.Intro;
            currentSceneMenus[(int)currentMenu].SetActive(true);
        }
        else
        {
            currentMenu = Menus.Pause;
        }
    }

    public void ChangeMenu(Menus menu)
    {
        previousMenu = currentMenu;
        currentMenu = menu;

        currentSceneMenus[!GameManager.instance.isRunning ? (int)previousMenu : (int)previousMenu - (numOfMenus - numOfRuntimeMenus)].SetActive(false);
        currentSceneMenus[!GameManager.instance.isRunning ? (int)currentMenu : (int)currentMenu - (numOfMenus - numOfRuntimeMenus)].SetActive(true);

        SoundManager.instance.playSFX(0);
    }
}