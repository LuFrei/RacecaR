using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float turnSpeed;
    public bool reverse;
    public int lapLimit;
    public bool immune;
    public int pickupCount;
    public int cpCount;
    public bool powerupActive;
    float duration = 5;
    //float currSpeed;

    public int lap = 0;
    public bool win;
    
    public Rigidbody rgb;
    public GameObject respawn;
    public CheckPoints1[] CP1 = new CheckPoints1[5];

    private void Start()
    {
        rgb = GetComponent<Rigidbody>();

        respawn = GameObject.Find("CheckPoint1");
        CP1[0] = GameObject.Find("CheckPoint1").GetComponent<CheckPoints1>();
        CP1[1] = GameObject.Find("CheckPoint2").GetComponent<CheckPoints1>();
        CP1[2] = GameObject.Find("CheckPoint3").GetComponent<CheckPoints1>();
        CP1[3] = GameObject.Find("CheckPoint4").GetComponent<CheckPoints1>();
        CP1[4] = GameObject.Find("CheckPoint5").GetComponent<CheckPoints1>();

        powerupActive = false;
        immune = false;
    }
    // Update  is called once per frame
    void Update()
    {
        //currSpeed = 
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
            //rgb.AddTorque(0, hoz * turnSpeed, 0);

            if (Input.GetKey(KeyCode.W))
            {
                Accelerate();
            }

            if (lap >= lapLimit)
            {
                win = true;
            }
        }

        //toggle powerup
        if (pickupCount > 0 && Input.GetKeyDown(KeyCode.E))
        {
            powerupActive = true;
        }


        if (powerupActive)
        {
            Immunity();
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

    void Accelerate()
    {
        gameObject.transform.Translate(0, 0, speed);
        //rgb.AddForce(transform.forward * speed);
    }

    void Immunity()
    {

        immune = true;
        duration -= 1 * Time.deltaTime;

        if(duration <= 0)
        {
            immune = false;
            duration = 5;
            powerupActive = false;
            pickupCount -= 1;
        }
        
        Debug.Log(duration);
        //LeanTween.move(gameObject, respawn.transform, 1).setEase(LeanTweenType.easeInExpo);

    }
}
