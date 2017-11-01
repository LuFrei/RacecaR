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

    public GameObject respawn;

    private void Start()
    {
        respawn = GameObject.Find("CheckPoint");
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
        if (other.CompareTag("Finish"))
        {
            lap += 1;
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
