using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerID;

    public float speed;
    //float currSpeed;
    public float turnSpeed;
    public bool reverse;
    
    public int pickupCount;
    public bool powerupActive;
    float powerupDuration = 5;
    public bool immune;

    public int lap = 0;
    public int checkpointCount;
    public int lapLimit;
    public bool win;

    public float topSpeed;
    float currentSpeed = 0;

    public Rigidbody rgb;
    public GameObject respawn;
    public CheckPoints[] CP = new CheckPoints[5];
   public GameMaster gm;

    float horizontalDirection;

    private void Start()
    {
        rgb = GetComponent<Rigidbody>();
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();

        powerupActive = false;
        immune = false;
    }
    // Update  is called once per frame
    void Update()
    {
        switch (playerID)
        {
            case 1:
            {
                if (Input.GetKey(KeyCode.A))
                {
                    horizontalDirection = -1;
                }
                else 
                    if (Input.GetKey(KeyCode.D))
                    {
                        horizontalDirection = 1;
                    }
                    else
                    {
                        horizontalDirection = 0;
                    }
                    break;
            }

            case 2:
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    horizontalDirection = -1;
                }
                else 
                    if (Input.GetKey(KeyCode.RightArrow))
                    {
                        horizontalDirection = 1;
                    }
                    else
                    {
                        horizontalDirection = 0;
                    }
                    break;
            }
        }

        if (reverse == true)
        {
            horizontalDirection = -horizontalDirection;
        }
        else
        {
            horizontalDirection = horizontalDirection;
        }

        if (win == false)
        {
            gameObject.transform.Rotate(0, horizontalDirection * turnSpeed, 0);
            //rgb.AddTorque(0, hoz * turnSpeed, 0);

            switch (playerID)
            {
                case 1:
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        Accelerate();
                    }
                    else
                    {
                        Decelerate();
                    }
                    break;
                }

                case 2:
                {
                    if (Input.GetKey(KeyCode.UpArrow))
                    {
                        Accelerate();
                    }
                    break;
                }
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

        if(gm.inversion && !immune)
        {
            reverse = true;
        }
        else
        {
            reverse = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish") && checkpointCount >= 5)
        {
            foreach (CheckPoints cp in CP)
                cp.GetComponent<CheckPoints>().inactive[playerID - 1] = false;

            lap++;
            checkpointCount = 0;
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
        float maxSpeed;
        

        maxSpeed = topSpeed;

        currentSpeed += 0.01f;

        if(currentSpeed >= maxSpeed)
        {
            currentSpeed = maxSpeed;
        }
        



        gameObject.transform.Translate(0, 0, currentSpeed);
        //rgb.AddForce(transform.forward * speed);
    }

    void Decelerate()
    {
        currentSpeed -= 0.02f;

        if(currentSpeed <= 0)
        {
            currentSpeed = 0;
        }

        gameObject.transform.Translate(0, 0, currentSpeed);
    }

    void Immunity()
    {
        immune = true;
        powerupDuration -= 1 * Time.deltaTime;

        if(powerupDuration <= 0)
        {
            immune = false;
            powerupDuration = 5;
            powerupActive = false;
            pickupCount -= 1;
        }
        
        Debug.Log(powerupDuration);
        //LeanTween.move(gameObject, respawn.transform, 1).setEase(LeanTweenType.easeInExpo);
    }
}