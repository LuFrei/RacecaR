using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{

    public float speed;
    public float turnSpeed;
    public bool reverse;
    public int lap = 0;
    public int lapLimit;
    public bool win;
    public int cpCount;

    public GameObject respawn;
    public CheckPoints2[] CP2 = new CheckPoints2[5];

    private void Start()
    {
        respawn = GameObject.Find("CheckPoint1");
        CP2[0] = GameObject.Find("CheckPoint1").GetComponent<CheckPoints2>();
        CP2[1] = GameObject.Find("CheckPoint2").GetComponent<CheckPoints2>();
        CP2[2] = GameObject.Find("CheckPoint3").GetComponent<CheckPoints2>();
        CP2[3] = GameObject.Find("CheckPoint4").GetComponent<CheckPoints2>();
        CP2[4] = GameObject.Find("CheckPoint5").GetComponent<CheckPoints2>();
    }
    // Update  is called once per frame
    void Update()
    {
        float hoz;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            hoz = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            hoz = 1;
        }
        else
        {
            hoz = 0;
        }


        if (reverse == true)
        {
            hoz = -hoz;
        }
        else
        {
            hoz = hoz;
        }


        if (win == false)
        {

            gameObject.transform.Rotate(0, hoz * turnSpeed, 0);

            if (Input.GetKey(KeyCode.UpArrow))
            {
                gameObject.transform.Translate(0, 0, speed);
            }

            if (lap >= lapLimit)
            {
                win = true;
            }
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish") && cpCount >= 5)
        {
            lap += 1;
            cpCount = 0;
            CP2[0].active = true;
            CP2[1].active = true;
            CP2[2].active = true;
            CP2[3].active = true;
            CP2[4].active = true;
        }

        if (other.CompareTag("Respawn"))
        {
            respawn = other.gameObject;
        }

        if (other.CompareTag("KillBox"))
        {
            transform.position = respawn.transform.position;
            transform.rotation = respawn.transform.rotation;
        }
    }
}
