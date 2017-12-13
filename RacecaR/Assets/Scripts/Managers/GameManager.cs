using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isRunning;
    public bool isPaused;

    public Text timerText;
    float timer;

    public PlayerController player;
    public PlayerController player2;
    public float inverseDuration = 0;
    public float inverseCountdown;
    public bool inverseActive = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        UIManager.instance.InstantiateMenus();   
    }

    void Update()
    {
        if (isRunning && !isPaused)
        {
            timer = timer + 1 * Time.deltaTime;
            timerText.text = "" + timer;

            if (inverseActive)
            {
                inverseDuration -= 1 * Time.deltaTime;

                player.reverse = true;
                player2.reverse = true;

                if (inverseDuration <= 0)
                {
                    inverseCountdown = Random.Range(15f, 20f);
                    inverseActive = false;
                }
            }

            if (!inverseActive)
            {
                inverseCountdown -= 1 * Time.deltaTime;

                player.reverse = false;
                player2.reverse = false;

                if (inverseCountdown <= 0)
                {
                    inverseDuration = Random.Range(4f, 10f);
                    inverseActive = true;
                }
            }

            /*if (inverseCountdown <= 0)
            {
                resetDuration = true;

                if (resetDuration)
                {
                    inverseDuration = Random.Range(4f, 10f);
                    resetDuration = false;
                }
            }

            if (inverseDuration <= 0)
            {
                resetCountdown = true;

                if (resetCountdown)
                {
                    inverseCountdown = Random.Range(4f, 10f);
                    resetCountdown = false;
                }
            }*/
        }
    }

    public void StartGame()
    {
        StartCoroutine(LoadSceneAsync("Level 1"));
    }

    public void EndGame()
    {
        isPaused = false;
        isRunning = !isRunning;
        StartCoroutine(LoadSceneAsync("Main"));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        // The Application loads the Scene in the background at the same time as the current Scene.
        //This is particularly good for creating loading screens. You could also load the Scene by build //number.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        //Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
            yield return null;

        if (sceneName != "Main")
        {
            initializeValues();
            isRunning = !isRunning;
        }

        UIManager.instance.InstantiateMenus();
    }

    public void initializeValues()
    {
        inverseCountdown = Random.Range(20f, 25f);
        timerText = GameObject.Find("Timer").GetComponent<Text>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        player2 = GameObject.Find("Player2").GetComponent<PlayerController>();
    }
}