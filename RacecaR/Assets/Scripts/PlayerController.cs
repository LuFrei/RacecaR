using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float turnSpeed;
    public bool reverse;
    public int lap = 0;
    public int lapLimit;
    public bool win;
    public int cpCount;

    public GameObject respawn;
    public CheckPoints1[] CP1 = new CheckPoints1[5];

    private void Start()
    {
        respawn = GameObject.Find("CheckPoint1");
        CP1[0] = GameObject.Find("CheckPoint1").GetComponent<CheckPoints1>();
        CP1[1] = GameObject.Find("CheckPoint2").GetComponent<CheckPoints1>();
        CP1[2] = GameObject.Find("CheckPoint3").GetComponent<CheckPoints1>();
        CP1[3] = GameObject.Find("CheckPoint4").GetComponent<CheckPoints1>();
        CP1[4] = GameObject.Find("CheckPoint5").GetComponent<CheckPoints1>();
    }
    // Update  is called once per frame
    void Update()
    {
        float hoz;

        if (Input.GetKey(KeyCode.A))
        {
            hoz = -1;
        }
        else if (Input.GetKey(KeyCode.D))
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

            if (Input.GetKey(KeyCode.W))
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
            CP1[0].active = true;
            CP1[1].active = true;
            CP1[2].active = true;
            CP1[3].active = true;
            CP1[4].active = true;
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
